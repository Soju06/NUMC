using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace NUMC.Expansion
{
    public static class ArrayExpansion
    {
        public delegate bool FilterHandle<T>(T obj);
        
        public static List<T> Filter<T>(this IList<T> list, FilterHandle<T> handle) {
            if (list == null) throw new ArgumentNullException("list");
            if (handle == null) throw new ArgumentNullException("handle"); 
            var h = new List<T>(); 
            for (int i = 0; i < list.Count; i++) {
                var g = list[i]; if (handle.Invoke(g)) h.Add(g);
            } return h;
        }

        public static T OneFilter<T>(this IList<T> list, FilterHandle<T> handle)
        {
            if (list == null) throw new ArgumentNullException("list");
            if (handle == null) throw new ArgumentNullException("handle"); 
            for (int i = 0; i < list.Count; i++) {
                var g = list[i]; if (handle.Invoke(g)) return g;
            } return default;
        }

        public static T TryGetValue<T>(this IList<T> list, int index)
        {
            if (index < 0 || index >= list.Count) return default;
            return list[index];
        }
        public static void QuickSort(this IList<ISortIndex> list, int p, int r)
        {
            if (p < r) {
                int q = Partition(list, p, r); 
                QuickSort(list, p, q - 1);
                QuickSort(list, q + 1, r);
            }
        }

        public static int Partition(IList<ISortIndex> list, int p, int r)
        {
            int q = p;
            var ri = GetSortIndex(list[r]);
            for (int j = p; j < r; j++) {
                if (GetSortIndex(list[j]) <= ri) {
                    Swap(list, q, j); q++;
                }
            } Swap(list, q, r); 
            return q;
        }

        private static void Swap(IList<ISortIndex> list, int beforeIndex, int foreIndex)
        {
            var tmp = list[beforeIndex];
            list[beforeIndex] = list[foreIndex];
            list[foreIndex] = tmp;
        }

        private static int GetSortIndex(ISortIndex sortIndex, int defaultValue = 5)
        {
            var index = defaultValue;
            try { 
                if (sortIndex == null) return defaultValue; index = sortIndex.Index; 
            } catch (Exception ex) { 
                Plugin.Plugin.PluginException(ex, sortIndex?.GetType(), "ISortIndex Get Index Failed"); 
            } return index;
        }
    }

    public interface ISortIndex
    {
        int Index { get; }
    }
}