using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Item.cs
 * Last modified: April 30, 2013
 * 
 * Creates and stores items. Items may have dependencies on other named items
 * 
 * 
 */

namespace tpchallenge
{
    class Item
    {
        public string Name { get; set; }
        public string[] Dependency { get; set; }

        // Accounting for unnamed Items
        public Item() 
        {
            Name = "";
        }
    }  
}
