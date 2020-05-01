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
                        if (output.Length > 15)
                        {
                            output = output.Substring(0, 15);
                        }
                        processedStrings.Add(output);
                    }
                }
            }

            return processedStrings;
        }
    }
}
