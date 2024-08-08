using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;

namespace Infraestructure.Security.Jwt
{
    public static class JwtConfig
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                                context.Response.StatusCode = 401;
                                context.Response.ContentType = "application/json";
                                var result = JsonConvert.SerializeObject(new { error = "Token Expired", message = "The token has expired." });
                                return context.Response.WriteAsync(result);
                            }
                            else
                            {
                                context.Response.StatusCode = 401;
                                context.Response.ContentType = "application/json";
                                var result = JsonConvert.SerializeObject(new { error = "Invalid Token", message = "The token is invalid." });
                                return context.Response.WriteAsync(result);
                            }
                        },
                        OnChallenge = context =>
                        {
                            // Si no hay token en la solicitud
                            if (!context.Request.Headers.ContainsKey("Authorization"))
                            {
                                context.HandleResponse();
                                context.Response.StatusCode = 401;
                                context.Response.ContentType = "application/json";
                                var result = JsonConvert.SerializeObject(new { error = "No Token", message = "No token was provided." });
                                return context.Response.WriteAsync(result);
                            }

                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var defaultResult = JsonConvert.SerializeObject(new { error = "Unauthorized", message = "Missing, invalid or expired token" });
                            return context.Response.WriteAsync(defaultResult);
                        }
                    };
                });
            return services;
        }

        public static IServiceCollection AddJwtPolicies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "4")); // 4: ADMIN
                options.AddPolicy("SecretaryOnly", policy => {
                    policy.RequireAssertion(context =>
                        context.User.HasClaim(ClaimTypes.Role, "4") || //ADMIN
                        context.User.HasClaim(ClaimTypes.Role, "3") // SECRETARIA
                    );
                });
                options.AddPolicy("StudenteOnly", policy => {
                    policy.RequireAssertion(context =>
                        context.User.HasClaim(ClaimTypes.Role, "4") || //ADMIN
                        context.User.HasClaim(ClaimTypes.Role, "2") // ESTUDIANTE
                    );
                });
                options.AddPolicy("DocenteOnly", policy => {
                    policy.RequireAssertion(context =>
                        context.User.HasClaim(ClaimTypes.Role, "4") || //ADMIN
                        context.User.HasClaim(ClaimTypes.Role, "3") ||// SECRETARIA
                        context.User.HasClaim(ClaimTypes.Role, "1") // DOCENTE
                    );
                });
            });

            return services;
        }
    }
}
