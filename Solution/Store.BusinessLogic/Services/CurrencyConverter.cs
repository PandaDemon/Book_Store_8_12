using PrintStore.BusinessLogic.Services.Interfaces;
using PrintStore.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PrintStore.BusinessLogic.Services
{
    public class CurrencyConverter : ICurrencyConverter
    {
        private const string _storeDefaultCurrency = "USD";
        private Dictionary<string, double> _exchengeRateToDefault;
        private Dictionary<string, double> _exchengeRateToUserCurrency;

        public CurrencyConverter()
        {
            _exchengeRateToDefault = new Dictionary<string, double>();
            _exchengeRateToDefault.Add("EUR", 1.11);
            _exchengeRateToDefault.Add("UAN", 0.04);

            _exchengeRateToUserCurrency = new Dictionary<string, double>();
            _exchengeRateToUserCurrency.Add("EUR", 1.11);
            _exchengeRateToUserCurrency.Add("UAN", 25);
        }

        private double ConvertToDafaultIfNeeded(Currency currency, double price)
        {
            if (_exchengeRateToDefault.ContainsKey(currency.CurrencyName))
            {
                return price * _exchengeRateToDefault[currency.CurrencyName];
            }

            return price;
        }

        public double Convert(Currency currencyBegin, double price, string currencyForUser)
        {
            double pricedDefault = price;

            if (currencyBegin.CurrencyName != _storeDefaultCurrency)
            {
                pricedDefault = ConvertToDafaultIfNeeded(currencyBegin, price);
            }

            if (currencyForUser == _storeDefaultCurrency)
            {
                return pricedDefault;
            }

            return pricedDefault * _exchengeRateToUserCurrency[currencyForUser];
        }
    }
}
