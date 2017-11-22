using System;

namespace kmeans
{
    public static class Vector
    {
        public static double Distance(this double[] a, double[] b)
        {
            double sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += (a[i] - b[i]) * (a[i] - b[i]);
            }
            return Math.Sqrt(sum);
        }

        public static string ToPrettyString(this double[] a)
        {
            return "[" + string.Join(", ", a) + "]";
        }
    }
}
