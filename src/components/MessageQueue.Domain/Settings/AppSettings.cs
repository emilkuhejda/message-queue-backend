namespace MessageQueue.Domain.Settings
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }

        public string[] AllowedHosts { get; set; }
    }
}
