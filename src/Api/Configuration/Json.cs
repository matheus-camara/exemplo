using Core.Policies;

namespace Api.Configuration;

public static class Json
{
    public static IMvcBuilder AddJsonConfiguration(this IMvcBuilder builder)
    {
        builder.AddJsonOptions(config =>
        {
            config.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
        });

        return builder;
    }
}