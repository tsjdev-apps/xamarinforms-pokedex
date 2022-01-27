using Pokedex.Common;
using Pokedex.Interfaces;

namespace Pokedex.Services
{
public class UriBuilderService : IUriBuilderService
{
    public string GetPokemonTypesUri()
    {
        return $"{Statics.BaseUrl}{Statics.TypeUri}";
    }
}
}
