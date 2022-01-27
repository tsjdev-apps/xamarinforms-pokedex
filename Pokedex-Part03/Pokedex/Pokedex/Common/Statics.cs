namespace Pokedex.Common
{
    public static class Statics
    {
        public static string BaseUrl = "https://pokeapi.co/api/v2/";

        public static string TypeUri = "type";
        public static string PokemonDetailsUri = "pokemon/{0}";

        public static string PokemonTypesId = nameof(PokemonTypesId);
        public static string PokemonTypeCollectionName = nameof(PokemonTypeCollectionName);

        public static string PokemonId = nameof(PokemonId);
        public static string PokemonCollectionName = nameof(PokemonCollectionName);

        public static int DefaultLimit = 10;
    }
}
