using AutoMapper;
using Store.BusinessLogic.Models.User;
using Store.DataAccess.Entities;

namespace Store.BusinessLogic.Mapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<UserCreateModel, User>();
            CreateMap<UserEditModel, User>();
            CreateMap<UserChangePasswordModel, User>();
            CreateMap<UserSignUpModel, User>();
        }

		public static User MapModelToEntity(UserModel model)
		{
			var entity = new User();
			if (!string.IsNullOrWhiteSpace(model.Id))
			{
				entity.Id = model.Id;
			}
			entity.FirstName = model.FirstName;
			entity.LastName = model.LastName;
			entity.Email = model.Email;
			entity.UserName = model.UserName;
			return entity;
		}

		public static UserModel MapEntityToModel(User entity)
		{
			var model = new UserModel();
			model.Id = entity.Id;
			model.FirstName = entity.FirstName;
			model.LastName = entity.LastName;
			model.Email = entity.Email;
			model.UserName = entity.UserName;
			return model;
		}
	}
}
