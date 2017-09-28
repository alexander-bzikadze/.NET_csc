using System;
using MyNUnit.Framework;
using System.IO;

namespace NoBeforeAfter {
	public class CL {
		[Before]
		public void before() {
		}
		[After]
		public void After() {
		}
		[Test]
		public void Succ1() {
		}
		[Test]
		public void Succ2() {
		}
		[Test]
		public void Succ3() {
		}
		[Test(Ignore="Just because we can")]
		public void Ignore1() {
		}
		[Test(Ignore="Just because we can")]
		public void Ignore2() {
		}
		[Test(Ignore="Just because we can")]
		public void Ignore3() {
		}
		[Test(Expected=typeof(AssertionException))]
		public void ShoudlFail1() {
			throw new AssertionException("Just because we can");
		}
		[Test(Expected=typeof(AssertionException))]
		public void ShouldFail2() {
			throw new AssertionException("Just because we can");
		}
		[Test(Expected=typeof(AssertionException))]
		public void ShouldFail3() {
			throw new AssertionException("Just because we can");
		}
		[Test]
		public void ShoudlNotFail1() {
			throw new AssertionException("Just because we can");
		}
		[Test]
		public void ShouldNotFail2() {
			throw new AssertionException("Just because we can");
		}
		[Test]
		public void ShouldNotFail3() {
			throw new AssertionException("Just because we can");
		}
		public void ShouldNotBeRun() {
		}
	}
}