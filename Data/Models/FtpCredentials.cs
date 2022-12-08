namespace Domain.Models
{
    public class FtpCredentials
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PathToFiles { get; set; }
        public int Port { get; set; }
    }
}
