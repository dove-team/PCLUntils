using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PCLUntils.Plantform
{
    public static class PlantformUntils
    {
        public static string CurrentArchString(this object _)
        {
            return RuntimeInformation.ProcessArchitecture switch
            {
                Architecture.X86 => "x86",
                Architecture.X64 => "x64",
                Architecture.Arm => "arm",
                Architecture.Arm64 => "arm64",
                _ => "unknow",
            };
        }
        public static Platforms Platform()
        {
            Platforms platform = Platforms.UnSupport;
            try
            {
                if (IsAndroid())
                    platform = Platforms.Android;
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    platform = Platforms.Linux;
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    platform = Platforms.MacOS;
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    platform = Platforms.Windows;
            }
            catch { }
            return platform;
        }
        public static bool IsAndroid()
        {
            using var process = new Process();
            process.StartInfo.FileName = "getprop";
            process.StartInfo.Arguments = "ro.build.user";
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            bool isAndroid = false;
            try
            {
                process.Start();
                var output = process.StandardOutput.ReadToEnd();
                isAndroid = !string.IsNullOrEmpty(output);
            }
            catch { }
            return isAndroid;
        }
    }
}