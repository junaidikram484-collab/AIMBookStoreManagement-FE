using Blazored.LocalStorage;
using FEBookStoreManagement.Data;
using FEBookStoreManagement.Utilities;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// 1. Add authorization services
builder.Services.AddAuthorizationCore();

// 2. Register Blazored.LocalStorage (or your preferred storage)
builder.Services.AddBlazoredLocalStorage();

// 3. Register your custom AuthenticationStateProvider
// The framework will use this implementation
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationServiceProvider>();
builder.Services.AddHttpContextAccessor();

// Use this insecure handler only for development and testing.
// DO NOT use this in production.
if (builder.Environment.IsDevelopment())
{
    // Create the insecure handler for development only
    var handler = new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    };

    // Create options and set both the endpoint and the custom handler
    var options = new GraphQLHttpClientOptions
    {
        EndPoint = new Uri("https://localhost:7124/graphql/"),
        HttpMessageHandler = handler
    };

    // Create the GraphQL client with the options and serializer
    builder.Services.AddSingleton(new GraphQLHttpClient(options, new NewtonsoftJsonSerializer()));
}
else
{
    // Production configuration with standard HttpClient validation
    builder.Services.AddSingleton<IGraphQLClient>(_ =>
        new GraphQLHttpClient("https://your-production-endpoint.com/graphql", new NewtonsoftJsonSerializer()));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();