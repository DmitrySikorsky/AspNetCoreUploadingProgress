// Copyright © 2017 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreFileUploading
{
  public class Startup
  {
    // This is not the best idea to use a static variable (especially when you have more than one active uploading session at the same time)
    public static int Progress { get; set; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    }

    public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
    {
      applicationBuilder.UseStaticFiles();

      if (hostingEnvironment.IsDevelopment())
      {
        applicationBuilder.UseDeveloperExceptionPage();
        applicationBuilder.UseBrowserLink();
      }

      applicationBuilder.UseMvcWithDefaultRoute();
    }
  }
}