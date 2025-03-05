using ComponentLibrary;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;



#if LOGGING
using Serilog;
using Serilog.Events;

const string _customTemplate = "{Timestamp:HH:mm:ss.fff}\t[{Level:u3}]\t{Message}{NewLine}{Exception}";

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Async(a => a.Console(outputTemplate: _customTemplate))
    .CreateLogger();
#endif

try
{
#if LOGGING
    Log.Information("Starting Blazor Website.Server");
#endif
    var builder = WebApplication.CreateBuilder(args);

#if LOGGING
    builder.Host.UseSerilog();
#endif

    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

#if LOGGING
    app.UseSerilogRequestLogging();
#endif

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/Host");

    app.Run();
}
#if LOGGING
catch (Exception ex)
{
    Log.Fatal(ex, "Blazor Website.Server terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
#else
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
#endif
