using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

public class TokenMiddleware : IMiddleware
{
    private readonly ILogger<TokenMiddleware> _logger;
    private readonly IConfiguration _configuration;

    public TokenMiddleware(ILogger<TokenMiddleware> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return;
        }

        var authorizationHeader = context.Request.Headers["Authorization"].ToString();
        if (!authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return;
        }

        var token = authorizationHeader.Substring("Bearer ".Length).Trim();
        if (string.IsNullOrEmpty(token))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return;
        }

        try
        {
            var handler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]))
            };

            var claimsPrincipal = handler.ValidateToken(token, validationParameters, out var validatedToken);
            if (!Guid.TryParse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            // Add the user ID to the request context for use in subsequent middleware
            context.Items["UserId"] = userId;

            await next(context);
        }
        catch (SecurityTokenException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return;
        }
    }
}
