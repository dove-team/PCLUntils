using System.Net;
using System.Net.Sockets;

namespace PCLUntils.Net
{
    public static class NetUntils
    {
        public static int GetAvailablePort()
        {
            try
            {
                IPAddress ipa = new IPAddress(new byte[] { 127, 0, 0, 1 });
                TcpListener listener = new TcpListener(ipa, 0);
                listener.Start();
                int port = ((IPEndPoint)listener.LocalEndpoint).Port;
                listener.Stop();
                return port;
            }
            catch { }
            return 5600;
        }
    }
}