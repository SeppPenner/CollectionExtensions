CollectionExtensions
====================================

CollectionExtensions is an dll/ assembly that contains useful extensions to Lists, Dictionaries and ObservableCollections.
The assembly was written and tested in .Net 4.8.

[![Build status](https://ci.appveyor.com/api/projects/status/x2rink65wav91ap0?svg=true)](https://ci.appveyor.com/project/SeppPenner/collectionextensions)
[![GitHub issues](https://img.shields.io/github/issues/SeppPenner/CollectionExtensions.svg)](https://github.com/SeppPenner/CollectionExtensions/issues)
[![GitHub forks](https://img.shields.io/github/forks/SeppPenner/CollectionExtensions.svg)](https://github.com/SeppPenner/CollectionExtensions/network)
[![GitHub stars](https://img.shields.io/github/stars/SeppPenner/CollectionExtensions.svg)](https://github.com/SeppPenner/CollectionExtensions/stargazers)
[![GitHub license](https://img.shields.io/badge/license-AGPL-blue.svg)](https://raw.githubusercontent.com/SeppPenner/CollectionExtensions/master/License.txt)
[![Known Vulnerabilities](https://snyk.io/test/github/SeppPenner/CollectionExtensions/badge.svg)](https://snyk.io/test/github/SeppPenner/CollectionExtensions)


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
            var dict1 = new Dictionary<string, string>();
            var dict2 = dict1.Clone();
            dict2.Add("1", "1");
            PrintDictionaryToConsole(dict1);
            PrintDictionaryToConsole(dict2);
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
            var observableCollection1 = new ObservableCollection<string>();
            var observableCollection2 = observableCollection1.Clone();
            observableCollection2.Add("Abc");
            PrintObservableCollectionToConsole(observableCollection1);
            PrintObservableCollectionToConsole(observableCollection2);
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
            var list1 = new List<string>();
            var list2 = list1.Clone();
            list2.Add("Abc");
            PrintListToConsole(list1);
            PrintListToConsole(list2);
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

An example project therefore can be found [here](https://github.com/SeppPenner/CollectionExtensions/blob/master/ExampleUsage/Program.cs).

Change history
--------------

* **Version 1.0.0.2 (2019-05-06)** : Updated .Net version to 4.8.
* **Version 1.0.0.1 (2017-05-01)** : Added cloning option.
* **Version 1.0.0.0 (2017-03-11)** : 1.0 release.
