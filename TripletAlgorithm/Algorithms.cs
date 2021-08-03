using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace TripletAlgorithm
{
    public static class Algorithms
    {
        public static string GetMostCommonTriplets(string input, int howMany)
        {
            input = input.ToLower();
            var triplets = new ConcurrentDictionary<string, int>();
            Parallel.ForEach(input.Split(" "), word =>
            {
                word = word.Trim();
                if (word.Length >= 3)
                {
                    for (int i = 0; i < word.Length - 2; i++)
                    {
                        var triplet = word.Substring(i, 3);
                        triplets.AddOrUpdate(triplet, _ => 1, (_, previousCount) => previousCount + 1);
                    }
                }
            });
            return string.Join(",", triplets.OrderByDescending(x => x.Value).Select(x => x.Key).Take(howMany));
        }

        public static string GetRandomString(int length)
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
            Random random = new Random();

            return new string(Enumerable.Range(1, length)
                                        .Select(_ => alphabet[random.Next(alphabet.Length)])
                                        .ToArray());
        }
    }
}