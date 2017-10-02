using System.Collections.Generic;
using System.Diagnostics;

namespace Trie
{
    public class Trie
    {
        /// Expected complexity: O(|element|)
        /// Returns true if this set has not already contained the specified element
        public bool Add(string element) 
        { 
            if (Contains(element)) 
            {
                return false;
            }
            var node = _root;
            foreach (var c in element) 
            {
                if (!node.DictionaryFromCharToNextNode.ContainsKey(c)) 
                {
                    node.DictionaryFromCharToNextNode.Add(c, new Node());
                }
                node.HowManyPassHere++;
                node = node.DictionaryFromCharToNextNode[c];
            }
            node.HowManyPassHere++;
            node.HowManyEndHere++;
            return true;
        }

        /// Expected complexity: O(|element|)
        public bool Contains(string element) 
        { 
            var node = _root;
            foreach (var c in element) 
            {
                if (!node.DictionaryFromCharToNextNode.ContainsKey(c)) 
                {
                    return false;
                }
                node = node.DictionaryFromCharToNextNode[c];
            }
            return node.HowManyEndHere > 0;
        }

        /// Expected complexity: O(|element|)
        /// Returns true if this set contained the specified element
        public bool Remove(string element)  
        {
            if (!Contains(element)) {
                return false;
            }
            var node = _root;
            foreach (var c in element) {
                node.HowManyPassHere--;
                if (node.DictionaryFromCharToNextNode[c].HowManyPassHere < 2) {
                    node.DictionaryFromCharToNextNode.Remove(c);
                    return true;
                }
                node = node.DictionaryFromCharToNextNode[c];
            }
            node.HowManyPassHere--;
            node.HowManyEndHere--;
            Debug.Assert(node.HowManyEndHere >= 0);
            return true;
        }

        /// Expected complexity: O(1)
        public int Size()  
        { 
            return _root.HowManyPassHere;
        }

        /// Expected complexity: O(|prefix|)
        public int HowManyStartsWithPrefix(string prefix)  
        { 
            var node = _root;
            foreach (var c in prefix) 
            {
                if (!node.DictionaryFromCharToNextNode.ContainsKey(c)) 
                {
                    return 0;
                }
                node = node.DictionaryFromCharToNextNode[c];
            }
            return node.HowManyPassHere;
        }

        private class Node 
        {
            public Dictionary<char, Node> DictionaryFromCharToNextNode { get; } = new Dictionary<char, Node>();
            public int HowManyPassHere { get; set; }
            public int HowManyEndHere { get; set; }
        }

        private readonly Node _root = new Node();
    }
}