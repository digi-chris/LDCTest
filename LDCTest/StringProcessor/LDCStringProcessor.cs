using System;
using System.Collections.Generic;
using System.Text;

namespace StringProcessor
{
    public class LDCStringProcessor : IStringProcessor
    {
        public List<string> Process(List<string> stringCollection)
        {
            List<string> processedStrings = new List<string>();

            foreach (string item in stringCollection)
            {
                char? lastLetter = null;
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


                    if (lastLetter != outLetter)
                    {
                        lastLetter = outLetter;
                    }
                    else if (outLetter.HasValue)
                    {
                        output += outLetter;
                    }
                }

                if (output != "")
                {
                    processedStrings.Add(output);
                }
            }

            return processedStrings;
        }
    }
}
