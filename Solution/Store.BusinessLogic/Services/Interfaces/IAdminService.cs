using PrintStore.BusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PrintStore.BusinessLogic.Services.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<AdminManagmentViewModel> GetAllUsersOrder();
        IEnumerable<AdminManagmentViewModel> OrderSort(SortOrder order, string sortedColumn);
        IEnumerable<AdminManagmentViewModel> FilterByOrderStatus(bool value);
    }
}
