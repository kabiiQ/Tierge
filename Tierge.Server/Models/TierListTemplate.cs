using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Tierge.Server.Models
{
    public class TierListTemplate
    {
        public ObjectId Id { get; set; }

        public int AuthorId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CoverImage { get; set; } = null!;

        // TODO category 

        public DateTime Created { get; set; }

        public DateTime LastUpdated { get; set; }

        public IList<TierListObjects.Tier> Tiers { get; } = null!;

        public IList<TierListObjects.Item> Items { get; } = null!;
    }
}
