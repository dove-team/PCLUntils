using System;
using System.IO;
using System.Threading.Tasks;

namespace PCLUntils.Steams
{
    public static class SteamUntils
    {
        public static async Task<bool> ReadBAsync(this Stream stream, byte[] buffer, int offset, int count)
        {
            try
            {
                if (offset + count <= buffer.Length)
                {
                    int read = 0;
                    while (read < count)
                    {
                        var available = await stream.ReadAsync(buffer, offset, count - read);
                        if (available == 0) throw new ObjectDisposedException(null);
                        read += available;
                        offset += available;
                    }
                    return true;
                }
            }
            catch { }
            return false;
        }
    }
}