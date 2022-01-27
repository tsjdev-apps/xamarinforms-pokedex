using Pokedex.Interfaces;
using Xamarin.Essentials;

namespace Pokedex.Services
{
public class NetworkService : INetworkService
{
    public bool HasInternetAccess 
            => Connectivity.NetworkAccess == NetworkAccess.Internet;
}
}
