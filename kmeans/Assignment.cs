namespace kmeans
{
    public static class Assignments
    {
        public static void Assign(this int[] assignments, double[][] vectors, double[][] clusters)
        {
            for (int i = 0; i < vectors.Length; i++)
            {
                double min = double.MaxValue;
                for (int j = 0; j < clusters.Length; j++)
                {
                    double distance = vectors[i].Distance(clusters[j]);
                    if (min > distance)
                    {
                        min = distance;
                        assignments[i] = j;
                    }
                }
            }
        }

        public static void Update(this double[][] clusters, double[][] vectors, int[] assignments)
        {
            for (int i = 0; i < clusters.Length; i++)
            {
                double[] cluster = new double[clusters[i].Length];
                int count = 0;
                for (int j = 0; j < assignments.Length; j++)
                {
                    if (i == assignments[j])
                    {
                        for (int k = 0; k < vectors[j].Length; k++)
                        {
                            cluster[k] += vectors[j][k];
                        }
                        count++;
                    }
                }
                for (int l = 0; l < cluster.Length; l++)
                {
                    cluster[l] /= count;
                }
                clusters[i] = cluster;
            }
        }
    }
}
