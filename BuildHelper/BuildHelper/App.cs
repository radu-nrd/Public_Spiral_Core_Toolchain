using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BuildHelper
{
    internal class App
    {
        string _rootDir;
        public App()
        {
            _rootDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar))!.FullName;
            _rootDir = Directory.GetParent(_rootDir.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar))!.FullName;
        }

        private IniFile GetIniFile()
        {
            return new IniFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "options.ini"));
        }

        public void Run()
        {
            BuildMainApp();
            RemoveTmpFiles();
            BuildPlugins();
        }

        private void RemoveTmpFiles()
        {
            var tmpFiles = Directory.GetFiles(_rootDir+"\\Build", "__nouse", SearchOption.AllDirectories);
            foreach (var tmpFile in tmpFiles)
                File.Delete(tmpFile);
        }

        private void BuildMainApp()
        {
            var mainApp = GetMainApp();
            if (mainApp is null)
                throw new Exception("Main app not found in options.ini");
            var outputPath = Path.Combine(_rootDir, "Build");
            var psi = new ProcessStartInfo
            {
                FileName = "dotnet",
                //Arguments = $"build \"{mainApp}\" -c Release -o \"{outputPath}\"",
                Arguments = $"build \"{mainApp}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };
            using (var process = new Process { StartInfo = psi })
            {
                process.OutputDataReceived += (s, e) => { if (e.Data != null) Console.WriteLine(e.Data); };
                process.ErrorDataReceived += (s, e) => { if (e.Data != null) Console.Error.WriteLine(e.Data); };
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
        }

        private string? GetMainApp()
        {
            var ini = GetIniFile();
            var mainAppField = ini[Utils.MainAppIniField];
            if (mainAppField is null)
                throw new Exception($"Main app not found in {ini}");
            if(mainAppField.Count != 1)
                throw new Exception($"Main app should have only one entry in {ini}");
            if (bool.Parse(mainAppField[0]!.Value))
            {
                var allSlns = Directory.GetFiles(_rootDir, "*.sln", SearchOption.AllDirectories);
                return allSlns.FirstOrDefault(p => Path.GetFileNameWithoutExtension(p).Trim() == mainAppField[0]!.Name);
            }
            return null;
        }

        private void BuildPlugins()
        {
            var outputDir = _rootDir+"\\Build\\Plugins";
            var projects = GetValidProjects();
            foreach (var project in projects)
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    //Arguments = $"build \"{project}\" -c Release -o \"{outputDir}\"",
                    Arguments = $"build \"{project}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                };

                using (var process = new Process { StartInfo = psi })
                {
                    process.OutputDataReceived += (s, e) => { if (e.Data != null) Console.WriteLine(e.Data); };
                    process.ErrorDataReceived += (s, e) => { if (e.Data != null) Console.Error.WriteLine(e.Data); };

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();
                }
            }
        }

        private string[] GetValidProjects()
        {
            var allSlns = Directory.GetFiles(_rootDir, "*.sln", SearchOption.AllDirectories);
            var ini = GetIniFile();
            var validProjects = new List<string>();
            for (int i = 0; i < allSlns.Length; i++)
            {
                var projectName = Path.GetFileNameWithoutExtension(allSlns[i]);
                var iniData = ini[Utils.ProjectIniField]![projectName];
                if (iniData is not null && bool.Parse(iniData.Value))
                    validProjects.Add(allSlns[i]);
            }
            return validProjects.ToArray();

        }
    }
}
