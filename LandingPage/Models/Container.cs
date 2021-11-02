using System;
using LandingPage.Static;

namespace LandingPage.Models
{
    public class Container
    {
        public Guid Key { get; set; }
        public Guid ParentKey { get; set; }
        public string Name { get; set; }
        public EntityType Type { get; set; }

        public Container(Guid key, string name, EntityType type)
        {
            Key = key;
            Name = name;
            Type = type;
        }

        public Container(Guid key, string name, Guid parentKey, EntityType type)
        {
            Key = key;
            Name = name;
            ParentKey = parentKey;
            Type = type;
        }
    }
}
