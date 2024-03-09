// https://github.com/kroefer
using System;
using Cosmos.Core;
using Sys = Cosmos.System;

namespace SharpK
{
    public class Kernel : Sys.Kernel
    {
        private string _Prompt;

        protected override void BeforeRun()
        {
            Console.Clear();
            Console.Beep();
            string asciiart = @" 

  ______   __                                      __    __ 
 /      \ |  \                                    |  \  /  \
|  $$$$$$\| $$____    ______    ______    ______  | $$ /  $$
| $$___\$$| $$    \  |      \  /      \  /      \ | $$/  $$ 
 \$$    \ | $$$$$$$\  \$$$$$$\|  $$$$$$\|  $$$$$$\| $$  $$  
 _\$$$$$$\| $$  | $$ /      $$| $$   \$$| $$  | $$| $$$$$\  
|  \__| $$| $$  | $$|  $$$$$$$| $$      | $$__/ $$| $$ \$$\ 
 \$$    $$| $$  | $$ \$$    $$| $$      | $$    $$| $$  \$$\
  \$$$$$$  \$$   \$$  \$$$$$$$ \$$      | $$$$$$$  \$$   \$$
                                        | $$                
                                        | $$                
                                         \$$                
https://github.com/Kroefer/SharpK

";
            Console.WriteLine(asciiart);
            Console.WriteLine(" ");
            Console.WriteLine("Welcome to SharpK.");
            _Prompt = "root@sharpk:~# ";
        }

        protected override void Run()
        {
            Console.Write($"{_Prompt}");
            var input = Console.ReadLine();
            string[] words = input.Split(' ');
            switch (words[0])
            {
                case "clear":
                    Console.Clear();
                    break;
                case "version":
                    Console.WriteLine($"SharpK 1.2");
                    break;
                case "cpu":
                    Console.WriteLine($"Vendor: {CPU.GetCPUVendorName()}, Name: {CPU.GetCPUBrandString()}");
                    break;
                case "shutdown":
                    Sys.Power.Shutdown();
                    break;
                case "restart":
                    Sys.Power.Reboot();
                    break;
                case "help":
                    Console.WriteLine("clear    - clears the screen beacause why not");
                    Console.WriteLine("cpu      - prints info about current cpu");
                    Console.WriteLine("shutdown - shuts down current computer");
                    Console.WriteLine("restart  - restarts current computer");
                    Console.WriteLine("help     - shows this help menu");
                    Console.WriteLine("version  - shows what version you are running");
                    break;
                default:
                    Console.WriteLine($"\"{words[0]}\" is not a command, type 'help' to view all commands.");
                    break;
            }
            Console.WriteLine();
        }
    }
}