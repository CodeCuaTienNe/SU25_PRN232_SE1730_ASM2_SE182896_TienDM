using DNATestingSystem.BlazorWAS.GraphQLClients.TienDM;
using DNATestingSystem.BlazorWAS.GraphQLClients.TienDM.GraphQLClient;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//graphQL
builder.Services.AddScoped<IGraphQLClient>(serviceProvider =>
{
    var httpClient = new HttpClient();
    var graphQLEndpoint = builder.Configuration["GraphQLURI"] ?? "https://localhost:7286/graphql/";
    var graphQLClient = new GraphQLHttpClient(graphQLEndpoint, new NewtonsoftJsonSerializer(), httpClient);

    // Add default headers if needed
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

    return graphQLClient;
});
builder.Services.AddScoped<GraphQLConsumer>();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// Đăng ký AuthService
builder.Services.AddScoped<DNATestingSystem.BlazorWAS.GraphQLClients.TienDM.Services.AuthService>();

await builder.Build().RunAsync();
