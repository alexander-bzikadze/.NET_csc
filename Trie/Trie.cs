using System.Collections.Generic;

namespace Trie
{
    public class Trie
    {
        /// Expected complexity: O(|element|)
        /// Returns true if this set did not already contain the specified element
        public bool Add(string element)  { 
            if (Contains(element)) {
                return false;
            }
            var node = _root;
            foreach (var c in element) {
                if (!node.DictionaryFromCharToNode.ContainsKey(c)) {
                    node.DictionaryFromCharToNode.Add(c, new Node());
                }
                node.Size++;
                node = node.DictionaryFromCharToNode[c];
            }
            node.Size++;
            return true;
        }

        /// Expected complexity: O(|element|)
        public bool Contains(string element) { 
            var node = _root;
            foreach (var c in element) {
                if (!node.DictionaryFromCharToNode.ContainsKey(c)) {
                    return false;
                }
                node = node.DictionaryFromCharToNode[c];
            }
            return node.HowManyEndHere > 0;
        }

        /// Expected complexity: O(|element|)
        /// Returns true if this set contained the specified element
        public bool Remove(string element)  { 
            if (!Contains(element)) {
                return false;
            }
            var node = _root;
            foreach (var c in element) {
                node.Size--;
                if (node.DictionaryFromCharToNode[c].Size < 2) {
                    node.DictionaryFromCharToNode.Remove(c);
                    return true;
                }
                node = node.DictionaryFromCharToNode[c];
            }
            node.HowManyEndHere--;
            return true;
        }

        /// Expected complexity: O(1)
        public int Size()  { 
            return _root.Size;
        }

        /// Expected complexity: O(|prefix|)
        public int HowManyStartsWithPrefix(string prefix)  { 
            var node = _root;
            foreach (var c in prefix) {
                if (!node.DictionaryFromCharToNode.ContainsKey(c)) {
                    return 0;
                }
                node = node.DictionaryFromCharToNode[c];
            }
            return node.Size;
        }

        private class Node {
            public Node() {
                DictionaryFromCharToNode = new Dictionary<char, Node>();
                Size = 0;
                HowManyEndHere = 0;
            }
            public Dictionary<char, Node> DictionaryFromCharToNode { get; }
            public int Size { get; set; }
            public int HowManyEndHere;
        }

        private readonly Node _root = new Node();
    }
}
