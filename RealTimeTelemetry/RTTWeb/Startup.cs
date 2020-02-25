using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RTTWeb.Data;
using RTTWeb.Data.ViewModels;

namespace RTTWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var IOTSettingsConfig = Configuration.GetSection("IOTConnectionStrings");
            string s_eventHubsCompatibleEndpoint = IOTSettingsConfig["s_eventHubsCompatibleEndpoint"];
            string s_eventHubsCompatiblePath = IOTSettingsConfig["s_eventHubsCompatiblePath"];
            string s_iotHubSasKeyName = IOTSettingsConfig["s_iotHubSasKeyName"] ;
            string s_iotHubSasKey = IOTSettingsConfig["s_iotHubSasKey"];

            var telemService = new TelemetryService(s_eventHubsCompatibleEndpoint, s_eventHubsCompatiblePath, s_iotHubSasKeyName, s_iotHubSasKey);

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<TelemetryService>(telemService);
            services.AddSingleton<VehicleRPMVM>(new VehicleRPMVM(telemService));
            services.AddSingleton<AcceleratorPositionVM>(new AcceleratorPositionVM(telemService));
            services.AddSingleton<BrakeActiveVM>(new BrakeActiveVM(telemService));
            services.AddSingleton<EngineTemperatureVM>(new EngineTemperatureVM(telemService));
            services.AddSingleton<GearActiveVM>(new GearActiveVM(telemService));
            services.AddSingleton<SteeringPositionVM>(new SteeringPositionVM(telemService));
            services.AddSingleton<VehicleSpeedVM>(new VehicleSpeedVM(telemService));
            services.AddSingleton<WheelSpeedVM>(new WheelSpeedVM(telemService));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
