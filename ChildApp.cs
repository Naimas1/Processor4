using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processor4
{
    internal class ChildApp
    {
        void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Неверное количество аргументов.");
                return;
            }

            string directoryPath = args[0];
            string searchWord = args[1];
            int wordCount = 0;

            try
            {
                // Получение списка файлов в указанной директории
                string[] files = Directory.GetFiles(directoryPath, "*.txt");

                // Поиск указанного слова в каждом файле
                foreach (string file in files)
                {
                    string content = File.ReadAllText(file);
                    wordCount += CountWordOccurrences(content, searchWord);
                }

                // Вывод результата поиска
                Console.WriteLine($"Слово '{searchWord}' найдено {wordCount} раз.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при обработке файлов: " + ex.Message);
            }
        }

        // Метод для подсчета количества вхождений слова в текст
        static int CountWordOccurrences(string text, string word)
        {
            int count = 0;
            int index = text.IndexOf(word, StringComparison.OrdinalIgnoreCase);
            while (index != -1)
            {
                count++;
                index = text.IndexOf(word, index + 1, StringComparison.OrdinalIgnoreCase);
            }
            return count;
        }
    }
}
