using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace obligatorisk_systemInt
{
    class CPR_system : QueueManager
    {
        public CPR_system(string queueName) : base(queueName, new XmlMessageFormatter(new Type[] { typeof(CPRRegisterData), typeof(string), typeof(int), typeof(AegteskabeligStatus) }))
        {         
        }

        protected override void ReceiveCompletedEventHandler(object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;

            // End the asynchronous Receive operation.
            Message m = mq.EndReceive(asyncResult.AsyncResult);

            // Restart the asynchronous Receive operation.
            mq.BeginReceive();

            return;
        }
    }
}
