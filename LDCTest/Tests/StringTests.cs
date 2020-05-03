using System;
using System.Collections.Generic;
using Xunit;
using StringProcessor;
using System.Linq;

namespace Tests
{
    public class StringTests
    {
        IStringProcessor processor;
        List<string> testStrings;
        const int MAX_STRING_LENGTH = 15;
        const string GENERATOR_CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!\"£$%^&*()_+'#@~";
        private readonly char[] SPECIAL_CHARS = new char[] { '$', '_', '4' };

        public StringTests()
        {
            // set up some test strings for use across the tests
            testStrings = new List<string>();
            testStrings.Add("AAAc91%cWwWkLq$1ci3_848v3d__K");

            // include some randomly-created strings of varying lengths
            // NOTE: Using randomly-generated strings has benefits and disadvantages. One benefit is we can
            // quickly set up many strings with complex sequences. A downside could be that we can't be totally
            // sure what our tests are going to contain, so maybe a specific string sequence could cause a test
            // failure, and we won't see it on every test. However, I think this is something where you would
            // keep this in mind and look to improve the test over time.
            for (int i = 1; i < 50; i++)
            {
                testStrings.Add(RandomString(i, GENERATOR_CHARS));
                testStrings.Add(RandomString(i, GENERATOR_CHARS));
            }

            // Add an empty string and a null so we test these as well
            testStrings.Add("");
            testStrings.Add(null);

            processor = new LDCStringProcessor();
        }

        /// <summary>
        /// Run some hard-coded tests where we supply a collection of strings and expect a specific output.
        /// </summary>
        [Fact]
        public void Hardcoded()
        {
            List<string> tStrings = new List<string>();
            List<string> correctStrings = new List<string>();

            tStrings.Add("AA");
            correctStrings.Add("A");

            tStrings.Add("AAA");
            correctStrings.Add("A");

            tStrings.Add("AAAc91%cWwWkLq$1ci3_848v3d__K");
            correctStrings.Add("Ac91%cWwWkLq£1c");

            tStrings.Add("$$$$$");
            correctStrings.Add("£");

            // The next two strings shouldn't return anything, as the characters should be removed.
            tStrings.Add("444");
            tStrings.Add("___");

            List<String> processedStrings = processor.Process(tStrings);

            Assert.True(processedStrings.SequenceEqual(correctStrings), "Returned strings are not as expected:\r\n" + string.Join("\r\n", processedStrings));
        }

        /// <summary>
        /// Make sure that no nulls are returned in the processed collection of strings.
        /// </summary>
        [Fact]
        public void NoNulls()
        {
            foreach (string processed in processor.Process(testStrings))
            {
                Assert.NotNull(processed);
            }
        }

        /// <summary>
        /// Make sure that no returned strings exceed the maximum string length.
        /// </summary>
        [Fact]
        public void LengthExceeded()
        {
            foreach (string processed in processor.Process(testStrings))
            {
                Assert.False(processed.Length > MAX_STRING_LENGTH);
            }
        }

        /// <summary>
        /// Make sure the returned strings contain no special characters.
        /// </summary>
        [Fact]
        public void SpecialChars()
        {
            foreach (string processed in processor.Process(testStrings))
            {
                Assert.False(processed.IndexOf('$') > -1);
                Assert.False(processed.IndexOf('_') > -1);
                Assert.False(processed.IndexOf('4') > -1);
            }
        }

        /// <summary>
        /// Make sure the returned strings contain no duplicate sequences of characters.
        /// </summary>
        [Fact]
        public void NoDuplicates()
        {
            foreach (string processed in processor.Process(testStrings))
            {
                if (processed.Length > 1)
                {
                    Assert.False(processed.Where((c, i) => i > 1 && processed[i - 1] == c).Any(), "'" + processed + "' contains duplicate characters.");
                }
            }
        }

        /// <summary>
        /// A random-character generator for any length of string, using a pre-determined list of allowed characters.
        /// </summary>
        /// <param name="length">The length of string that should be returned.</param>
        /// <returns>A string containing randomly-generated characters.</returns>
        private string RandomString(int length, string allowedChars)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(allowedChars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
