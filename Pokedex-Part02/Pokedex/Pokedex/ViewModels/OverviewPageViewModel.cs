using Pokedex.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Pokedex.ViewModels
{
    public class OverviewPageViewModel : BaseViewModel
    {
        private readonly IPokemonService _pokemonService;

        private IList<string> _pokemonTypes;
        public IList<string> PokemonTypes
        {
            get => _pokemonTypes;
            set => SetProperty(ref _pokemonTypes, value);
        }

        private IAsyncCommand _getPokemonTypesCommand;
        public IAsyncCommand GetPokemonTypesCommand
            => _getPokemonTypesCommand
            ?? (_getPokemonTypesCommand = new AsyncCommand(GetPokemonTypesAsync, allowsMultipleExecutions: false));


        public OverviewPageViewModel(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        private async Task GetPokemonTypesAsync()
        {
            IsLoading = true;

            PokemonTypes = await _pokemonService.GetPokemonTypesAsync();

            IsLoading = false;
        }

    }
}
