namespace FoundationService.DataAccess.Persistence;

/// <summary>
/// The class which contains all config fields for database
/// </summary>
public class FoundationDatabaseSettings
{
    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }

    public string FoundationCollectionName { get; set; }

    public string FoundationRequestCollectionName { get; set; }

}
