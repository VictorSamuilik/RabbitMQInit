using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer
{
   public class Sender
   {
      public static void Main(string[] args)
      {
         var factory = new ConnectionFactory() { HostName = "my-rabbitmq", Port = 5672 };
         using (var connection = factory.CreateConnection())
         using (var chanel = connection.CreateModel())
         {
            chanel.QueueDeclare("BasicTest", false, false, false, null);
            string massage = "Getting started with .Net Core RabbitMQ";
            var body = Encoding.UTF8.GetBytes(massage);
            chanel.BasicPublish("", "BasicTest", null, body);
            Console.WriteLine($"Sent message {massage}...");
         }
         Console.WriteLine("Press [enter] to exit the Sender App...");
         Console.ReadLine();
      }
   }
}
