namespace TodoMinApi.MinApi.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static void AddSerilog(this ConfigureHostBuilder host)
        {
            //host.UseSerilog();

            //Log.Logger = new LoggerConfiguration()
            //    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //    .Enrich.FromLogContext()
            //    .WriteTo.Console()
            //    .CreateLogger();

            //https://thecodeblogger.com/2021/05/14/overview-of-logging-providers-available-in-net/
            //https://thecodeblogger.com/2022/09/24/net-7-minimal-apis-with-serilog-logging-providers/
        }
    }
}
