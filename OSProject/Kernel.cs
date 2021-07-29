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
            Console.ForegroundColor = ConsoleColor.Orange;
            console.Writeline ("┌─ [0] PCI/OS ─┐ ┌─ [1] Apps ─┐ ┌─ [2] Reboot ─┐ ┌─ [3] Shutdown ─┐");
            

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

                            
                    

                        case "1":
                            Programs.main();
                            break;
                            
                        case "2":
                            Sys.Power.Shutdown();
                            break;

                        case "3":
                            Sys.Power.Reboot();
                            break;

                        case "0":
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
