using System;

namespace ДЗ_5
{
    class Text 
    {
        static void ReadDataFndSafeFile()
        {
            Console.WriteLine("Input file path and save data");

            var path = Console.ReadLine();
            if(string.IsNullOrEmpty(path)) || (string.IsNullOrWhiteSpace(path));
            {
                Console.WriteLine("Incorect Path");
                return;
            }
            if (!path.EndsWith(".txt")) path += ".txt";
            using var fs = new FileStream(path, File.Exists(path) ? FileMode.Append : FileMode.OpenOrCreate);
            using var sw = new StreamWriter(fs);

            Console.WriteLine("Введите данные для сохранения в текстовом файле, нажмите Esc, чтобы остановить");
            sw.AutoFlush = true;
            while (true)
            {
                var inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.Escape)
                    break;
                if (inputKey.Key == ConsoleKey.Enter)
                {
                    sw.Write("\n");
                    Console.WriteLine();
                }
                else sw.Write(inputKey.KeyChar);
            }

            Console.WriteLine("\nРабота сделана");
        }

        static void AppendTime()
        {
            using var sw = File.AppendText("startup.txt");
            var time = DateTime.Now.ToString("HH:mm:ss tt");
            sw.Wtiteline(time);
            Console.WriteLine($"Я создал sturtup.txt новое время,это {time}, посмотри");
        }

        static void BinFile()
        {
            const string file = "test.bin";
            Console.WriteLine("Введите числа от  [0..255] через пробел");
            var input = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (input is null)
            {
                Console.WriteLine("Неправильный ввод");
                return;
            }

            var array = new byte[input.Length];
            for (var i = 0; i < array.Length; i++)
            {
                if (!byte.TryParse(input[i], out var number))
                {
                    Console.WriteLine($"Неправильный номер{ input[i]}");
                    return;
                }
                array[i] = number;
            }

        }
    }   
}
