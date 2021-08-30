using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MqttUtils;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Subscriber
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly MqttClientSubscriber _mqttClientSubscriber;

        public Worker(ILogger<Worker> logger, MqttClientSubscriber mqttClientSubscriber)
        {
            _logger = logger;

            //required to install nuget: Microsoft.Extensions.Configuration.Binder
            _mqttClientSubscriber = mqttClientSubscriber;
            _mqttClientSubscriber.RaiseMessageReceivedEvent += MqttMessageReceivedHandler;
            _ = _mqttClientSubscriber.Start();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _mqttClientSubscriber.SubscribeToTopic("topic");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Subscribe Worker running at: {time}", DateTimeOffset.Now);
                
                await Task.Delay(1000, stoppingToken);
            }
        }

        public async void MqttMessageReceivedHandler(object sender, MessageEventArgs e)
        {
            _logger.LogInformation("Subscribe message received at: {time} {message}", DateTimeOffset.Now, e.Message);
        }
    }
}
