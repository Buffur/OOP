using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lab14
{
    class Program
    {
        static async Task Main(string[] args)
        { 
          // Task1. Паралельна обробка логів
            string[] fileNames = { "log1.txt", "log2.txt", "log3.txt" };

            try
            {
                GenerateLogFile("log1.txt", 10000, 5);
                GenerateLogFile("log2.txt", 10000, 3);
                GenerateLogFile("log3.txt", 10000, 7);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при створенні файлів: {ex.Message}");
                return;
            }

            Task[] tasks = new Task[fileNames.Length];
            for (int i = 0; i < fileNames.Length; i++)
            {
                int fileIndex = i;
                tasks[i] = Task.Run(() => ProcessLog(fileNames[fileIndex]));
            }
            await Task.WhenAll(tasks);

            Console.WriteLine("Обробка лог-файлів завершена!");
        }

        static void GenerateLogFile(string fileName, int lineCount, int errorCount)
        {
            Random rand = new Random();
            string[] lines = new string[lineCount];
            for (int i = 0; i < lineCount; i++)
            {
                lines[i] = i < errorCount ? "ERROR: Something went wrong" : $"INFO: Line {i}";
            }
            lines = lines.OrderBy(_ => rand.Next()).ToArray();
            File.WriteAllLines(fileName, lines);
        }

        static void ProcessLog(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                int errorCount = lines.Count(line => line.Contains("ERROR"));
                Console.WriteLine($"Файл {fileName}: знайдено {errorCount} помилок.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при обробці файлу {fileName}: {ex.Message}");
            }
        }
    }

}