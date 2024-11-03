using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DRR.Configurations.Authentication;
using DRR.Framework.Contracts.Common.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;


namespace DRR.Configurations.Swagger
{
    public static class SwaggerExtension
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("DRR", new OpenApiInfo { Title = "DRR.Host - V1", Version = "Host" });

                //TODO : Should Add
                #region XML-Settings
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
                //c.SchemaFilter<EnumTypesSchemaFilter>(xmlPath);
                //c.DocumentFilter<EnumTypesDocumentFilter>();
                #endregion

                c.SchemaFilter<EnumSchemaFilter>();
                c.OperationFilter<IgnorePropertyFilter>();
                c.OperationFilter<AddRequiredHeaderParameterOperationFilter>();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

            });
            //services.AddSwaggerGenNewtonsoftSupport();
        }

        public static void SwaggerConfigure(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/DRR/swagger.json", "DRR.Host - V1");
                c.DocExpansion(DocExpansion.None);
                c.EnableFilter();
            });
        }

    }

    public class AddRequiredHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "language",
                In = ParameterLocation.Header,
                Description = "language",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "int",
                    Default = new OpenApiInteger((int)ContentLanguage.Persian)
                }
            });
        }
    }

    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema model, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                model.Enum.Clear();
                Enum.GetNames(context.Type)
                    .ToList()
                    .ForEach(name => model.Enum.Add(
                        new OpenApiString($"{Convert.ToInt64(Enum.Parse(context.Type, name))} - {name} - {GetDescription(name, context.Type)}")));
            }
        }

        private string GetDescription(string name, Type type)
        {
            return GetEnumDescription(Enum.Parse(type, name));
        }

        private string GetEnumDescription(object value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : null;
        }
    }

    public class EnumTypesSchemaFilter : ISchemaFilter
    {
        private readonly XDocument _xmlComments;

        public EnumTypesSchemaFilter(string xmlPath)
        {
            if (File.Exists(xmlPath))
            {
                _xmlComments = XDocument.Load(xmlPath);
            }
        }

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (_xmlComments == null) return;

            if (schema.Enum != null && schema.Enum.Count > 0 &&
                context.Type != null && context.Type.IsEnum)
            {
                schema.Description += "<p>Members:</p><ul>";

                var fullTypeName = context.Type.FullName;

                foreach (var enumMemberName in schema.Enum.OfType<OpenApiString>().
                         Select(v => v.Value))
                {
                    var fullEnumMemberName = $"F:{fullTypeName}.{enumMemberName}";

                    var enumMemberComments = _xmlComments.Descendants("member")
                        .FirstOrDefault(m => m.Attribute("name").Value.Equals
                        (fullEnumMemberName, StringComparison.OrdinalIgnoreCase));

                    if (enumMemberComments == null) continue;

                    var summary = enumMemberComments.Descendants("summary").FirstOrDefault();

                    if (summary == null) continue;

                    schema.Description += @$"<li><i>{enumMemberName}</i> - 
                                          { summary.Value.Trim()}</ li > ";
                }

                schema.Description += "</ul>";
            }
        }
    }

    public class EnumTypesDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var path in swaggerDoc.Paths.Values)
            {
                foreach (var operation in path.Operations.Values)
                {
                    foreach (var parameter in operation.Parameters)
                    {
                        var schemaReferenceId = parameter.Schema.Reference?.Id;

                        if (string.IsNullOrEmpty(schemaReferenceId)) continue;

                        var schema = context.SchemaRepository.Schemas[schemaReferenceId];

                        //if (schema.Enum.IsNullOrEmptyExtension()) continue;

                        parameter.Description += "<p>Variants:</p>";

                        int cutStart = schema.Description.IndexOf("<ul>");

                        int cutEnd = schema.Description.IndexOf("</ul>") + 5;

                        parameter.Description += schema.Description
                            .Substring(cutStart, cutEnd - cutStart);
                    }
                }
            }
        }
    }
}

