using HRManagement.Web.Context;
using HRManagement.Web.Models;
using HRManagement.Web.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NCrontab;
using Nest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HRManagement.Web.Utils
{
    public class MyTestHostedService : BackgroundService
    {
        private readonly IElasticClient _client;
        private CrontabSchedule _schedule;
        private DateTime _nextRun;
        private readonly IServiceScopeFactory _scopeFactory;


        private string Schedule => "*/30 * * * * *"; //Runs every 30 seconds

        public MyTestHostedService(IElasticClient client, IServiceScopeFactory scopeFactory)
        {
            _schedule = CrontabSchedule.Parse(Schedule, new CrontabSchedule.ParseOptions { IncludingSeconds = true });
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
            _client = client;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.Now;
                var nextrun = _schedule.GetNextOccurrence(now);
                if (now > _nextRun)
                {
                    await Process();
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
                }
                await Task.Delay(5000, stoppingToken); //5 seconds delay
            }
            while (!stoppingToken.IsCancellationRequested);
        }

        private async Task Process()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                Debug.Write("Insert elastic Project - Loading ...");
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                _client.DeleteByQuery<Project>(q => q.MatchAll());

                var projects = await dbContext.Projects.ToListAsync();

                foreach (var project in projects)
                {
                    await _client.IndexDocumentAsync(project);
                }
            }
        }
    }
}
