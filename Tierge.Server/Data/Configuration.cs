namespace Tierge.Server.Data
{
    public class Configuration
    {
        public string FrontendOrigin { get; set; } = null!;
    }

    public class DatabaseSettings
    {
        public string MongoDB { get; set; } = null!;

        public string PostgreSQL { get; set; } = null!;
    }
}
