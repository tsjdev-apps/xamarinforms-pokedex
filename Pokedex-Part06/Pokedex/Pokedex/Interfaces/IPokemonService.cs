using Pokedex.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pokedex.Interfaces
{
    public interface IPokemonService
    {
        Task<IList<string>> GetPokemonTypesAsync();

        Task<IList<PokemonDetail>> GetPokemonDetailsAsync(int offset, int limit);
    }
}
