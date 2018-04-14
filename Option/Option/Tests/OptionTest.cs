using NUnit.Framework;
using Option.Exceptions;

namespace Option.Tests
{
    [TestFixture]
    public class OptionTest
    {   
        [Test]
        public void NoneOptionTest()
        {   
            Assert.IsTrue(Option<int>.None().IsNone());
            Assert.IsFalse(Option<int>.None().IsSome());
        }
        
        [Test]
        public void NoneValueExceptionOptionTest()
        {   
            Assert.IsTrue(Option<int>.None().IsNone());
            Assert.IsFalse(Option<int>.None().IsSome());
            Assert.Throws<UnBoxNoneOptionException>(
                () => Option<int>.None().Value());
        }
        
        [Test]
        public void SomeValueTypeOptionTest()
        {   
            Assert.IsTrue(Option<int>.Some(1).IsSome());
            Assert.AreEqual(Option<int>.Some(1).Value(), 1);
            Assert.IsFalse(Option<int>.Some(1).IsNone());
        }
        
        [Test]
        public void SomeReferenceTypeOptionTest()
        {   
            Assert.IsTrue(Option<string>.Some("1").IsSome());
            Assert.AreEqual(Option<string>.Some("1").Value(), "1");
            Assert.IsFalse(Option<string>.Some("1").IsNone());
        }

        [Test]
        public void MapSomeOptionTest()
        {
            Assert.IsTrue(Option<int>.Some(1).Map(x => x * 2).IsSome());
            Assert.IsFalse(Option<int>.Some(1).Map(x => x * 2).IsNone());
            Assert.AreEqual(Option<int>.Some(1).Map(x => x * 2).Value(), 2);
        }

        [Test]
        public void MapNoneOptionTest()
        {
            Assert.IsFalse(Option<int>.None().Map(x => x * 2).IsSome());
            Assert.IsTrue(Option<int>.None().Map(x => x * 2).IsNone());
        }

        [Test]
        public void FlattenNoneOptionTest()
        {
            Assert.IsTrue(Option<int>.Flatten(Option<Option<int>>.None()).IsNone());
        }

        [Test]
        public void FlattenSomeNoneOptionTest()
        {
            Assert.IsTrue(Option<int>.Flatten(Option<Option<int>>.Some(Option<int>.None())).IsNone());
        }

        [Test]
        public void FlattenSomeSomeOptionTest()
        {
            Assert.IsTrue(Option<int>.Flatten(Option<Option<int>>.Some(Option<int>.Some(1))).IsSome());
            Assert.AreEqual(Option<int>.Flatten(Option<Option<int>>.Some(Option<int>.Some(1))).Value(), 1);
        }
        
        [Test]
        public void NoneEqualsNoneTest()
        {
            Assert.AreEqual(Option<int>.None(), Option<int>.None());
        }

        [Test]
        public void SomeEqualsSomeTest()
        {
            Assert.IsTrue(Option<int>.Some(2).Map(x => x * 2) == Option<int>.Some(4));
        }
    }
}