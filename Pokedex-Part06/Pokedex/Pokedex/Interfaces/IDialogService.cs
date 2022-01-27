using Pokedex.Models;
using System.Threading.Tasks;

namespace Pokedex.Interfaces
{
    public interface IDialogService
    {
        Task OpenPokemonDetailsDialogAsync(PokemonDetail pokemonDetail);

        Task CloseDialogAsync();
    }
}
