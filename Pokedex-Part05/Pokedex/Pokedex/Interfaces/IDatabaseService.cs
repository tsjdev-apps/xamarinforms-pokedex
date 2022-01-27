namespace Pokedex.Interfaces
{
    public interface IDatabaseService
    {
        T GetById<T>(string id, string collectionName);
        bool DeleteById<T>(string id, string collectionName);
        bool Upsert<T>(T item, string collectionName);
    }
}
