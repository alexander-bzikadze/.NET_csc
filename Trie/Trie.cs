using System;
using System.Collections.Generic;

namespace Trie
{
    public class Trie
    {
        public Trie() {}

        /// Expected complexity: O(|element|)
        /// Returns true if this set did not already contain the specified element
        public bool Add(string element)  { 
            if (Contains(element)) {
                return false;
            }
            var node = root;
            foreach (var c in element) {
                if (!node.Map.ContainsKey(c)) {
                    node.Map.Add(c, new Node());
                }
                node.Size += 1;
                node = node.Map[c];
            }
            node.Size += 1;
            return true;
        }

        /// Expected complexity: O(|element|)
        public bool Contains(string element)  { 
            var node = root;
            foreach (var c in element) {
                if (!node.Map.ContainsKey(c)) {
                    return false;
                }
                node = node.Map[c];
            }
            return true;
        }

        /// Expected complexity: O(|element|)
        /// Returns true if this set contained the specified element
        public bool Remove(string element)  { 
            if (!Contains(element)) {
                return false;
            }
            var node = root;
            foreach (var c in element) {
                node.Size -= 1;
                if (node.Map[c].Size < 2) {
                    node.Map.Remove(c);
                    break;
                }
                node = node.Map[c];
            }
            return true;
        }

        /// Expected complexity: O(1)
        public int Size()  { 
            return root.Size;
        }

        /// Expected complexity: O(|prefix|)
        public int HowManyStartsWithPrefix(string prefix)  { 
            var node = root;
            foreach (var c in prefix) {
                if (!node.Map.ContainsKey(c)) {
                    return 0;
                }
                node = node.Map[c];
            }
            return node.Size;
        }

        private class Node {
            public Node() {
                this.Map = new Dictionary<char, Node>();
                this.Size = 0;
            }
            public Dictionary<char, Node> Map { get; }
            public int Size { get; set; }
        }

        private Node root = new Node();
    }
}
