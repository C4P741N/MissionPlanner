using Spice_n_Booster_Gobler.Launch;
using Spice_n_Booster_Gobler.Util;
using Microsoft.Extensions.DependencyInjection;
using Spice_n_Booster_Gobler.Locomote;
using Spice_n_Booster_Gobler.Map;


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

        // Build the service provider
        var serviceProvider = services.BuildServiceProvider();

        // Resolve the service
        //var globalVals = serviceProvider.GetRequiredService<IGlobal_Vals>();
        var home = serviceProvider.GetRequiredService<IBegin>();

        home.Lets_Catch_Them_All();

        //new Begin(globalVals).Lets_Catch_Them_All();
    }
}