namespace MongoDbJäsenrekisteri
{
    public class JasenrekisteriSettings
    {
        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;

        public string JasenCollectionName { get; set; } = string.Empty;
    }
}
