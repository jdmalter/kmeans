﻿using kmeans;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IRIS
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                throw new ArgumentException("Program <input> <output> <means>");
            }

            Func<string, double[]> keySelector = (line) => line.Split(',').Take(4).Select(double.Parse).ToArray();
            Func<string, string> valueSelector = (line) => line.Split(',')[4];

            IDictionary<double[], string> vectorToString = File.ReadAllLines(args[0])
                .Where((line) => line.Length > 0)
                .ToDictionary(keySelector, valueSelector);
            int means = int.Parse(args[2]);

            IDictionary<double[], double[]> vectorToCluster = new KMeans(new Random()).Run(vectorToString.Keys.ToArray(), means);
            foreach (double[] cluster in vectorToCluster.Values)
            {
                for (int i = 0; i < cluster.Length; i++)
                {
                    cluster[i] = Math.Round(cluster[i], 1);
                }
            }

            new Writer(args[1]).Write(vectorToCluster, vectorToString);
        }
    }
}
