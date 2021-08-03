using System;
using System.Collections.Generic;

namespace TripletAlgorithm
{
    public static class PerformanceProfiler
    {
        /// <summary>Возвращает время потраченное на выполнение метода, передав его результат в methodOutput</summary>
        public static double GetExecutionTime(Func<object> method, out object methodOutput)
        {
            DateTime startTime = DateTime.Now;
            methodOutput = method();
            return (DateTime.Now - startTime).TotalMilliseconds;
        }
        /// <summary>
        /// Возвращает время потраченное на выполнение метода, 
        /// передавая в него случайные строки c удваивающейся длиной 
        /// от 10 до stringLengthUpTo
        /// </summary>
        public static IEnumerable<string> TestAlgorithmWithIncreasingInputLength(Func<string, int, string> algorithm, int stringLengthUpTo)
        {
            string randomString = Algorithms.GetRandomString(stringLengthUpTo);
            object output;

            for (int i = 10; i < stringLengthUpTo; i *= 2)
            {
                var input = randomString.Substring(0, i);
                yield return $"{i}\t символов:\t { GetExecutionTime(() => algorithm(input, 10), out output) }мс";
            }

            yield return $"{stringLengthUpTo}\t символов:\t { GetExecutionTime(() => algorithm(randomString, 10), out output) }мс";
        }
    }
}