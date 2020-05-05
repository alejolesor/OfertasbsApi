using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using OfertasbsApi.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfertasbsApi.negocio
{
    public class serviceKafka
    {
        public bool ProducerTopic(string message, string topic)
        {
            try
            {
                Message msg = new Message(message);
                Uri uri = new Uri("http://localhost:9092");
                var options = new KafkaOptions(uri);
                var router = new BrokerRouter(options);
                var client = new Producer(router);
                client.SendMessageAsync(topic, new List<Message> { msg }).Wait();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string ConsumerTopic(string topic)
        {
            Uri uri = new Uri("http://localhost:9092");
            var options = new KafkaOptions(uri);
            var router = new BrokerRouter(options);
            var consumer = new Consumer(new ConsumerOptions(topic, router));
            string messageTopic = string.Empty;
            foreach (var message in consumer.Consume())
            {
                messageTopic =  Encoding.UTF8.GetString(message.Value);
                break;
            }

            return messageTopic;
        }


    }
}


