using System;
using System.Collections.Generic;
using System.Text;

namespace StringProcessor
{
    public interface IStringProcessor
    {
        List<string> Process(List<string> stringCollection);
    }
}
