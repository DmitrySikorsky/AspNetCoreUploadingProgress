// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreFileUploading {
    public class Startup {
        // This is not the best idea to use a static variable (especially when you have more than one active uploading session at the same time)
        public static int Progress { get; set; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            {
               if (env.IsDevelopment()) {
                    app.UseDeveloperExceptionPage();                    
                } else {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }
                app.UseStaticFiles();
                app.UseDeveloperExceptionPage();
                app.UseRouting();
                app.UseEndpoints(endpoints => {
                    endpoints.MapControllerRoute(
                        "default",
                        "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
                });
            }
        }
    }
        
    }