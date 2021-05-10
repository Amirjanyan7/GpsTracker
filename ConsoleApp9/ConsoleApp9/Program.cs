using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpListenerApp
{
    class Program
    {
        const int port =8080;
 
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                byte[] name=null;
                IPAddress localAddr = IPAddress.Parse("37.252.87.66");
                server = new TcpListener(localAddr, port);

                // запуск слушателя
                server.Start();

                
                    Console.WriteLine("Ожидание подключений... ");

                    // получаем входящее подключение
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Подключен клиент. Выполнение запроса...");

                    // получаем сетевой поток для чтения и записи
                    NetworkStream stream = client.GetStream();
                if (stream.CanRead)
                {
                    //int num = stream.Read(name,0,(int)stream.Length);
                    //Console.WriteLine(num);
                    for (int i = 0; i < 17; i++)
                    {
                        Console.WriteLine(Convert.ToString(stream.ReadByte()));

                    }


                }


              
                //  int x = 1;
                byte[] data = { 1, 0 };//BitConverter.GetBytes(n); 
              
                    stream.Write(data, 0, data.Length);

                    
                    Console.WriteLine("Отправлено сообщение: {0}", data);
                if (stream.CanRead)
                {
                    byte[] data3 = new byte[300];
                    //int num = stream.Read(name,0,(int)stream.Length);
                    //Console.WriteLine(num);
                    while (true)
                   
                    {
                      
                      
                        Console.Write(Convert.ToString(stream.ReadByte()));
                    }
                   

                }

                stream.Close();

                    client.Close();
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (server != null)
                    server.Stop();
            }
        }
    }
}