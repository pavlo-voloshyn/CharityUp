using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models;

/// <summary>
/// The entity for representing foundation requests in database
/// </summary>
public class FoundationRequest
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    public string Name { get; set; }

    public int YearOfFoundation { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public string Website { get; set; }

    public string IBAN { get; set; }

    public string Phone { get; set; }

    public DateTime DateOfRequesting { get; set; }
}
