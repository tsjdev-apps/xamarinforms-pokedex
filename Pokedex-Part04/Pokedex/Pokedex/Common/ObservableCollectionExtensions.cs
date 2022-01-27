using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pokedex.Common
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T>(this ObservableCollection<T> observableCollection,
            IEnumerable<T> collection)
        {
            if (observableCollection == null)
                throw new ArgumentNullException(nameof(observableCollection));

            foreach (var i in collection)
                observableCollection.Add(i);
        }
    }
}
