using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace Tierge.Server.Models
{
    public class TierList
    {
        public ObjectId Id { get; set; }

        public ObjectId Template { get; set; }

        public int? AuthorId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime Created { get; set; }

        public DateTime LastUpdated { get; set; }

        public IList<TierListObjects.Tier> Tiers { get; set; } = null!;

        public IList<TierListObjects.Item> Items { get; } = new List<TierListObjects.Item>();
    }

    public record TierListDto
}
