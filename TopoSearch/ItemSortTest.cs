using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* 
 * ItemSortTest.cs
 * Last modified: July 12, 2013
 * 
 * Test file.
 * 
 * Topological sort of items that may or may not be unnamed with or without dependencies.
 *
 * USAGE:
 * 
 * 1. Create an ItemList and populate with Items.
 * 
 * 2. Run Sort on ItemList to obtain a List of integers corresponding to the correct order of the ItemList
 * 
 * In this example, we print the Items to console in order, also showing dependencies for ease of testing.          
 * 
 * 
 */

namespace tpchallenge
{
    class ItemSortTest
    {
        public static void Main(string[] args)
        {

            ItemList items = new ItemList();

            // Unnammed independent item
            items.AddItem(new Item() { });
            items.AddItem(new Item()
            {
                Name = "A"
                //,Dependency = new[] { "J" }   //Uncomment for Dependency Cycle Test
            });
            items.AddItem(new Item()
            {
                Name = "J",
                Dependency = new[] { "A", "C" }
            });
            items.AddItem(new Item()
            {
                Name = "B",
                Dependency = new[] { "D", "F" }
            });
            items.AddItem(new Item()
            {
                Name = "Z",
                Dependency = new[] { "F" }
            });
            items.AddItem(new Item()
            {
                Name = "C",
                Dependency = new[] { "D" }
            });
            // Unnamed with dependency
            items.AddItem(new Item()
            {
                Dependency = new[] { "F", "D" }
            });
            items.AddItem(new Item()
            {
                Name = "D"
            });
            items.AddItem(new Item()
            {
                Name = "F"
            });
            items.AddItem(new Item()
            {
                Name = "C",
                Dependency = new[] { "F" }
            });

            // Get and Loop through all items in the ItemList, printing Items and their dependencies in brackets
            Console.WriteLine("Unsorted List:\n");
            foreach (var item in items.GetAll())
            {
                if (item.Dependency != null)
                {
                    Console.Write(item.Name + " ( ");
                    foreach (var value in item.Dependency)
                    {
                        Console.Write(value);
                    }
                    Console.WriteLine(" )");
                }
                else Console.WriteLine(item.Name);
            }

            Console.WriteLine("\nSorted List:\n");
            try
            {
                // Get sorted list order and print to screen
                List<int> sortOrder = items.Sort();

                for (int i = 0; i < sortOrder.Count; i++)
                {
                    var item = items.GetItem(sortOrder[i]);

                    if (item.Dependency != null)
                    {
                        Console.Write(item.Name + " ( ");
                        foreach (var value in item.Dependency)
                        {
                            Console.Write(value);
                        }
                        Console.WriteLine(" )");
                    }
                    else Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                // Catch cyclic dependency error
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
