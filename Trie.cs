using DataStrucures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPortfolio
{
    internal class Trie
    {
        /**
         * Private class for implementing the Trie's nodes
         */
        private class TrieNode
        {
            public bool IsWord;
            public Dictionary<char, TrieNode> Children;

            public TrieNode()
            {
                IsWord = false;
                Children = new Dictionary<char, TrieNode>();
            }
        }

        private TrieNode root;
        /**
         * Constructor for a Trie using Utils.PasswordWordList()
         */
        public Trie()
        {
            root = new TrieNode();

            IEnumerable<string> passwordList = Utils.PasswordWordlist();
            foreach(var pass in passwordList)
            {
                Add(pass);
            }
        }
        /**
         * Method that adds words into Trie
         */
        public void Add(string word)
        {
            TrieNode node = root;
            foreach (char c in word)
            {
                if (!node.Children.ContainsKey(c))
                    node.Children[c] = new TrieNode();

                node = node.Children[c];
            }

            node.IsWord = true;
        }
        /**
         * Method that removes words from the Trie
         */
        public string Remove(string word)
        {
            TrieNode node = root;
            TrieNode lastWordNode = null;
            char lastChar = '\0';

            foreach (char c in word)
            {
                if (node.Children.ContainsKey(c))
                {
                    if (node.Children.Count > 1 || node.IsWord)
                    {
                        lastWordNode = node;
                        lastChar = c;
                    }
                    node = node.Children[c];
                }
                else
                {
                    return word;
                }
            }

            if (node.Children.Count > 0)
            {
                node.IsWord = false;
                return word;
            }

            if (lastWordNode != null)
            {
                lastWordNode.Children.Remove(lastChar);
                return word;
            }

            root.Children.Remove(word[0]);
            return word;
        }
        /**
         * Method that checks whether a word is in the Trie
         */
        public bool Has(string word)
        {
            TrieNode node = HasNode(word);
            return node != null && node.IsWord;
        }
        /**
         * Checks to see if prefix of word is in the Trie
         */
        public bool StartsWith(string prefix)
        {
            return HasNode(prefix) != null;
        }
        /**
         * Recursive Helper Method for Has(string word) to iterate through nodes
         */
        private TrieNode HasNode(string str)
        {
            TrieNode node = root;
            foreach (char c in str)
            {
                if (node.Children.ContainsKey(c))
                    node = node.Children[c];
                else
                    return null;
            }

            return node;
        }
    }

}
