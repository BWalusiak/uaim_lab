namespace ExaminationRoomsSelector.Web.Utils
{
    using System;
    using System.Collections.Generic;

    public static class EnumerationUtils
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (var item in enumeration) action(item);
        }
    }
}