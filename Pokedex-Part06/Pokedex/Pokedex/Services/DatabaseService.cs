using LiteDB;
using Pokedex.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Essentials;

namespace Pokedex.Services
{
    public class DatabaseService : IDatabaseService
    {
        protected LiteDatabase _database;

        public T GetById<T>(string id, string collectionName)
        {
            Init();

            // get collection
            var collection = _database.GetCollection<T>(collectionName);

            // get item
            return collection.FindById(id);
        }

        public bool DeleteById<T>(string id, string collectionName)
        {
            Init();

            // get collection
            var collection = _database.GetCollection<T>(collectionName);

            // delete items
            var result = collection.Delete(id);

            return result;
        }

        public bool Upsert<T>(T item, string collectionName)
        {
            try
            {
                Init();

                // get collection
                var collection = _database.GetCollection<T>(collectionName);

                // insert or update items
                return collection.Upsert(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{GetType().Name} | {nameof(Upsert)} | {ex}");
            }

            return false;
        }

        private void Init()
        {
            try
            {
                if (_database == null)
                    _database = new LiteDatabase($"Filename={GetDatabasePath()}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"{GetType().Name} | {nameof(Init)} | {ex}");
            }
        }

        private string GetDatabasePath()
        {
            return Path.Combine(FileSystem.AppDataDirectory, "PokemonDatabase.db");
        }
    }
}
