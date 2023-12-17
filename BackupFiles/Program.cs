﻿using System.Diagnostics;
using Util;

namespace BackUp{
    public class Program{
        public static void Main(){
            string input = "";
            Logs.CreateLog();
            DataFilePaths.CreateDataFile();
            Logs.WriteLog("New Session Started");
            Stopwatch sw = new();
            sw.Start();
            Data data = new();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            while(input != "exit"){
                Console.Write(">");
                input = (Console.ReadLine() + "").Trim();
                Args args = new(input);
                
                if(args.command == "add"){
                    data.Add(args);
                }else if(args.command == "backup"){
                    data.CreateBackUp(args);
                }else if(args.command == "list"){
                    data.ListFiles();
                }else{
                    Console.WriteLine("Invalid Command: " + args.command);
                }
            }
            Logs.WriteLog("Session Closed");
            Console.WriteLine("Closing File Backup System");
            Thread.Sleep(100);
        }
    }
}