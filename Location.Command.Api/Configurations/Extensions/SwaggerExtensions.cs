using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Diagnostics.CodeAnalysis;

namespace Location.Command.Api.Configurations.Extensions;

[ExcludeFromCodeCoverage]
public static class SwaggerExtensions
{
    public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder app, IConfiguration configuration, IApiVersionDescriptionProvider provider)
    {
        var useSwagger = configuration.GetValue<bool>("UseSwagger");

        if (!useSwagger)
            return app;

        return app
            .UseSwagger()
            .UseSwaggerUI(options => provider.ApiVersionDescriptions.ToList()
            .ForEach(act => options.SwaggerEndpoint($"/swagger/{act.GroupName}/swagger.json", act.GroupName.ToUpper())));
    }
}