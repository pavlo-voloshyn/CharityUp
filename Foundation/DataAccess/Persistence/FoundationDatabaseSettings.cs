namespace DataAccess.Persistence;

public class FoundationDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string FoundationCollectionName { get; set; } = null!;

    public string FoundationRequestCollectionName { get; set; } = null!;

}
