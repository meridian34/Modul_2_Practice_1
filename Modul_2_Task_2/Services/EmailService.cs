namespace Modul_2_Practice_1.Services
{
    public class EmailService
    {
        private readonly Logger _logger;

        public EmailService()
        {
            _logger = Logger.Instance;
        }

        public void Send(string email, string message)
        {
            _logger.LogInfo($"Send to email - {email}, message: {message}");
        }
    }
}
