// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DictionaryExtension.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   An extension for the <see cref="Dictionary{TKey,TValue}" /> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CollectionExtensions;

/// <summary>
/// An extension for the <see cref="Dictionary{TKey,TValue}"/> class.
/// </summary>
public static class DictionaryExtension
{
    /// <summary>
    /// Clones the dictionary.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="dictionary">The dictionary.</param>
    /// <returns>A new <see cref="Dictionary{TKey,TValue}"/>.</returns>
    public static Dictionary<TKey, TValue> Clone<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) where TKey : notnull
    {
        return dictionary.ToDictionary(val => val.Key, val => val.Value);
    }

    /// <summary>
    /// Adds a value if it doesn't exist yet.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public static void AddIfNotExists<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value) where TKey : notnull
    {
        CheckDictionaryIsNull(dictionary);

        if (!dictionary.ContainsKey(key))
        {
            dictionary.Add(key, value);
        }
    }

    /// <summary>
    /// Updates a value.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public static void Update<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value) where TKey : notnull
    {
        CheckDictionaryIsNull(dictionary);
        CheckKeyValuePairIsNull(key, value);
        dictionary[key] = value;
    }

    /// <summary>
    /// Updates a key value pair.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="pair">The key value pair.</param>
    public static void Update<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, KeyValuePair<TKey, TValue> pair) where TKey : notnull
    {
        CheckDictionaryIsNull(dictionary);
        CheckKeyValuePairIsNull(pair);
        dictionary[pair.Key] = pair.Value;
    }

    /// <summary>
    /// Deletes the key if it exists.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="key">The key.</param>
    public static void DeleteIfExistsKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) where TKey : notnull
    {
        CheckDictionaryIsNull(dictionary);

        if (dictionary.ContainsKey(key))
        {
            dictionary.Remove(key);
        }
    }

    /// <summary>
    /// Deletes a value if it exists.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="value">The value.</param>
    public static void DeleteIfExistsValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TValue value) where TKey : notnull
    {
        CheckDictionaryIsNull(dictionary);

        if (!dictionary.ContainsValue(value))
        {
            return;
        }

        var key = dictionary.GetKeyFromValue(value);

        if (key is not null)
        {
            dictionary.Remove(key);
        }
    }

    /// <summary>
    /// Checks whether all values are <c>null</c> or not.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="dictionary">The dictionary.</param>
    /// <returns><c>true</c> if all values are <c>null</c>.</returns>
    public static bool AreValuesNull<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) where TKey : notnull
    {
        CheckDictionaryIsNull(dictionary);
        return dictionary.All(x => x.Value is null);
    }

    /// <summary>
    /// Checks whether all keys are <c>null</c> or not.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="dictionary">The dictionary.</param>
    /// <returns><c>true</c> if all keys are <c>null</c>.</returns>
    public static bool AreKeysNull<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) where TKey : notnull
    {
        CheckDictionaryIsNull(dictionary);
        return dictionary.All(x => x.Key is null);
    }

    /// <summary>
    /// Gets the key for a value.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="dictionary">The dictionary.</param>
    /// <param name="value">The value.</param>
    /// <returns>The found key.</returns>
    private static TKey? GetKeyFromValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TValue value) where TKey : notnull
    {
        var keys = new List<TKey>();

        foreach (var pair in dictionary)
        {
            AddToKeysList(keys, pair, value);
        }

        CheckCountGreaterZero(keys.Count, value);
        return !keys.Any() ? default : keys.First();
    }

    /// <summary>
    /// Adds keys to the list.
    /// </summary>
    /// <typeparam name="TKey">The key value type.</typeparam>
    /// <typeparam name="TValue">The value value type.</typeparam>
    /// <param name="keys">The keys.</param>
    /// <param name="pair">The key value pair.</param>
    /// <param name="value">The value.</param>
    private static void AddToKeysList<TKey, TValue>(ICollection<TKey> keys, KeyValuePair<TKey, TValue> pair, TValue value)
    {
        if (pair.Value is null)
        {
            return;
        }

        if (pair.Value.Equals(value))
        {
            keys.Add(pair.Key);
        }
    }

    /// <summary>
    /// Checks whether the count is greater than zero.
    /// </summary>
    /// <typeparam name="TValue">The value value type.</typeparam>
    /// <param name="count">The count.</param>
    /// <param name="value">The value.</param>
    private static void CheckCountGreaterZero<TValue>(int count, TValue value)
    {
        if (count <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count));
        }

        if (count > 1)
        {
            throw new ArgumentException(nameof(value));
        }
    }

    /// <summary>
    /// Checks whether the dictionary is <c>null</c>.
    /// </summary>
    /// <typeparam name="TKey">The key value type.</typeparam>
    /// <typeparam name="TValue">The value value type.</typeparam>
    /// <param name="dictionary">The dictionary.</param>
    private static void CheckDictionaryIsNull<TKey, TValue>(this Dictionary<TKey, TValue> dictionary) where TKey : notnull
    {
        if (dictionary is null)
        {
            throw new ArgumentNullException(nameof(dictionary));
        }
    }

    /// <summary>
    /// Checks whether the value pair is <c>null</c>.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="pair">The key value pair.</param>
    private static void CheckKeyValuePairIsNull<TKey, TValue>(KeyValuePair<TKey, TValue> pair)
    {
        if (pair.Key is null || pair.Value is null)
        {
            throw new ArgumentNullException(nameof(pair));
        }
    }

    /// <summary>
    /// Checks whether the value pair is <c>null</c>.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    private static void CheckKeyValuePairIsNull<TKey, TValue>(TKey key, TValue value)
    {
        if (key is null)
        {
            throw new ArgumentNullException(nameof(key));
        }

        if (value is null)
        {
            throw new ArgumentNullException(nameof(value));
        }
    }
}
