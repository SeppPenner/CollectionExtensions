// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The main program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ExampleUsage
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using CollectionExtensions;

    /// <summary>
    /// The main program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main method.
        /// </summary>
        public static void Main()
        {
            TestDictionary();
            TestList();
            TestObservableCollection();
            Console.ReadKey();
        }

        /// <summary>
        /// Tests the dictionary methods.
        /// </summary>
        private static void TestDictionary()
        {
            Console.WriteLine("Dictionary Test:");
            Console.WriteLine(string.Empty);
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
            Print(dictionary.AreKeysNull());
            Print(dictionary.AreValuesNull());
            var dict1 = new Dictionary<string, string>();
            var dict2 = dict1.Clone();
            dict2.Add("1", "1");
            PrintDictionaryToConsole(dict1);
            PrintDictionaryToConsole(dict2);
        }

        /// <summary>
        /// Tests the observable enumerable methods.
        /// </summary>
        private static void TestObservableCollection()
        {
            Console.WriteLine("ObservableCollection Test:");
            Console.WriteLine(string.Empty);
            var observableCollection = new ObservableCollection<string>();
            observableCollection.AddIfNotExists("a");
            observableCollection.AddIfNotExists("a");
            observableCollection.AddIfNotExists("b");
            PrintIEnumerableToConsole(observableCollection, "ObservableCollection");
            observableCollection.DeleteIfExists("a");
            PrintIEnumerableToConsole(observableCollection, "ObservableCollection");
            observableCollection.UpdateValue("b", "c");
            PrintIEnumerableToConsole(observableCollection, "ObservableCollection");
            observableCollection.DeleteIfExists("c");
            PrintIEnumerableToConsole(observableCollection, "ObservableCollection");
            Print(observableCollection.AreValuesNull());
            var observableCollection1 = new ObservableCollection<string>();
            var observableCollection2 = observableCollection1.Clone();
            observableCollection2.Add("Abc");
            PrintIEnumerableToConsole(observableCollection1, "ObservableCollection");
            PrintIEnumerableToConsole(observableCollection2, "ObservableCollection");
        }

        /// <summary>
        /// Tests the list methods.
        /// </summary>
        private static void TestList()
        {
            Console.WriteLine("List Test:");
            Console.WriteLine(string.Empty);
            var list = new List<string>();
            list.AddIfNotExists("a");
            list.AddIfNotExists("a");
            list.AddIfNotExists("b");
            PrintIEnumerableToConsole(list, "List");
            list.DeleteIfExists("a");
            PrintIEnumerableToConsole(list, "List");
            list.UpdateValue("b", "c");
            PrintIEnumerableToConsole(list, "List");
            list.DeleteIfExists("c");
            PrintIEnumerableToConsole(list, "List");
            Print(list.AreValuesNull());
            var list1 = new List<string>();
            var list2 = list1.Clone();
            list2.Add("Abc");
            PrintIEnumerableToConsole(list1, "List");
            PrintIEnumerableToConsole(list2, "List");
        }

        /// <summary>
        /// Prints the <see cref="IEnumerable{T}"/> to the console.
        /// </summary>
        /// <param name="enumerable">The <see cref="IEnumerable{T}"/>.</param>
        /// <param name="name">The name of the <see cref="IEnumerable{T}"/>.</param>
        private static void PrintIEnumerableToConsole(IEnumerable<string> enumerable, string name)
        {
            if (enumerable == null)
            {
                Console.WriteLine($"{name} was null.");
                return;
            }

            var enumerableList = enumerable.ToList();

            if (!enumerableList.Any())
            {
                Console.WriteLine($"Empty {name}");
                return;
            }

            foreach (var value in enumerableList)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("-------------------------------------");
        }

        /// <summary>
        /// Prints the <see cref="Dictionary{TKey,TValue}"/> to the console.
        /// </summary>
        /// <param name="dictionary">The <see cref="Dictionary{TKey,TValue}"/>.</param>
        private static void PrintDictionaryToConsole(Dictionary<string, string> dictionary)
        {
            if (dictionary == null)
            {
                Console.WriteLine("Dictionary was null.");
            }
            else if (dictionary.Count == 0)
            {
                Console.WriteLine("Empty dictionary");
            }
            else
            {
                // ReSharper disable once UseDeconstruction
                foreach (var pair in dictionary)
                {
                    Console.WriteLine(pair.Key + ":" + pair.Value);
                }
            }

            Console.WriteLine("-------------------------------------");
        }

        /// <summary>
        /// Prints the last line and a value.
        /// </summary>
        /// <param name="value">The value.</param>
        private static void Print(bool value)
        {
            Console.WriteLine(value);
            Console.WriteLine("-------------------------------------");
        }
    }
}