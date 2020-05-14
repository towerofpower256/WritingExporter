using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WritingExporter.WinForms
{
    /// <summary>
    /// Utility functions related to the Windows OS.
    /// </summary>
    public static class WinUtil
    {
        public static void RunExplorerCommand(string command, bool sanitiseCommand = true)
        {
            if (sanitiseCommand && !IsStringQuoted(command))
            {
                
                command = $"\"{Regex.Replace(command, "\"", "\\\"")}\""; // Escape any quotation, and wrap in quotation.
            }

            var processInfo = new System.Diagnostics.ProcessStartInfo();
            processInfo.WorkingDirectory = Assembly.GetExecutingAssembly().Location;
            processInfo.FileName = "explorer.exe";
            processInfo.Arguments = command;
            processInfo.CreateNoWindow = true;
            var process = new System.Diagnostics.Process();
            process.StartInfo = processInfo;
            process.Start();
        }

        public static bool IsStringQuoted(string input)
        {
            return new Regex(@"^\"".*\""").Match(input).Success;
        }

        public static string GetCurrentDir()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}
