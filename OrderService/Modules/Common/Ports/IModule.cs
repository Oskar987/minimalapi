namespace OrderService.Modules.Common.Ports;

public interface IModule
{
    IServiceCollection RegisterModule(IServiceCollection builder, IConfiguration configuration, bool isProduction);
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder edpoints);
}