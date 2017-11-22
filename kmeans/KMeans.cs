using System;
using System.Collections.Generic;

namespace kmeans
{
    public class KMeans
    {
        private Random random;

        public KMeans(Random random)
        {
            this.random = random;
        }

        private double[][] TakeRandom(double[][] vectors, int means)
        {
            double[][] clusters = new double[means][];
            for (int mean = 0; mean < means; mean++)
            {
                clusters[mean] = vectors[random.Next(vectors.Length)];
            }
            return clusters;
        }

        public IDictionary<double[], double[]> Run(double[][] vectors, int means)
        {
            double[][] clusters = TakeRandom(vectors, means);
            int[] assignment = new int[vectors.Length];
            for (int i = 0; i < 50; i++)
            {
                assignment.Assign(vectors, clusters);
                clusters.Update(vectors, assignment);
            }
            IDictionary<double[], double[]> dictionary = new Dictionary<double[], double[]>();
            for (int j = 0; j < vectors.Length; j++)
            {
                dictionary[vectors[j]] = clusters[assignment[j]];
            }
            return dictionary;
        }
    }
}
