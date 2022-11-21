#if NET45
using System;
#else
using Plugin.DeviceInfo;
using Plugin.DeviceInfo.Abstractions;
using System.Runtime.InteropServices;
#endif

namespace PCLUntils.Plantform
{
    public static class PlantformUntils
    {
        public static string ArchitectureString
        {
            get
            {
#if NET45
                return Environment.Is64BitProcess ? "x64" : "x86";
#else
                return RuntimeInformation.ProcessArchitecture switch
                {
                    Architecture.X86 => "x86",
                    Architecture.X64 => "x64",
                    Architecture.Arm => "arm",
                    Architecture.Arm64 => "arm64",
                    _ => "unknow",
                };
#endif
            }
        }
        public static bool IsArmArchitecture
        {
            get
            {
                try
                {
#if !NET45
                    var arch = RuntimeInformation.ProcessArchitecture;
                    return arch == Architecture.Arm || arch == Architecture.Arm64;
#endif
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
#if NET45
                        platform = Platforms.Windows;
#else
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
#endif
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
#if !NET45
                    return CrossDeviceInfo.Current.Platform == Platform.iOS;
#endif
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
#if !NET45
                    return CrossDeviceInfo.Current.Platform == Platform.Android;
#endif
                }
                catch { }
                return false;
            }
        }
    }
}