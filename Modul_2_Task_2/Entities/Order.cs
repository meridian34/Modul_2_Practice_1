using System;
using Modul_2_Practice_1.Converters;
using Modul_2_Practice_1.Services;

namespace Modul_2_Practice_1.Entities
{
    public class Order
    {
        private readonly CurrencyConverter _currencyConverter = new CurrencyConverter();
        private readonly Logger _logger;
        private readonly EmailService _emailService;
        private readonly SmsService _smsService;

        public Order()
        {
            Products = null;
            _logger = Logger.Instance;
            _emailService = new EmailService();
            _smsService = new SmsService();
        }

        public Product[] Products { get; set; }

        public CustomerContactInformation CustomerContactInformation { get; set; }

        public void CloseOrder()
        {
            _logger.LogInfo($"Order closing in {DateTime.UtcNow}");
            var message = $"{CustomerContactInformation.FirstName} {CustomerContactInformation.LastName} bought goods worth {GetSumPrices()} {CustomerContactInformation.SelectedCurrency}";
            if (!string.IsNullOrEmpty(CustomerContactInformation.Email))
            {
                _emailService.Send(CustomerContactInformation.Email, message);
            }

            if (!string.IsNullOrEmpty(CustomerContactInformation.Phone))
            {
                _smsService.Send(CustomerContactInformation.Phone, message);
            }
        }

        public decimal GetSumPrices()
        {
            var sum = 0.0m;
            foreach (var item in Products)
            {
                sum = sum + _currencyConverter.CurrencyConvertIn(CustomerContactInformation.SelectedCurrency, item.Price);
            }

            return sum;
        }
    }
}
