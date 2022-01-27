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
        private readonly HttpClient _httpClient;

        public PokemonService(IDatabaseService databaseService, INetworkService networkService, IUriBuilderService uriBuilderService)
        {
            _databaseService = databaseService;
            _networkService = networkService;
            _uriBuilderService = uriBuilderService;

            _httpClient = new HttpClient();
        }

        public async Task<IList<PokemonDetail>> GetPokemonDetailsAsync(int offset, int limit = 10)
        {
            try
            {
                var localData = _databaseService.GetById<PokemonDetailDatabaseObject>(Statics.PokemonId, Statics.PokemonCollectionName);
                if (localData != null)
                {
                    if (localData.Pokemons.Count > offset + limit)
                        return localData.Pokemons.Skip(offset).Take(limit).ToList();
                }

                if (!_networkService.HasInternetAccess)
                    return null;

                var pokemons = new List<PokemonDetail>();

                for (int i = 1; i <= limit; i++)
                {
                    var uri = _uriBuilderService.GetPokemonDetailUri(offset + i);

                    var response = await _httpClient.GetAsync(uri);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        var pokemonDetail = JsonConvert.DeserializeObject<PokemonDetail>(jsonResponse);

                        pokemons.Add(pokemonDetail);
                    }
                }

                var newPokemons = new List<PokemonDetail>(pokemons);

                if (localData != null)
                    pokemons.AddRange(localData.Pokemons);

                _databaseService.Upsert(new PokemonDetailDatabaseObject { Pokemons = pokemons.Distinct().OrderBy(p => p.Id).ToList() }, Statics.PokemonCollectionName);

                return newPokemons.OrderBy(p => p.Id).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{GetType().Name} | {nameof(GetPokemonDetailsAsync)} | {ex}");
            }

            return null;
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

                var response = await _httpClient.GetAsync(uri);

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
