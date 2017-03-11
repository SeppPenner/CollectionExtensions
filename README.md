CollectionExtensions
====================================

CollectionExtensions is an dll/ assembly that contains useful extensions to Lists, Dictionaries and ObservableCollections.
The assembly was written and tested in .Net 4.6.2.

[![Build status](https://ci.appveyor.com/api/projects/status/0p2unbxcfge97f84?svg=true)](https://ci.appveyor.com/project/SeppPenner/512kbchecker)


## Basic usage:
```csharp
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CollectionExtensions;

namespace ExampleUsage
{
    internal static class Program
    {
        public static void Main()
        {
            TestDictionary();
            TestList();
            TestObservableCollection();
            Console.ReadKey();
        }

        private static void TestDictionary()
        {
            Console.WriteLine("Dictionary Test:");
            Console.WriteLine("");
            var dictionary = new Dictionary<string, string>();
            dictionary.AddIfNotExists("a", "abc");
            dictionary.AddIfNotExists("a", "abc");
            dictionary.AddIfNotExists("b", "def");
            PrintDictionaryToConsole(dictionary);
            dictionary.Update("b", "defg");
            PrintDictionaryToConsole(dictionary);
            var pair = dictionary.First(x => x.Key.Equals("b"));
            dictionary.Update(pair);
            PrintDictionaryToConsole(dictionary);
            dictionary.DeleteIfExistsKey("a");
            PrintDictionaryToConsole(dictionary);
            dictionary.DeleteIfExistsValue("defg");
            PrintDictionaryToConsole(dictionary);
            Print(dictionary.AreKeysEmpty());
            Print(dictionary.AreValuesEmpty());
        }

        private static void TestObservableCollection()
        {
            Console.WriteLine("ObservableCollection Test:");
            Console.WriteLine("");
            var observableCollection = new ObservableCollection<string>();
            observableCollection.AddIfNotExists("a");
            observableCollection.AddIfNotExists("a");
            observableCollection.AddIfNotExists("b");
            PrintObservableCollectionToConsole(observableCollection);
            observableCollection.DeleteIfExists("a");
            PrintObservableCollectionToConsole(observableCollection);
            observableCollection.UpdateValue("b", "c");
            PrintObservableCollectionToConsole(observableCollection);
            observableCollection.DeleteIfExists("c");
            PrintObservableCollectionToConsole(observableCollection);
            Print(observableCollection.AreValuesEmpty());
        }

        private static void TestList()
        {
            Console.WriteLine("List Test:");
            Console.WriteLine("");
            var list = new List<string>();
            list.AddIfNotExists("a");
            list.AddIfNotExists("a");
            list.AddIfNotExists("b");
            PrintListToConsole(list);
            list.DeleteIfExists("a");
            PrintListToConsole(list);
            list.UpdateValue("b", "c");
            PrintListToConsole(list);
            list.DeleteIfExists("c");
            PrintListToConsole(list);
            Print(list.AreValuesEmpty());
        }

        private static void PrintObservableCollectionToConsole(ObservableCollection<string> collection)
        {
            if (!collection.Any())
                Console.WriteLine("Empty collection");
            else
                foreach (var value in collection)
                    Console.WriteLine(value);
            Console.WriteLine("-------------------------------------");
        }

        private static void PrintListToConsole(IEnumerable<string> list)
        {
            var enumerable = list as string[] ?? list.ToArray();
            if (!enumerable.Any())
                Console.WriteLine("Empty list");
            else
                foreach (var value in enumerable)
                    Console.WriteLine(value);
            Console.WriteLine("-------------------------------------");
        }

        private static void PrintDictionaryToConsole(Dictionary<string, string> dictionary)
        {
            if (dictionary.Count == 0)
                Console.WriteLine("Empty dictionary");
            else
                foreach (var pair in dictionary)
                    Console.WriteLine(pair.Key + ":" + pair.Value);
            Console.WriteLine("-------------------------------------");
        }

        private static void Print(bool value)
        {
            Console.WriteLine(value);
            Console.WriteLine("-------------------------------------");
        }
    }
}
```

An example project therefore can be found [here](https://github.com/SeppPenner/CSharpLanguageManager/tree/master/ExampleProject).

Change history
--------------

* **Version 1.0.0.0 (2017-03-11)** : 1.0 release.