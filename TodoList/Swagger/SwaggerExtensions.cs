using System.Reflection;

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