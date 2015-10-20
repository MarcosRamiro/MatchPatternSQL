using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace TesteFila
{
    class Program
    {
        const string queue_name = @".\private$\sample_queue";
        static void Main(string[] args)
        {
            Console.Title = "Sender";

            MessageQueue queue;
            if (MessageQueue.Exists(queue_name))
                queue = new MessageQueue(queue_name);
            else
                queue = MessageQueue.Create(queue_name);

            while (true)
                queue.Send(Console.ReadLine());
        }
    }
}
