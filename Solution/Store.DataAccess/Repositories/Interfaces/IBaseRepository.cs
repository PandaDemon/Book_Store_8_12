using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        void Create();
        void Update();
        void Delete();
    }
}
