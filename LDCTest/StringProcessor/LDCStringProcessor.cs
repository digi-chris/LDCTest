using System;
using System.Collections.Generic;
using System.Text;

namespace StringProcessor
{
    public class LDCStringProcessor : IStringProcessor
    {
        const int MAX_STRING_LENGTH = 15;

        public List<string> Process(List<string> stringCollection)
        {
            List<string> processedStrings = new List<string>();

            // Run through the list of strings for processing
            foreach (string item in stringCollection)
            {
                if (item != null)
                {
                    // run through each char in each individual string

                    // NOTE: I feel like this is a simplistic approach that probably doesn't reflect how I would
                    // usually code in a production setting. They are probably other ways of doing this, using Regular
                    // Expressions and more intelligent string manipulation functions. However, I generally like
                    // to write in a way that's most appropriate for a codebase, and allows additional functionality
                    // to be added. In this case, since I don't have a bigger picture to think of, I thought it
                    // best to write the code in a way that was simple and easy-to-read. This would then be considered
                    // a first step towards iteratively improving the method.

                    string output = "";
                    foreach (char letter in item)
                    {
                        char? outLetter;

                        switch (letter)
                        {
                            case '$':
                                outLetter = '£';
                                break;
                            case '_':
                                outLetter = null;
                                break;
                            case '4':
                                outLetter = null;
                                break;
                            default:
                                outLetter = letter;
                                break;
                        }


                        if (output.Length == 0 || !output.EndsWith(outLetter.ToString()))
                        {
                            if (outLetter.HasValue)
                            {
                                output += outLetter;
                            }
                        }
                    }

                    if (output != "")
                    {
                        if (output.Length > MAX_STRING_LENGTH)
                        {
                            output = output.Substring(0, MAX_STRING_LENGTH);
                        }
                        processedStrings.Add(output);
                    }
                }
            }

            return processedStrings;
        }
    }
}
