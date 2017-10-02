using NUnit.Framework;

namespace Trie.Tests
{   
    [TestFixture]
    public class TrieTest
    {
        private Trie _trie;

        [SetUp]
        public void TrieTestSetUp()
        {
            _trie = new Trie();
        }

        [Test]
        public void AddEmpty()
        {
            Assert.IsTrue(_trie.Add(""));
            Assert.IsTrue(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            Assert.IsFalse(_trie.Contains("12"));
            
            Assert.AreEqual(_trie.Size(), 1);
        }

        [Test]
        public void AddSingleChar()
        {
            Assert.IsTrue(_trie.Add("1"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsTrue(_trie.Contains("1"));
            Assert.IsFalse(_trie.Contains("12"));
            
            Assert.AreEqual(_trie.Size(), 1);
        }

        [Test]
        public void AddTwoCharString()
        {
            Assert.IsTrue(_trie.Add("12"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            Assert.IsTrue(_trie.Contains("12"));
            
            Assert.AreEqual(_trie.Size(), 1);
        }

        [Test]
        public void AddEmptyWithPrefixAssert()
        {
            Assert.IsTrue(_trie.Add(""));
            Assert.IsTrue(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            Assert.IsFalse(_trie.Contains("12"));
            
            Assert.AreEqual(_trie.Size(), 1);
            
            Assert.AreEqual(_trie.HowManyStartsWithPrefix(""), 1);
            Assert.AreEqual(_trie.HowManyStartsWithPrefix("1"), 0);
            Assert.AreEqual(_trie.HowManyStartsWithPrefix("12"), 0);
        }

        [Test]
        public void AddSingleCharWithPrefixAssert()
        {
            Assert.IsTrue(_trie.Add("1"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsTrue(_trie.Contains("1"));
            Assert.IsFalse(_trie.Contains("12"));
            
            Assert.AreEqual(_trie.Size(), 1);
            
            Assert.AreEqual(_trie.HowManyStartsWithPrefix(""), 1);
            Assert.AreEqual(_trie.HowManyStartsWithPrefix("1"), 1);
            Assert.AreEqual(_trie.HowManyStartsWithPrefix("12"), 0);
        }

        [Test]
        public void AddTwoCharStringWithPrefixAssert()
        {
            Assert.IsTrue(_trie.Add("12"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            Assert.IsTrue(_trie.Contains("12"));
            
            Assert.AreEqual(_trie.Size(), 1);
            
            Assert.AreEqual(_trie.HowManyStartsWithPrefix(""), 1);
            Assert.AreEqual(_trie.HowManyStartsWithPrefix("1"), 1);
            Assert.AreEqual(_trie.HowManyStartsWithPrefix("12"), 1);
        }

        [Test]
        public void AddTwoStringWithOnePrefix()
        {
            Assert.IsTrue(_trie.Add("11"));
            Assert.IsTrue(_trie.Add("12"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            Assert.IsTrue(_trie.Contains("11"));
            Assert.IsTrue(_trie.Contains("12"));

            Assert.AreEqual(_trie.Size(), 2);
            
            Assert.AreEqual(_trie.HowManyStartsWithPrefix(""), 2);
            Assert.AreEqual(_trie.HowManyStartsWithPrefix("1"), 2);
            Assert.AreEqual(_trie.HowManyStartsWithPrefix("12"), 1);
            Assert.AreEqual(_trie.HowManyStartsWithPrefix("11"), 1);
        }

        [Test]
        public void DoubleAddOneString()
        {
            Assert.IsTrue(_trie.Add("12"));
            Assert.IsFalse(_trie.Add("12"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            Assert.IsTrue(_trie.Contains("12"));
            
            Assert.AreEqual(_trie.Size(), 1);
            
            Assert.AreEqual(_trie.HowManyStartsWithPrefix(""), 1);
            Assert.AreEqual(_trie.HowManyStartsWithPrefix("1"), 1);
            Assert.AreEqual(_trie.HowManyStartsWithPrefix("12"), 1);
        }

        [Test]
        public void AddStringAndItsPrefix()
        {
            Assert.IsTrue(_trie.Add("12"));
            Assert.IsTrue(_trie.Add("1"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsTrue(_trie.Contains("1"));
            Assert.IsTrue(_trie.Contains("12"));

            Assert.AreEqual(_trie.Size(), 2);
            
            Assert.AreEqual(_trie.HowManyStartsWithPrefix(""), 2);
            Assert.AreEqual(_trie.HowManyStartsWithPrefix("1"), 2);
            Assert.AreEqual(_trie.HowManyStartsWithPrefix("12"), 1);
        }

        [Test]
        public void DoesNotContainAnyTrash()
        {
            Assert.IsTrue(_trie.Add("11"));
            Assert.IsTrue(_trie.Add("12"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            
            Assert.IsFalse(_trie.Contains("123"));
            Assert.IsFalse(_trie.Contains("481892481"));
            Assert.IsFalse(_trie.Contains("112"));
            Assert.IsFalse(_trie.Contains("as"));
        }

        [Test]
        public void AddEmptyAndRemove()
        {
            Assert.IsTrue(_trie.Add(""));
            Assert.IsTrue(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            Assert.IsFalse(_trie.Contains("12"));
            
            Assert.AreEqual(_trie.Size(), 1);
//            
            Assert.IsTrue(_trie.Remove(""));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            Assert.IsFalse(_trie.Contains("12"));
//            
            Assert.AreEqual(_trie.Size(), 0);
        }

        [Test]
        public void AddSingleCharAndRemove()
        {
            Assert.IsTrue(_trie.Add("1"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsTrue(_trie.Contains("1"));
            Assert.IsFalse(_trie.Contains("12"));
            
            Assert.AreEqual(_trie.Size(), 1);
            
            Assert.IsTrue(_trie.Remove("1"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            Assert.IsFalse(_trie.Contains("12"));
            
            Assert.AreEqual(_trie.Size(), 0);
        }

        [Test]
        public void AddTwoCharStringAndRemove()
        {
            Assert.IsTrue(_trie.Add("12"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            Assert.IsTrue(_trie.Contains("12"));
            
            Assert.AreEqual(_trie.Size(), 1);
            
            Assert.IsTrue(_trie.Remove("12"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            Assert.IsFalse(_trie.Contains("12"));
            
            Assert.AreEqual(_trie.Size(), 0);
        }

        [Test]
        public void AddTwoStringWithOnePrefixAndRemove()
        {
            Assert.IsTrue(_trie.Add("11"));
            Assert.IsTrue(_trie.Add("12"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            Assert.IsTrue(_trie.Contains("11"));
            Assert.IsTrue(_trie.Contains("12"));

            Assert.AreEqual(_trie.Size(), 2);
            
            Assert.IsTrue(_trie.Remove("11"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            Assert.IsFalse(_trie.Contains("11"));
            Assert.IsTrue(_trie.Contains("12"));
            Assert.AreEqual(_trie.Size(), 1);
            
            Assert.IsTrue(_trie.Remove("12"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            Assert.IsFalse(_trie.Contains("11"));
            Assert.IsFalse(_trie.Contains("12"));
            Assert.AreEqual(_trie.Size(), 0);   
        }

        [Test]
        public void DoesNotRemoveWhatIsNotAdded()
        {
            Assert.IsTrue(_trie.Add("11"));
            Assert.IsTrue(_trie.Add("12"));
            Assert.IsFalse(_trie.Contains(""));
            Assert.IsFalse(_trie.Contains("1"));
            
            Assert.IsFalse(_trie.Remove("123"));
            Assert.IsFalse(_trie.Remove("481892481"));
            Assert.IsFalse(_trie.Remove("112"));
            Assert.IsFalse(_trie.Remove("as"));
        }
    }
}