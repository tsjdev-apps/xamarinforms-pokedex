using Pokedex.Common;
using Pokedex.Interfaces;
using Pokedex.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Pokedex.ViewModels
{
    public class OverviewPageViewModel : BaseViewModel
    {
        private readonly IPokemonService _pokemonService;

        private bool _isLoadingData;
        public bool IsLoadingData
        {
            get => _isLoadingData;
            set => SetProperty(ref _isLoadingData, value);
        }

        private IList<string> _pokemonTypes;
        public IList<string> PokemonTypes
        {
            get => _pokemonTypes;
            set => SetProperty(ref _pokemonTypes, value);
        }

        private ObservableCollection<PokemonDetail> _pokemons;
        public ObservableCollection<PokemonDetail> Pokemons
        {
            get => _pokemons;
            set => SetProperty(ref _pokemons, value);
        }

        private IAsyncCommand _getPokemonTypesCommand;
        public IAsyncCommand GetPokemonTypesCommand => _getPokemonTypesCommand ?? (_getPokemonTypesCommand = new AsyncCommand(GetPokemonTypesAsync, allowsMultipleExecutions: false));

        private IAsyncCommand _loadPokemonsCommand;
        public IAsyncCommand LoadPokemonsCommand => _loadPokemonsCommand ?? (_loadPokemonsCommand = new AsyncCommand(LoadPokemonsAsync, allowsMultipleExecutions: false));

        private IAsyncCommand _loadMorePokemonsCommand;
        public IAsyncCommand LoadMorePokemonsCommand => _loadMorePokemonsCommand ?? (_loadMorePokemonsCommand = new AsyncCommand(LoadMorePokemonsAsync, allowsMultipleExecutions: false));

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

        private async Task LoadPokemonsAsync()
        {
            if (Pokemons != null)
                return;

            IsLoading = true;

            var pokemons = await _pokemonService.GetPokemonDetailsAsync(0, Statics.DefaultLimit);

            if (pokemons != null)
                Pokemons = new ObservableRangeCollection<PokemonDetail>(pokemons);

            IsLoading = false;
        }

        private async Task LoadMorePokemonsAsync()
        {
            if (Pokemons == null)
                return;

            IsLoadingData = true;

            var pokemons = await _pokemonService.GetPokemonDetailsAsync(Pokemons.Count, Statics.DefaultLimit);
            if (pokemons != null)
                Pokemons.AddRange(pokemons);

            IsLoadingData = false;
        }
    }
}
