using System;
using System.Linq;
using Xunit;

namespace AdvancedMVC2.Tests
{
    internal class MyTestAttribute : Attribute
    {
        public MyTestAttribute()
        {
            Value = -1;
        }

        public int Value { get; set; }
    }

    [MyTest]
    public class AttributeLifeCycleTest
    {
        public AttributeLifeCycleTest()
        {
            var attr = GetAttribute();
            attr.Value = 2;
        }

        private MyTestAttribute GetAttribute()
        {
            return GetType().GetCustomAttributes(typeof (MyTestAttribute), false).Cast<MyTestAttribute>().First();
        }

        [Fact]
        public void ValueShouldBeMinusOne()
        {
            var attr = GetAttribute();
            Assert.Equal(-1,attr.Value);
        }

        public void FooMethod()
        {
            
        }
    }
}