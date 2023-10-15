using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumerableExtensions
{
    public static T GetMax<T>(this IEnumerable<T> sequence, Func<T, float> getParameter) where T : class
    {
        return sequence?.OrderByDescending(getParameter).FirstOrDefault();
    }
}
