namespace DeveloperTest.WebApi.Setup;

[ExcludeFromCodeCoverage]
public static class AddAuthentication
{
    public static AuthenticationBuilder AddAuthenticationBuilder(
       this IServiceCollection serviceCollection,
       IConfiguration configuration)
    {
        byte[] publicKeyBytes = Convert.FromBase64String(configuration.GetSection("JwtSecret").Value);
        RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)PublicKeyFactory.CreateKey(publicKeyBytes);
        RSAParameters rsaParameters = new RSAParameters
        {
            Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned(),
            Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned(),
        };

        return serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration.GetSection("JwtIssuer").Value,
                ValidAudiences = configuration.GetSection("JwtAudience").Value.Split(" "),
                IssuerSigningKey = new RsaSecurityKey(rsaParameters),
            };

            x.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("Token-Expired", "true");
                    }

                    return Task.CompletedTask;
                },
            };
        });
    }
}
