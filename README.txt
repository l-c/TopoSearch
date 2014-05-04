Challenge Question
======================================================================================

We have a number of items we want to place in order.
Each item can fall into one of four categories:
   - unnamed without dependencies
   - unnamed with dependencies
   - named without dependencies
   - named with dependencies
 
If an item is named other items that have dependencies can depend on it by name
 
Write a framework for defining items and a function that takes items on a given type
and return them in an order such that items with dependencies come later in the order
than the item or items they depend on.

======================================================================================

Solution Location: /TopoSearch

Execution: Main method is located in ItemSortTest.cs

Usage:

 * 1. Create an object type ItemList [ItemList.cs]. Populate Itemlist with Item objects [Item.cs] using ItemList.Add
 * 2. Run Sort on ItemList to obtain a List of integers corresponding to the correct order of indexes of ItemList
 
*note. Names are case sensitive. Error will be thrown if a dependency is create on a non-existant node

The test program will:

 * 1. Create an ItemList
 * 2. Populate with Items 
 * 3. Run the sort on the ItemList > receiving a List of indexes in correct order
 * 4. Loop over the ItemList with the supplied index, retrieving Item objects in correct order using ItemList.GetItem
 * 5. Print Item name's and dependencies in topological order

