using System;
using MyNUnit.Framework;
using System.IO;

namespace NoBeforeAfter 
{
	public class CL 
	{
		[Test]
		public void SuccessfulTestMethod1() 
		{
		}
		[Test]
		public void SuccessfulTestMethod2() 
		{
		}
		[Test]
		public void SuccessfulTestMethod3() 
		{
		}
		[Test(Ignore="Just because we can")]
		public void IgnoredTestMethod1() 
		{
		}
		[Test(Ignore="Just because we can")]
		public void IgnoredTestMethod2() 
		{
		}
		[Test(Ignore="Just because we can")]
		public void IgnoredTestMethod3() 
		{
		}
		[Test(Expected=typeof(AssertionException))]
		public void ExpectionExceptionTestMethod1() 
		{
			throw new AssertionException("Just because we can");
		}
		[Test(Expected=typeof(AssertionException))]
		public void ExpectionExceptionTestMethod2() 
		{
			throw new AssertionException("Just because we can");
		}
		[Test(Expected=typeof(AssertionException))]
		public void ExpectionExceptionTestMethod3() 
		{
			throw new AssertionException("Just because we can");
		}
		[Test]
		public void FailingWithAssertationTestMethod1() 
		{
			throw new AssertionException("Just because we can");
		}
		[Test]
		public void FailingWithAssertationTestMethod2() 
		{
			throw new AssertionException("Just because we can");
		}
		[Test]
		public void FailingWithAssertationTestMethod3() 
		{
			throw new AssertionException("Just because we can");
		}
		public void ShouldNeverBeRanTestMethod() 
		{
		}
	}
}