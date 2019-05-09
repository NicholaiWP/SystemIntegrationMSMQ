using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace obligatorisk_systemInt
{
    class EUCCID_system : QueueManager
    {
        public EUCCID_system(string queueName) : base(queueName, new XmlMessageFormatter(new Type[] { typeof(EUCCIDRegisterData), typeof(string), typeof(int), typeof(Gender)}))
        {             
        }

        protected override void ReceiveCompletedEventHandler(object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;

            // End the asynchronous Receive operation.
            Message m = mq.EndReceive(asyncResult.AsyncResult);

            var cprData = (CPRRegisterData)m.Body;

           var euccid = Translator.CPRRegisterDataTranslation(cprData);

            Console.WriteLine(euccid.CristianName + " | " + euccid.FamilyName + Environment.NewLine + " | " + euccid.EU_CCID +
                    " | " + euccid.Gender + " | " + euccid.StreetAndNumberOfHouse + Environment.NewLine + " | " + euccid.ApartmentNumber + " | " +
                     euccid.Country + " | " + euccid.City + Environment.NewLine + " | " + euccid.BirthCountry + " | " + euccid.CurrentLivingCountry +
                    " | " + euccid.Nationality);


            // Restart the asynchronous Receive operation.
            mq.BeginReceive();

        }
    }
}
