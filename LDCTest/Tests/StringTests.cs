using System;
using Xunit;
using StringProcessor;
using System.Linq;

namespace Tests
{
    public class StringTests
    {
        IStringProcessor processor;

        public StringTests()
        {
            processor = new LDCStringProcessor();
        }

        [Fact]
        public void NoNulls()
        {
            foreach (string processed in processor.Process(null))
            {
                Assert.NotNull(processed);
            }
        }

        [Fact]
        public void LengthExceeded()
        {
            foreach (string processed in processor.Process(null))
            {
                Assert.False(processed.Length > 15);
            }
        }

        [Fact]
        public void SpecialChars()
        {
            foreach (string processed in processor.Process(null))
            {
                Assert.False(processed.IndexOf('$') > -1);
                Assert.False(processed.IndexOf('_') > -1);
                Assert.False(processed.IndexOf('4') > -1);
            }
        }

        [Fact]
        public void NoDuplicates()
        {
            foreach (string processed in processor.Process(null))
            {
                if (processed.Length > 1)
                {
                    Assert.False(processed.Where((c, i) => i > 1 && processed[i - 1] == c).Any());
                }
            }
        }
    }
}
