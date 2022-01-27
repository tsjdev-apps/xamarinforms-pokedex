namespace Pokedex.Interfaces
{
    public interface IUriBuilderService
    {
        string GetPokemonTypesUri();
        string GetPokemonDetailUri(int id);
    }
}
