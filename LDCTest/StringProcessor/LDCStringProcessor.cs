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

            foreach (string item in stringCollection)
            {
                if (item != null)
                {
                    //char? lastLetter = null;
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
