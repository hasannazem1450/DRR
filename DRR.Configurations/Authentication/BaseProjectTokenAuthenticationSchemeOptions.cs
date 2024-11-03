using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

namespace DRR.Configurations.Authentication
{
    public class BaseProjectTokenAuthenticationSchemeOptions : AuthenticationSchemeOptions
    {
        public const string SchemeName = "DRR";
        public const string CustomToken = "BaseProjectToken";
        /// <summary>
        /// Generates the swagger custom token security scheme object
        /// </summary>
        /// <returns>The swagger custom token security scheme</returns>
        public static OpenApiSecurityScheme GetSwaggerCustomTokenApiSecurityScheme()
        {
            var scheme = new OpenApiSecurityScheme
            {
                Name = CustomToken,
                Type = SecuritySchemeType.ApiKey,
                Scheme = SchemeName,
                In = ParameterLocation.Header,
                Description = "DRR Token Authorization Header.\r\n\r\n Example: \"BaseProjectToken : 123456\""
            };
            return scheme;
        }

        /// <summary>
        /// Generates the swagger security scheme object
        /// </summary>
        /// <returns>The swagger security scheme</returns>
        public static OpenApiSecurityRequirement GetSwaggerCustomTokenSecurityRequirement()
        {
            var req = new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme()
                    {
                        Reference = new OpenApiReference()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = SchemeName
                        }
                    },
                    new string[] {}
                }
            };
            return req;
        }
    }
}
