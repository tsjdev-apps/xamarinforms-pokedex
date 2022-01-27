using Newtonsoft.Json;
using Pokedex.Common;
using Pokedex.Interfaces;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IDatabaseService _databaseService;
        private readonly INetworkService _networkService;
        private readonly IUriBuilderService _uriBuilderService;

        public PokemonService(IDatabaseService databaseService, INetworkService networkService, IUriBuilderService uriBuilderService)
        {
            _databaseService = databaseService;
            _networkService = networkService;
            _uriBuilderService = uriBuilderService;
        }

        public async Task<IList<string>> GetPokemonTypesAsync()
        {
            try
            {
                var localData = _databaseService.GetById<PokemonTypesDatabaseObject>(Statics.PokemonTypesId, Statics.PokemonTypeCollectionName);
                if (localData != null)
                    return localData.PokemonTypes;

                if (!_networkService.HasInternetAccess)
                    return null;

                var uri = _uriBuilderService.GetPokemonTypesUri();
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var pokemonTypeRootObject = JsonConvert.DeserializeObject<PokemonTypeRootObject>(jsonResponse);

                    var pokemonTypes = pokemonTypeRootObject?.Types?.Select(x => x.Name).ToList();
                    _databaseService.Upsert(new PokemonTypesDatabaseObject { PokemonTypes = pokemonTypes }, Statics.PokemonTypeCollectionName);
                    return pokemonTypes;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{GetType().Name} | {nameof(GetPokemonTypesAsync)} | {ex}");
            }

            return null;
        }
    }
}
