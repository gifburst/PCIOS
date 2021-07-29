using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Input;
using Sys = Cosmos.System;
using System.Threading;
using Cosmos.Core.IOGroup;

namespace OSProject
{
    class Programs
    {
        public static void main()
        {
            string pchoice;
            bool exit = false;
            do
            {
                Console.WriteLine("╔═ Programs installed on PCI/OS for ChipPad ═╗\n");
                Console.WriteLine("┌─ 1. Text Editor ─┐"); 
                Console.WriteLine("┌─ 2. Calculator ─┐");
                Console.WriteLine("┌─ 3. Date ─┐"); 
                Console.WriteLine("┌─ 4. X-O Game ─┐"); 
                Console.WriteLine("┌─ 5. Exit ─┐\n\n");

                Console.WriteLine("Enter the choice of program.");
                pchoice = Console.ReadLine();

                switch (pchoice)
                {
                    case "1": // Text Editor.
                        Editor.Main();
                        break;

                    case "2": // Calculator.
                        Calculator.main();
                        break;
                        
                    case "3":
                        DateTime date = DateTime.Now;
                        Console.WriteLine(date);
                        break;
                        
                    case "4": // X-O Game.
                        Game.Main();
                        break;

                    case "5":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Wrong choice. Try again");
                        break;
                }
            } while (!exit);
            exit = false;
            return;
        }
    }
}
