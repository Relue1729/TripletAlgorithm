using System;
using System.IO;
using static TripletAlgorithm.PerformanceProfiler;
using static TripletAlgorithm.Algorithms;

namespace TripletAlgorithm
{
    public class MenuDisplay
    {
        const string MainMenuText = "1 - Ввести путь к файлу               \r\n" +
                                    "2 - Тест алгоритма случайными данными \r\n" +
                                    "3 - Ввод входных данных в консоль     \r\n";
        public static void DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine(MainMenuText);
                var mainMenuSwitch = Console.ReadKey(true);

                switch (mainMenuSwitch.KeyChar)
                {
                    case '1': { DisplayFileInputMenu();        break; }
                    case '2': { DisplayRandomStringTestMenu(); break; }
                    case '3': { DisplayTextInputMenu();        break; }
                }
            }
        }
        private static void DisplayFileInputMenu()
        {
            Console.Clear();
            Console.WriteLine("Введите путь к файлу");

            string input = File.ReadAllText(Console.ReadLine());
            var execTime = GetExecutionTime(() => GetMostCommonTriplets(input, 10), out var output);

            Console.WriteLine($"{output}\r\n{execTime}мс\r\n");
        }
        private static void DisplayRandomStringTestMenu()
        {
            Console.Clear();
            Console.WriteLine("Введите максимальное количество символов:");

            string input = Console.ReadLine();
            if (int.TryParse(input, out var length))
            {
                var testData = TestAlgorithmWithIncreasingInputLength((x, y) => GetMostCommonTriplets(x, y), length);
                foreach (var data in testData) 
                { 
                    Console.WriteLine(data); 
                }
                Console.WriteLine();
            }
        }
        private static void DisplayTextInputMenu()
        {
            Console.Clear();
            Console.WriteLine("Введите входную строку:");

            string input = Console.ReadLine();
            var execTime = GetExecutionTime(() => GetMostCommonTriplets(input, 10), out var output);

            Console.WriteLine($"{output}\r\n{execTime}мс\r\n");
        }
    }
}