using PraticalApps;

// Sostituita tutta la configurazione originale con la chiamata al nostro file
Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    }).Build().Run();

Console.WriteLine("Thisexecute after the web server has stopped");