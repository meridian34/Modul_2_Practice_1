using Modul_2_Practice_1.Entities;
using Modul_2_Practice_1.Services;

namespace Modul_2_Practice_1.Controllers
{
    public class PurchaseController
    {
        private readonly Basket _basket;
        private readonly Logger _logger;

        public PurchaseController()
        {
            _basket = Basket.Instance;
            _logger = Logger.Instance;
        }

        public void MakeAnOrder(CustomerContactInformation information)
        {
            _logger.LogInfo($"Invoke: {nameof(MakeAnOrder)}");
            if (CheckCustomerInformation(information))
            {
                var order = new Order();
                order.Products = _basket.GetOrderProducts();
                order.CustomerContactInformation = information;
                order.CloseOrder();
                _basket.BasketClear();
            }
        }

        private bool CheckCustomerInformation(CustomerContactInformation info)
        {
            _logger.LogInfo($"Invoke: {nameof(CheckCustomerInformation)}");
            if (string.IsNullOrEmpty(info.Address))
            {
                _logger.LogWarning($"{nameof(CustomerContactInformation.Address)} == null/empty");
                return false;
            }
            else if (string.IsNullOrEmpty(info.FirstName))
            {
                _logger.LogWarning($"{nameof(CustomerContactInformation.FirstName)} == null/empty");
                return false;
            }
            else if (string.IsNullOrEmpty(info.LastName))
            {
                _logger.LogWarning($"{nameof(CustomerContactInformation.LastName)} == null/empty");
            }
            else if (string.IsNullOrEmpty(info.Phone) || string.IsNullOrEmpty(info.Email))
            {
                _logger.LogWarning($"{nameof(CustomerContactInformation.Phone)} or {nameof(CustomerContactInformation.Email)} == null/empty");
                return false;
            }
            else
            {
                return true;
            }

            _logger.LogWarning($"В {nameof(CheckCustomerInformation)} шо то пошло не так");
            return false;
        }
    }
}
