using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace kmeans
{
    public class Writer
    {
        private string path;

        public Writer(string path)
        {
            this.path = path;
        }

        public void Write(IDictionary<double[], double[]> vectorToCluster, IDictionary<double[], string> vectorToString)
        {
            using (StreamWriter writer = new StreamWriter(@path))
            {
                foreach (IGrouping<double[], double[]> group in vectorToCluster.Keys.GroupBy((vector) => vectorToCluster[vector]))
                {
                    writer.WriteLine("cluster at " + group.Key.ToPrettyString() + " with " + group.Count() + " vectors");
                    foreach (double[] vector in group)
                    {
                        writer.WriteLine(vectorToString[vector] + " " + vector.ToPrettyString());
                    }
                    writer.WriteLine();
                }
            }
        }
    }
}
