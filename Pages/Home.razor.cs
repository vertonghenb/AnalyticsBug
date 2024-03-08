using BlazorApplicationInsights.Interfaces;
using BlazorApplicationInsights.Models;
using Microsoft.AspNetCore.Components;
using Serilog;

namespace AnalyticsBug.Pages;

public partial class Home
{
    [Inject] public required IApplicationInsights AppInsights { get; set; }

    protected override void OnInitialized()
    {
        Log.Information("Hello from Home");
        Log.Warning("Warning");
        Log.Error("Error");
        Log.Fatal("Fatal");
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await AppInsights.TrackEvent(new EventTelemetry { Name = "FeaturePage" });
            await AppInsights.TrackMetric(new MetricTelemetry { Name = "FeaturePage", Average = 1 });
        }
    }
}

