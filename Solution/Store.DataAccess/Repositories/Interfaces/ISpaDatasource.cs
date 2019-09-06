using Store.DataAccess.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface ISpaDatasource
    {
      //  #region API : Открытие и закрытие соединения

        void Open();
        void Close();

     //   #endregion

     //   #region API : Работа с пользователями

        IEnumerable Users();
        User FindUserById(string id);
        User FindUserByName(string name);
        void InsertUser(User user);
        void UpdateUser(User user);

      //  #endregion
    }
}
