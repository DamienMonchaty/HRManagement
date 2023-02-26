using HRManagement.Web.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Web.Extensions
{
    public static class ElasticSearchExtensions
    {
        public static void AddElasticsearch(this IServiceCollection services, IConfiguration configuration)
        {
            var url = configuration["elasticsearch:url"];
            var defaultIndex = configuration["elasticsearch:index"];

            var settings = new ConnectionSettings(new Uri(url))
                .DefaultIndex(defaultIndex)
                .DefaultMappingFor<User>(j => j.IndexName("users").IdProperty(f => f.Id))
                .OnRequestCompleted(callDetails =>
                {
                    if (callDetails.RequestBodyInBytes != null)
                    {
                        Console.WriteLine(
                            $"{callDetails.HttpMethod} {callDetails.Uri} \n" +
                            $"{Encoding.UTF8.GetString(callDetails.RequestBodyInBytes)}");
                    }
                    else
                    {
                        Console.WriteLine($"{callDetails.HttpMethod} {callDetails.Uri}");
                    }

                    Console.WriteLine();

                    if (callDetails.ResponseBodyInBytes != null)
                    {
                        Console.WriteLine($"Status: {callDetails.HttpStatusCode}\n" +
                                 $"{Encoding.UTF8.GetString(callDetails.ResponseBodyInBytes)}\n" +
                                 $"{new string('-', 30)}\n");
                    }
                    else
                    {
                        Console.WriteLine($"Status: {callDetails.HttpStatusCode}\n" +
                                 $"{new string('-', 30)}\n");
                    }
                });

            AddDefaultMappings(settings);

            var client = new ElasticClient(settings);

            services.AddSingleton<IElasticClient>(client);

            CreateIndex(client, defaultIndex);
            CreateIndex2(client, "users");
        }

        private static void AddDefaultMappings(ConnectionSettings settings)
        {
            settings.DefaultMappingFor<Project>(m => m

            );

        }

        private static void CreateIndex(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName,
                index => index.Map<Project>(x => x.AutoMap())
            );
        }

        private static void CreateIndex2(IElasticClient client, string indexName)
        {
            var createIndexResponse = client.Indices.Create(indexName,
                index => index.Map<User>(x => x.AutoMap())
            );
        }
    }
}
