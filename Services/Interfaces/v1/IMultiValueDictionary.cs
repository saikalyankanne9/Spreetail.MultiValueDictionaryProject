using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Spreetail.MultiValueDictionary.Services.Interfaces.v1
{
    /// <summary>
    /// Generic Multi-Value dictionary interface 
    /// Contains all interface methods to perform basic dictionary operations
    /// </summary>
    public interface IMultiValueDictionary<Tkey, TValue>
    {
        /// <summary>
        /// Adds the specified key and val to the dictionary.
        /// </summary>
        bool Add(Tkey key, TValue val);

        /// <summary>
        /// Removes the val with the specified key from the dictionary.
        /// </summary>
        void Remove(Tkey key, TValue val);

        /// <summary>
        /// Checks whether the val exists within a key.
        /// </summary>
        /// <returns>
        /// true if the val is successfully found within the key; otherwise, false. 
        /// </returns>
        bool CheckValueExists(Tkey key, TValue val);

        /// <summary>
        /// Gets the collection of string of values for the given key.
        /// </summary>
        /// <returns>
        /// List of string if given key exists; Otherwise, an error.
        /// </returns>
        List<TValue> GetMembers(Tkey key);

        /// <summary>
        /// Removes all the values of the specified key from the dictionary.
        /// </summary>
        void RemoveAll(Tkey key);

        /// <summary>
        /// Checks whether the key exists within the dictionary.
        /// </summary>
        /// <returns>
        /// true if the key is successfully found; otherwise, false. 
        /// </returns>
        bool CheckKeyExists(Tkey key);

        /// <summary>
        /// Removes all keys and values from the dictionary.
        /// </summary>
        void Clear();

        /// <summary>
        /// Gets all the keys into a new list.
        /// </summary>
        /// <returns>
        /// List of strings with all keys available in the dictionary.
        /// </returns>
        List<Tkey> GetKeys();

        /// <summary>
        /// Gets the collection of strings with values of all the keys in the dictionary.
        /// </summary>
        /// <returns>
        /// List of string of values of all the keys in the dictionary.
        /// </returns>
        List<TValue> GetAllMembers();

        /// <summary>
        /// Gets all the keys and  values in the dictionary
        /// </summary>
        /// <returns>
        /// A new reference to the dictionary
        /// </returns>
        Dictionary<Tkey, List<TValue>> GetItems();
    }
}
