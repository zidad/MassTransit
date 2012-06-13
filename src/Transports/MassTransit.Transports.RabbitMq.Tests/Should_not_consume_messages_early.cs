// Copyright 2007-2012 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.Transports.RabbitMq.Tests
{
    using System;
    using System.Threading;
    using NUnit.Framework;
    using Serialization;
    using Magnum.Extensions;

    public class Should_not_consume_messages_early
    {
        [SetUp] 
        public void SetUp()
        {
            using(createBus())
            {
                //setup bindings
            }

            Endpoints.Initialize(cfg=>
                                     {
                                         cfg.AddTransportFactory(new RabbitMqTransportFactory());
                                         cfg.SetDefaultSerializer(new JsonMessageSerializer());
                                     });

            var ep = Endpoints.GetEndpoint("rabbitmq://localhost/bob");
            for (int i = 0; i < 100; i++)
            {
                ep.Send(new RabbitMessage());
            }

            _i = 0;
        }

        ManualResetEvent _mre;
        int _i = 0;

        [Test]
        public void Test()
        {
            _mre = new ManualResetEvent(false);

            using(var bus = createBus())
            {


                _mre.WaitOne(5.Seconds());
            }
        }

        IServiceBus createBus()
        {
            var sb = ServiceBusFactory.New(sbc =>
            {
                sbc.UseRabbitMq();
                sbc.UseRabbitMqRouting();

                sbc.ReceiveFrom("rabbitmq://localhost/bob");
                sbc.Subscribe(subs =>
                {
                    subs.Handler<RabbitMessage>(m =>
                                                    {
                                                        _i++;
                        Console.WriteLine("got it");
                                                        if(_i>=100)
                                                        {
                                                            _mre.Set();
                                                            Console.WriteLine(_i);
                                                        }
                        
                    });
                });
            });
            return sb;
        }
    }

    public class RabbitMessage
    {
        
    }
}