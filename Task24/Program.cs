using CommandLine;
using System;
using System.IO;

namespace Task24
{
    // создаем специальный класс
    public class Options
    {
        [Option('p', "path", Required = true, HelpText = "File path")]
        public string Path { get; set; }
        
        [Option('n', "number", HelpText = "Если флаг указан, выводим по два числа")]
        public int Number { get; set; }


    }

    public class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(param => { // в которую передаем лямбду
                    using(StreamReader reader = new StreamReader(param.Path))
                    {
                        string text = reader.ReadToEnd();
                        string[] words = text.Split(' ');
                        string rows = "";
                        foreach(string word in words) {
                            if(word.Length >= param.Number)
                            {
                                rows += word;
                            }
                        }
                        Console.WriteLine(rows);
                    }
                });
        }
    }
}
