using System.Net.Sockets;
using System.Net;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.IO;

var ipEndPoint = new IPEndPoint(IPAddress.Any, 13000);
TcpListener listener = new(ipEndPoint);

try
{
    listener.Start();
    string ticker = "";
    while (true) {
        using var tcpClient = await listener.AcceptTcpClientAsync();
        Byte[] buffer = new Byte[1024];
        NetworkStream buffer_s = tcpClient.GetStream();
        Int32 buffer32 = buffer_s.Read(buffer, 0, buffer.Length);
        ticker = System.Text.Encoding.ASCII.GetString(buffer, 0, buffer32);
        using (StockContext ka52 = new StockContext())
        {
            var tickers = ka52.StockPrices.ToList().Where(a => a.Ticker == ticker);
            foreach (var v in tickers) {
                //Console.WriteLine($"tickers: {v.Price}");
                var buf = System.Text.Encoding.ASCII.GetBytes(v.Price.ToString());
                buffer_s.Write(buf, 0, buf.Length);
            }
            
        }
    }
    
}
finally
{
    listener.Stop();
}