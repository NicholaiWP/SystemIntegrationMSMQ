using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace obligatorisk_systemInt
{
   abstract class QueueManager
    {
        private MessageQueue msMq;

        readonly string queueName;

        public MessageQueue MsMq { get => msMq; set => msMq = value; }
        public Message Message { get; set; }

        public QueueManager(string queueName, XmlMessageFormatter formatter)
        {
            this.queueName = queueName;

            // check if queue exists, if not create it
            if (!MessageQueue.Exists(queueName))
            {
                MsMq = MessageQueue.Create(queueName);
            }
            else
            {
                MsMq = new MessageQueue(queueName);
            }

               msMq.Formatter = formatter;
            msMq.ReceiveCompleted += ReceiveCompletedEventHandler;
            msMq.BeginReceive();
        }

        protected abstract void ReceiveCompletedEventHandler(object source, ReceiveCompletedEventArgs asyncResult);
    }
}
