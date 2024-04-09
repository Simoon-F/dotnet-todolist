using System.Reflection;
using Microsoft.OpenApi.Models;

namespace TodoList.Swagger;

/// <summary>
/// Swagger扩展
/// </summary>
public static class SwaggerExtensions
{
    /// <summary>
    /// 添加自定义Swagger配置
    /// </summary>
    /// <param name="services"></param>
    public static void AddCustomSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            #region 注释展示
            
            var basePath = AppContext.BaseDirectory; // 获取当前项目的执行目录
            var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var file = Path.Combine(basePath, xmlFileName);
    
            options.IncludeXmlComments(file, true);
            
            #endregion


            #region 支持token传值
            
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description = "格式：Bearer (token)",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            
            // 添加安全要求
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference()
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new List<string>()
                }
            });

            #endregion
            
        });
    }

    /// <summary>
    /// 自定义UseSwagger
    /// </summary>
    /// <param name="app"></param>
    public static void UseCustomSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
}