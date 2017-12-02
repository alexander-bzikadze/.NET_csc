using System.IO;
using NUnit.Framework;

namespace Mini_Roguelike.Tests
{
    [TestFixture]
    public class CharGameMapReaderTests
    {
        [Test]
        public void NoFailWhenNotFoundWhenConstructor()
        {
            // ReSharper disable once ObjectCreationAsStatement
            // The result not neaded, only that does not fails
            Assert.DoesNotThrow(() => 
                new CharGameMapReader(FileFromTestsReader.GetFile("CharGameMapReaderFailWhenNotFoundTest.txt")));
        }
        
        [Test]
        public void FailWhenNotFoundWhenRead()
        {
            Assert.Throws<FileNotFoundException>(() => 
                new CharGameMapReader(
                    FileFromTestsReader.GetFile("CharGameMapReaderFailWhenNotFoundTest.txt")).GetMap());
        }

        [Test]
        public void ReadSuccessEmpty()
        {
            Assert.NotNull(new CharGameMapReader(
                FileFromTestsReader.GetFile("CharGameMapReaderEmptyTest.txt")).GetMap());
        }

        [Test]
        public void ReadSuccessRandom()
        {
            Assert.NotNull(new CharGameMapReader(
                FileFromTestsReader.GetFile("CharGameMapReaderRandomTest.txt")).GetMap());
        }

        [Test]
        public void ReadCorrectRandom()
        {
            var gameMap = new CharGameMapReader(
                FileFromTestsReader.GetFile("CharGameMapReaderRandomTest.txt")).GetMap();
            for (var i = 0; i < 3; ++i)
            {
                for (var j = 0; j < 3; ++j)
                {
                    if (i == 1 && j == 1)
                    {
                        Assert.IsTrue(gameMap.CanGo(i, j));
                    }
                    else
                    {
                        Assert.IsFalse(gameMap.CanGo(i, j));
                    }
                }
            }
        }
    }
}