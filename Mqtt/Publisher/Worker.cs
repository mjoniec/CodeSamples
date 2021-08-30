using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MqttUtils;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Publisher
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly MqttClientPublisher _mqttClientPublisher;

        public Worker(ILogger<Worker> logger, MqttClientPublisher mqttClientPublisher)
        {
            _logger = logger;
            _mqttClientPublisher = mqttClientPublisher;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var i = 1;
            await _mqttClientPublisher.Start();

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Publish Worker running at: {time}", DateTimeOffset.Now);

                await _mqttClientPublisher.PublishAsync("Test: " + i + " at time: " + DateTime.Now.ToString("G"), "topic");

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
