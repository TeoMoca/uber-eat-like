using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDev.Extensions;

public static class ComplexContainsExtensions
{
    public static bool ComplexContains(this string source, string value)
    {
        var index = CultureInfo.InvariantCulture.CompareInfo.IndexOf
            (source, value, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreSymbols);
        return index != -1;
    }
}
