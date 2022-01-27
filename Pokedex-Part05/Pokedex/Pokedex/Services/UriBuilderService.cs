using Pokedex.Common;
using Pokedex.Interfaces;

namespace Pokedex.Services
{
    public class UriBuilderService : IUriBuilderService
    {
        public string GetPokemonDetailUri(int id)
        {
            return $"{Statics.BaseUrl}{string.Format(Statics.PokemonDetailsUri, id)}";
        }

        public string GetPokemonTypesUri()
        {
            return $"{Statics.BaseUrl}{Statics.TypeUri}";
        }
    }
}
