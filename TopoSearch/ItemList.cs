using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * ItemList.cs
 * Last modified: July 12, 2013
 * 
 * Create a list of Items, containing methods to get list details. 
 * Contains sort() which indexes to a List of integers, and passes the values 
 * to ItemSort.cs
 * 
 */

namespace tpchallenge
{
    class ItemList
    {
        private List<Item> _items = new List<Item>();

        public void AddItem(Item i) { _items.Add(i); }
        public void RemoveItem(Item i) { _items.Remove(i); }
        public List<Item> GetAll() { return _items; }
        public Item GetItem(int i) { return _items[i]; }
        public int GetLength() { return _items.Count; }

        public List<int> Sort()
        {
            // Create ItemSort Object: results
            ItemSort results = new ItemSort(_items.Count);
            Dictionary<string, int> index = new Dictionary<string, int>();

            // Load all nodes from ItemList into results -- receive and store node location in index dictionary for later reference
            for (int i = 0; i < _items.Count; i++)
            {
                index[_items[i].Name] = results.AddNode(i);
            }

            // Add dependencies to results, referencing the stored node location from index
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Dependency != null)
                {
                    for (int j = 0; j < _items[i].Dependency.Length; j++)
                    {
                        results.AddEdge(i, index[_items[i].Dependency[j]]);
                    }
                }
            }
            // TSort returns a list of integers coresponding to the correct sorted order of ItemList
            return results.TSort();
        }
    }
}
