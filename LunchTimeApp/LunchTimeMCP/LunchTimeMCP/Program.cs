using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;

var builder = Host.CreateEmptyApplicationBuilder(settings: null);

builder.Services
	.AddMcpServer()
	.WithStdioServerTransport();

await builder.Build().RunAsync();
