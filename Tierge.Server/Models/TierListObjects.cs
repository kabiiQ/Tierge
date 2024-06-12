namespace Tierge.Server.Models
{
    public static class TierListObjects
    {
        public class Tier
        {
            public string Label { get; set; } = null!;

            public int Color { get; set; }
        }

        public class Item
        {
            private Tier? _tier = null;
            private bool _ignored = false;

            public string Caption { get; set; } = null!;

            public string ImageHash { get; set; } = null!;

            public bool Ignored
            {
                get => _ignored;
                set
                {
                    // If item is ignored, should not be assigned to a tier
                    _ignored = value;
                    Tier = null;
                }
            }

            public Tier? Tier
            {
                get => _tier;
                set
                {
                    // If item is assigned to a tier, it can no longer be ignored
                    _tier = value;
                    Ignored = false;
                }
            }
        }
    }
}
