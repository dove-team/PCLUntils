using Plugin.DeviceInfo;
using Plugin.DeviceInfo.Abstractions;
using System.Runtime.InteropServices;

namespace PCLUntils.Plantform
{
    public static class PlantformUntils
    {
        public static string ArchitectureString
        {
            get
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
        }
        public static bool IsArmArchitecture
        {
            get
            {
                try
                {
                    var arch = RuntimeInformation.ProcessArchitecture;
                    return arch == Architecture.Arm || arch == Architecture.Arm64;
                }
                catch { }
                return false;
            }
        }
        public static Platforms System
        {
            get
            {
                Platforms platform = Platforms.UnSupport;
                try
                {
                    if (IsAndroid)
                        platform = Platforms.Android;
                    else if (IsiOS)
                        platform = Platforms.iOS;
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
        }
        public static bool IsiOS
        {
            get
            {
                try
                {
                    return CrossDeviceInfo.Current.Platform == Platform.iOS;
                }
                catch { }
                return false;
            }
        }
        public static bool IsAndroid
        {
            get
            {
                try
                {
                    return CrossDeviceInfo.Current.Platform == Platform.Android;
                }
                catch { }
                return false;
            }
        }
    }
}