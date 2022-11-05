﻿using Icamsystems.Identityserver.AspNetCoreConfigurator.Client;
using Microsoft.Extensions.DependencyInjection;
using ReklaTool.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews()
                // Maintain property names during serialization. See:
                // https://github.com/aspnet/Announcements/issues/194
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver 
                    = new Newtonsoft.Json.Serialization.DefaultContractResolver());
// Add Kendo UI services to the services container"
builder.Services.AddKendo();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IMsgService, HttpMsgService>();
builder.Services.AddScoped<IEndpointService, UiEndpointService>();
builder.Services.AddScoped<IRequestBuilder, RequestBuilder>();
builder.Services.AddScoped<ICacheService, ResponseCacheService>();
builder.Services.AddKeycloakAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseKeycloakAuthentication();
app.UseFrontendToken(); // Induziert am Ende den Token auf die Seite
app.UseAuthorization();

/*
#if !DEBUG
# endif
*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();