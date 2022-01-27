using LiteDB;
using Newtonsoft.Json;
using Pokedex.Common;
using System.Collections.Generic;

namespace Pokedex.Models
{
    public class PokemonDetail
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("sprites")]
        public OtherSprite Sprite { get; set; }

        [JsonProperty("types")]
        public IList<TypeDetails> Types { get; set; }
    }

    public class OtherSprite
    {
        [JsonProperty("other")]
        public OfficialArtwork Image { get; set; }
    }

    public class OfficialArtwork
    {
        [JsonProperty("official-artwork")]
        public Image Artwork { get; set; }
    }

    public class Image
    {
        [JsonProperty("front_default")]
        public string ImagePath { get; set; }
    }

    public class TypeDetails
    {
        [JsonProperty("type")]
        public PokemonType PokemonType { get; set; }
    }

    public class PokemonDetailDatabaseObject
    {
        [BsonId]
        public string Id { get; } = Statics.PokemonId;
        public IList<PokemonDetail> Pokemons { get; set; }
    }
}
