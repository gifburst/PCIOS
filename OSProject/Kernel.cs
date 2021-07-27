using System;
using System.IO;
using Sys = Cosmos.System;


namespace OSProject
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs;

        protected override void BeforeRun()
        {
            //----------------------------------------------------------------------------------------------------

            /*Can try to make a good loader from SVGII driver! Trying for animation on startup.

            Cosmos.HAL.Drivers.PCI.Video.VMWareSVGAII driver = new Cosmos.HAL.Drivers.PCI.Video.VMWareSVGAII();
            driver.SetMode(1280, 720);
            driver.Clear(0xFFF);*/

            //----------------------------------------------------------------------------------------------------

            InitAnim.main(); // Initial animation. Loads too fast to see tho. :/

            fs = new Sys.FileSystem.CosmosVFS(); // Initializing a FAT file system with recycle bin.
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            if (!Directory.Exists(@"0:\RecycleBin"))
            {
                Directory.CreateDirectory(@"0:\RecycleBin");
            }
            Console.Clear();
            console.Writeline ("[1] PCI/OS [2] Calculator [3] Clock [4] Write [5] X-O game [6] Reboot [7] Shutdown");
            

                    choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "HELP":
                            Console.WriteLine("\n\nLIST OF COMMANDS");
                            Console.WriteLine("--------------------------------------");

                        CommandChoice:

                            Console.WriteLine("1. Program Commands");
                            Console.WriteLine("2. File System Commands");
                            Console.WriteLine("3. System Commands");

                            String comchoice = Console.ReadLine();

                            switch (comchoice)
                            {
                                case "1":
                                    Console.WriteLine("THE RED WORDS ARE THE COMMANDS!\n");
                                    Console.Write("1. SQUIRRIX WARE - ");
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("squiware\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("\t - Text Editor"); // Contains bugs.
                                    Console.WriteLine("\t - Calculator");
                                    Console.WriteLine("\t - Music Player");
                                    Console.WriteLine("\t - XnO Game");
                                    Console.WriteLine("\t - SqUIrrel\n");
                                    break;

                                case "2":
                                    Console.WriteLine("THE RED WORDS ARE THE COMMANDS!\n");

                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("DO NOT DELETE 'TEST', '0' & 'Dir Testing' DIRECTORIES!\nTHEY ARE SYSTEM FOLDERS!");
                                    Console.WriteLine("DELETING THEM WILL BREAK THE OS!\n");
                                    Console.ForegroundColor = ConsoleColor.White;

                                    Console.Write("2. File System Commands\n\n");
                                    Console.Write("\t - Check Status - "); // Check File System status.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("fstats");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - Create Directory - "); // Make a folder.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("md");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - Change Directory - "); // Change directory.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("cd");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - Current Path - "); // Get current path.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("curr");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - List - "); // List files & folders in the path.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("ls");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - Delete File - "); // Delete a file provided it exists.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("df");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - Delete Folder - "); // Delete a folder provided it exists and is empty.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("dd");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - Copy File - "); // Copy a file.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("cp");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - Move File - "); // Move a file.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("mv");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - Search - "); // Search for a file.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("search\n");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;

                                case "3":
                                    Console.WriteLine("THE RED WORDS ARE THE COMMANDS!\n");
                                    Console.WriteLine("3. System Commands\n");
                                    Console.Write("\t - Clear Screen - "); // Clears the screen.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("cls");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - Echo - "); // Echos out something.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("echo");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - Version - "); // Shows the OS version.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("version");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - Date & Time - "); // Shows the date and time.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("dnt");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - Lock System - "); // Locks the system.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("lock");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - Restart - "); // Restarts the system.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("restart");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - Shutdown - "); // Shuts down the system.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("shutdown");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("\t - About SQUIRRIX - "); // Tells us about the created OS.
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("about");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;

                                default:
                                    Console.WriteLine("Wrong Choice! Please enter again");
                                    goto CommandChoice;
                                    break;
                            }
                            break;

                            
                        case "4": // Text Editor.
                            Editor.Main();
                            break;

                        case "2": // Calculator.
                            Calculator.main();
                           break;

                        case "5": // X-O Game.
                           Game.Main();
                           break;

                        case "fstats":
                            FileSystem.checkstat();
                            break;

                        case "md":
                            f.makedir();
                            break;

                        case "curr":
                            f.current();
                            break;

                        case "cd":
                            f.changedir();
                            break;

                        case "ls":
                            f.list();
                            break;

                        case "df":
                            f.deletef();
                            break;

                        case "dd": // Bugging out.
                            f.deleted();
                            break;

                        case "cp":
                            f.copy();
                            break;

                        case "mv": // Bugging out.
                                   //f.move();
                            break;

                        case "search":
                            f.search();
                            break;

                        case "cls":
                            Console.Clear();
                            break;

                        case "echo":
                            Console.WriteLine("Enter something to echo out!");
                            String sentence = Console.ReadLine();
                            Console.WriteLine(sentence);
                            break;

                        case "version":
                            Console.WriteLine("\nv.1.0.0");
                            break;

                        case "3":
                            DateTime date = DateTime.Now;
                            Console.WriteLine(date);
                            break;

                        case "lock":
                            x = Lock.main();
                            Run();
                            break;

                        case "7":
                            Sys.Power.Shutdown();
                            break;

                        case "6":
                            Sys.Power.Reboot();
                            break;

                        case "1":
                            About.main();
                            break;

                        default:
                            Console.WriteLine("Wrong choice! Please enter a valid command!");
                            goto AccCommand;
                            break;

                    }

                }
            } while (true);

        }

    }

}
