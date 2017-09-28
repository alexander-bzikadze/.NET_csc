using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using MyNUnit.Framework;
using AssertionException = MyNUnit.Framework.AssertionException;
using Test = MyNUnit.Framework.Test;

namespace MyNUnit 
{
    public class TestRunner
    {
        public TestRunner(string path)
        {
            TestTypes = Directory.GetFiles(path, "*.dll")
                .Select(Assembly.LoadFile)
                .SelectMany(dll => dll.GetTypes())
                .Where(type => type.GetMethods()
                    .Select(method => method.GetCustomAttributes(typeof(Test), true).Length > 0)
                    .Aggregate(true, (x,y) => x || y));
        }

        public IEnumerable<string> RunTests() =>
            TestTypes.Select(type =>
            {
                var obj = type.GetTypeInfo().DeclaredConstructors.First().Invoke(new object[0]);
                InvokeIfCan(type, obj, typeof(BeforeClass));
                var testResults = type
                    .GetMethods()
                    .Where(x => x.GetCustomAttributes(typeof(Test), true).Length > 0)
                    .Select(testMethod => RunSingleTest(type, obj, testMethod));
                InvokeIfCan(type, obj, typeof(AfterClass));
                return testResults;
            }).SelectMany(x => x);

        private static string RunSingleTest(Type type, object obj, MethodBase testMethod)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = AddRecord("Running ", testMethod.Name);
            var attribute = (Test)testMethod.GetCustomAttributes(typeof(Test), true).First();

            if (attribute.Ignore.Equals(""))
            {
                InvokeIfCan(type, obj, typeof(Before));

                try
                {
                    testMethod.Invoke(obj, new object[0]);
                    if (attribute.Expected != null)
                        result += AddRecord("Run failed: did not catch ", attribute.Expected.Name);
                    else
                        result += AddRecord("Test successfully finished");
                }
                catch (Exception exc)
                {
                    Debug.Assert(exc.InnerException != null, "exc.InnerException != null");
                    if (exc.InnerException.GetType().Equals(attribute.Expected))
                    {
                        // ReSharper disable once PossibleNullReferenceException
                        // If type equals Expected, expected in not null. exc.GetType() is not null anyway.
                        result += AddRecord("Did catch expected ", attribute.Expected.Name);
                    }
                    else if (exc.InnerException.GetType().Equals(typeof(AssertionException)))
                        result += AddRecord("Run failed: ", exc.InnerException.Message);
                    else
                        result += AddRecord("Unknown exception of type ", exc.InnerException.GetType().Name, ": ",
                            exc.InnerException.Message);
                }

                InvokeIfCan(type, obj, typeof(After));
            }
            else
                result += AddRecord("Ignoring test: ", attribute.Ignore);

            stopwatch.Stop();
            result += AddRecord("Finished in ", stopwatch.Elapsed.TotalSeconds.ToString(CultureInfo.InvariantCulture));
            return result;
        }

        private static string AddRecord(params string[] messages) => 
            string.Concat(string.Concat(messages) , ". ");

            
        private static void InvokeIfCan(Type cl, object instance,Type attr) =>
            cl.GetMethods().Where(x => x.GetCustomAttributes(attr, true).Length > 0)
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                // Is there any smarter way? Cause here we do not use the return value.
                .Select(method => method.Invoke(instance, new object[0]));

        public IEnumerable<Type> TestTypes { get; }
    }
}