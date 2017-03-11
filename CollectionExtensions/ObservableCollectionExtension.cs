using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CollectionExtensions
{
    public static class ObservableCollectionExtension
    {
        public static void AddIfNotExists<T>(this ObservableCollection<T> collection, T value)
        {
            CheckObservableCollectionIsNull(collection);
            if (!collection.Contains(value))
                collection.Add(value);
        }

        public static void UpdateValue<T>(this ObservableCollection<T> collection, T value, T newValue)
        {
            CheckObservableCollectionAndValueIsNull(collection, value);
            CheckValueIsNull(newValue);
            var index = collection.IndexOf(value);
            collection[index] = newValue;
        }

        public static void DeleteIfExists<T>(this ObservableCollection<T> collection, T value)
        {
            CheckObservableCollectionAndValueIsNull(collection, value);
            if (collection.Contains(value))
                collection.Remove(value);
        }

        public static bool AreValuesEmpty<T>(this ObservableCollection<T> collection)
        {
            CheckObservableCollectionIsNull(collection);
            return collection.All(x => x == null);
        }

        private static void CheckObservableCollectionAndValueIsNull<T>(this ObservableCollection<T> collection, T value)
        {
            CheckObservableCollectionIsNull(collection);
            CheckValueIsNull(value);
        }

        private static void CheckValueIsNull<T>(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
        }

        private static void CheckObservableCollectionIsNull<T>(this ObservableCollection<T> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
        }
    }
}