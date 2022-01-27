using Pokedex.Interfaces;
using Pokedex.Models;
using Pokedex.Views;
using Rg.Plugins.Popup.Extensions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pokedex.Services
{
    public class DialogService : IDialogService
    {
        public async Task CloseDialogAsync()
        {
            await Application.Current.MainPage.Navigation.PopPopupAsync();
        }

        public async Task OpenPokemonDetailsDialogAsync(PokemonDetail pokemonDetail)
        {
            await Application.Current.MainPage.Navigation.PushPopupAsync(new PokemonDetailDialogPage(pokemonDetail));
        }
    }
}
