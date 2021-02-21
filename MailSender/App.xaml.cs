﻿using System;
using MailSender.Infrastructure;
using MailSender.lib.Interfaces;
using MailSender.lib.Service;
using MailSender.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MailSender
{
    public partial class App
    {
        private static IHost __hosting;

        public static IHost Hosting => __hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(opt => opt.AddJsonFile("appsettings.json", false, true))
            .ConfigureServices(ConfigureServices);

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<StatisticsViewModel>();

            services.AddSingleton<ServersRepository>();
            services.AddSingleton<SendersRepository>();
            services.AddSingleton<ReceiversRepository>();
            services.AddSingleton<MessagesRepository>();

            services.AddSingleton<IStatistics, InMemoryStatisticsService>();
            services.AddSingleton<IMailSender, DebugMailService>();
        }
    }
}
