using LiteDB;
using Newtonsoft.Json;
using Pokedex.Common;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public class PokemonTypeRootObject
    {
        [JsonProperty("results")]
        public PokemonType[] Types { get; set; }
    }

    public class PokemonType
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class PokemonTypesDatabaseObject
    {
        [BsonId]
        public string Id { get; } = Statics.PokemonTypesId;
        public IList<string> PokemonTypes { get; set; }
    }
}
