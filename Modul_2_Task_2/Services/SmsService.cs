namespace Modul_2_Practice_1.Services
{
    public class SmsService
    {
        private readonly Logger _logger;

        public SmsService()
        {
            _logger = Logger.Instance;
        }

        public void Send(string phone, string message)
        {
            _logger.LogInfo($"Send to sms - {phone}, message: {message}");
        }
    }
}
