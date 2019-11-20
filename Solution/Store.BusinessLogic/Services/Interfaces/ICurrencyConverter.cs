using PrintStore.DataAccess.Entities;

namespace PrintStore.BusinessLogic.Services.Interfaces
{
    public interface ICurrencyConverter
    {
        double Convert(Currency currencyBegin, double price, string currencyForUser);
    }
}
