using PCLUntils.Objects;
using PCLUntils.Plantform;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PCLUntils.Untils
{
    public static class SystemUntils
    {
        public static bool SetClipboard(this string content)
        {
            bool success = false;
            try
            {
                if (content.IsNotEmpty())
                {
                    switch (PlantformUntils.System)
                    {
                        case Platforms.Windows:
                            {
                                if (Win32API.OpenClipboard(IntPtr.Zero))
                                {
                                    Win32API.EmptyClipboard();
                                    Win32API.SetClipboardData(13, Marshal.StringToHGlobalUni(content));
                                    Win32API.CloseClipboard();
                                    success = true;
                                }
                            }
                            break;
                        default:
                            success = $"echo \"{content}\" | pbcopy".ExecuteShell(out _);
                            break;
                    }
                }
            }
            catch { }
            return success;
        }
        public static bool ExecuteShell(this string shell, out string result)
        {
            result = string.Empty;
            try
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        UseShellExecute = false,
                        FileName = "/bin/bash",
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        Arguments = $"-c \"{shell.Replace("\"", "\\\"")}\""
                    }
                };
                process.Start();
                result = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                process.Dispose();
                return true;
            }
            catch { }
            return false;
        }
    }
}