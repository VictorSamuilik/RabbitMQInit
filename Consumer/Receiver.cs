using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
{
   public class Receiver
   {
      public static void Main(string[] args)
      {
         var factory = new ConnectionFactory() { HostName = "localhost" };
         using (var connection = factory.CreateConnection())
         using (var chanel = connection.CreateModel())
         {
            chanel.QueueDeclare("BasicTest", false, false, false, null);
            EventingBasicConsumer consumer = new EventingBasicConsumer(chanel);
            consumer.Received += (model, ea) =>
            {
               var body = ea.Body;
               var massage = Encoding.UTF8.GetString(body);
               Console.WriteLine($"Received message {massage}...");
            };
            chanel.BasicConsume("BasicTest", true, consumer);
            Console.WriteLine("Press [enter] to exit the Consumer App...");
            Console.ReadLine();
         }
      }
   }
}
