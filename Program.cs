using Spice_n_Booster_Gobler.Launch;
using Spice_n_Booster_Gobler.Util;
using Microsoft.Extensions.DependencyInjection;
using Spice_n_Booster_Gobler.Locomote;
using Spice_n_Booster_Gobler.Map;
using Spice_n_Booster_Gobler.Models;


class Program
{
    static void Main(string[] args)
    {
        // Create a service collection
        var services = new ServiceCollection();

        // Register your services
        services.AddSingleton<IGlobal_Vals, Global_Vals>();
        services.AddScoped<IBegin, Begin>();
        services.AddScoped<ILogger, Logger>();
        services.AddScoped<IMove_Caterpillar, Move_Caterpillar>();
        services.AddScoped<ICollect_Next_Direction, Collect_Next_Direction>();
        services.AddScoped<IMap_Co_ordinates, Map_Co_ordinates>();
        services.AddScoped<IRadar_Scope, Radar_Scope>();
        services.AddScoped<IDisplayRadarMap, DisplayRadarMap>();
        services.AddScoped<IUpdateMap, UpdateMap>();
        services.AddScoped<IForward_Command, Forward_Command>();
        services.AddScoped<IReverse_Command, Reverse_Command>();
        services.AddScoped<IDefaultMap, DefaultMap>();
        services.AddScoped<IModify_Segment_Position, Modify_Segment_Position>();
        services.AddScoped<ISegmentsCollection, SegmentsCollection>();
        services.AddScoped<INavigate, Navigate>();
        services.AddScoped<IResourceCollection, ResourceCollection>();
        services.AddScoped<ISectionPositionCorrecter, SectionPositionCorrecter>();
        services.AddScoped<IImportMap, ImportMap>();
        services.AddScoped<IMapSettings, MapSettings>();

        // Build the service provider
        var serviceProvider = services.BuildServiceProvider();

        // Resolve the service
        //var globalVals = serviceProvider.GetRequiredService<IGlobal_Vals>();
        var home = serviceProvider.GetRequiredService<IBegin>();

        home.Lets_Begin();

        //new Begin(globalVals).Lets_Catch_Them_All();
    }
}