using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * ItemSort.cs
 * Last modified: July 12, 2013
 * 
 * Creates ItemSort Object. Functions for adding node, deleting node, dependency check
 * Uses a topological sort algorithm to determine correct ordering. Dependencies conceptualized with 2D Array
 * 
 * Pseudo Code:
 * 
 *       L ← Empty list that will contain the sorted elements
 *       S ← Set of all nodes with no incoming edges
 *       while S is non-empty do
 *          remove a node n from S
 *           insert n into L
 *           for each node m with an edge e from n to m do
 *               remove edge e from the graph
 *               if m has no other incoming edges then
 *                   insert m into S
 *       if graph has edges then
 *           return error (graph has at least one cycle)
 *       else 
 *           return L (a topologically sorted order)
 *           
 * 
 * 
 */

namespace tpchallenge
{
    class ItemSort
    {
        private int[] _nodes;
        private int[,] _edges; // 2D array to map dependencies. Initialize all values to 0 in constructor.
        private int _nodeCount;
        private List<int> _sortedList = new List<int>();

        public ItemSort(int size)
        {
            _nodes = new int[size];
            _edges = new int[size, size];
            _nodeCount = 0;
        }

        // Add node and returns location as integer
        public int AddNode(int node)
        {
            _nodes[_nodeCount] = node;
            _nodeCount++;
            return _nodeCount - 1;
        }

        // Removes node by setting to -1 (DependencyCheck() ignores -1 valued nodes) and all connected edges from matrix. 
        private void DeleteNode(int delNode)
        {
            _nodes[delNode] = -1;

            // Clear all dependencies to deleted node
            for (int val = 0; val < _nodes.Length; val++)
            {
                _edges[delNode, val] = 0;
                _edges[val, delNode] = 0;
            }
        }

        // Add dependency to matrix, 1 indicates an edge, 0 indicates no edge
        public void AddEdge(int start, int end)
        {
            _edges[start, end] = 1;
        }

        // Return a topologically sorted list of integers
        public List<int> TSort()
        {
            // Repeat until sorted list contains all nodes (indicating sort completion)
            while (_sortedList.Count != _nodes.Length)
            {
                // Search for node without depdencies
                int currentNode = DependencyCheck();
                // If none found, and list isn't complete = cyclic list
                if (currentNode == -1) throw new Exception("Dependency Cycle Detected");
                // Add node to sorted list
                _sortedList.Add(_nodes[currentNode]);
                // Delete node from nodelist and depedency matrix
                DeleteNode(currentNode);
            }
            return _sortedList;
        }

        // Get node that does not contain dependencies
        private int DependencyCheck()
        {
            // Loop through each node
            for (int tar = 0; tar < _nodes.Length; tar++)
            {
                // Check if node value is -1, which represents a deleted node. If found, increment to next node.
                for (int c = tar; c < _nodes.Length; c++)
                {
                    if (_nodes[tar] == -1)
                    {
                        tar++;
                    }
                    else break;
                }
                // Throw exception for cyclic list if all nodes have been traversed and no dependentless item found 
                if (tar > _nodes.Length - 1) return -1;

                // Traverse dependency matrix of target node, if no dependicies found, return node index
                bool isEdge = false;
                for (int chd = 0; chd < _nodes.Length; chd++)
                {
                    if (_edges[tar, chd] > 0)
                    {
                        // Dependency found > break loop and go on to next node
                        isEdge = true;
                        break;
                    }
                }
                if (!isEdge) return tar;
            }
            return -1;
        }
    }
}
