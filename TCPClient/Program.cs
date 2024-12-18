using System.Net.Sockets;
using System.Net;
using System;


using TcpClient client = new();
await client.ConnectAsync("127.0.0.1", 13000);

if (client.Connected) {
    await using NetworkStream stream = client.GetStream();
    while (true)
    {
        var buffer1 = new byte[1_024];
        var ticker = Console.ReadLine();
        buffer1 = System.Text.Encoding.ASCII.GetBytes(ticker);
        stream.Write(buffer1, 0, buffer1.Length);
        Byte[] buffer2 = new Byte[1024];
        Int32 buffer32 = stream.Read(buffer2, 0, buffer2.Length);
        string tout = System.Text.Encoding.ASCII.GetString(buffer2, 0, buffer32);
        Console.WriteLine(tout);
        break;
    }
}



