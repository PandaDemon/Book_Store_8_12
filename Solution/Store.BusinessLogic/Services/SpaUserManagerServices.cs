using Store.DataAccess.Entities;
using Store.DataAccess.Helpers;
using Store.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace Store.BusinessLogic.Services
{
    class SpaUserManagerServices : IUserManager
    {
        private ISpaDatasource _SpaDatasource;

        public SpaUserManagerServices(ISpaDatasource spaDatasource)
        {
            _SpaDatasource = spaDatasource;
        }

        public Task<bool> CheckPasswordAsync(User user, string password)
        {
            bool isValid = PasswordHasher.Verify(password, user.PasswordHash);

            return Task.FromResult<bool>(isValid);
        }

        public Task<User> FindByNameAsync(string username)
        {
            return Task<User>.Run(() =>
            {
                User u = null;

                try
                {
                    _SpaDatasource.Open();

                    u = _SpaDatasource.FindUserByName(username);
                }
                finally
                {
                    _SpaDatasource.Close();
                }

                return u;
            });
        }

        public Task CreateAsync(User user, string password)
        {
            return Task<User>.Run(() =>
            {
                try
                {
                    user.PasswordHash = PasswordHasher.Hash(password);

                    _SpaDatasource.Open();

                    _SpaDatasource.InsertUser(user);
                }
                finally
                {
                    _SpaDatasource.Close();
                }
            });
        }

        Task IUserManager.FindByNameAsync(string username)
        {
            throw new System.NotImplementedException();
        }

        Task IUserManager.CheckPasswordAsync(User user, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
