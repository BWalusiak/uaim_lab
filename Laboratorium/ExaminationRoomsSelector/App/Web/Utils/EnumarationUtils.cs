namespace ExaminationRoomsSelector.Web.Utils
{
    using System;
    using System.Collections.Generic;

    public static class EnumarationUtils
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }
    }
}