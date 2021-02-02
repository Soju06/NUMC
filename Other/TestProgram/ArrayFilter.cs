using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgram
{
    public static class ArrayFilter
    {
        public delegate bool FilterHandle<T>(T list);

        public static List<T> Filter<T>(this IList<T> list, FilterHandle<T> handle)
        {
            if (list == null) throw new ArgumentNullException("list");
            if (handle == null) throw new ArgumentNullException("handle");

            var h = new List<T>();
            
            for (int i = 0; i < list.Count; i++) {
                var g = list[i]; if (handle.Invoke(g)) h.Add(g);
            }

            return h;
        }
    }
}