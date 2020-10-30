namespace NUMC.Array
{
    public class Sort
    {
        public static void QuickSort(ISortIndex[] array, int p, int r)
        {
            if (p < r)
            {
                int q = Partition(array, p, r);

                QuickSort(array, p, q - 1);
                QuickSort(array, q + 1, r);
            }
        }

        public static int Partition(ISortIndex[] array, int p, int r)
        {
            int q = p;

            for (int j = p; j < r; j++)
                if (array[j].Index <= array[r].Index)
                {
                    Swap(array, q, j);
                    q++;
                }

            Swap(array, q, r);

            return q;
        }

        public static void Swap(ISortIndex[] array, int beforeIndex, int foreIndex)
        {
            var tmp = array[beforeIndex];

            array[beforeIndex] = array[foreIndex];
            array[foreIndex] = tmp;
        }
    }

    public interface ISortIndex
    {
        int Index { get; }
    }
}