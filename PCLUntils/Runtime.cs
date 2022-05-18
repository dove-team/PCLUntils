using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PCLUntils
{
    public sealed class Runtime
    {
        private static Platforms _Platform = Platforms.UnSupport;
        public static Platforms Platform
        {
            get
            {
                try
                {
                    if (IsAndroid)
                        _Platform = Platforms.Android;
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                        _Platform = Platforms.Linux;
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                        _Platform = Platforms.MacOS;
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        _Platform = Platforms.Windows;
                }
                catch { }
                return _Platform;
            }
        }
        private static bool IsAndroid
        {
            get
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
}