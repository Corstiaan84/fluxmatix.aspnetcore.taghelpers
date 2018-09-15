using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Fluxmatix.AspNetCore.TagHelpers.QuillEditor
{
    public static class QuillEditorExtensions
    {
        public static IServiceCollection AddQuillEditor(this IServiceCollection services, Action<QuillEditorOptions> options = null)
        {
            var optionsObj = new QuillEditorOptions();

            if (options != null)
                options.Invoke(optionsObj);

            services.AddSingleton(optionsObj);

            return services;
        }

        public static IApplicationBuilder UseQuillEditor(this IApplicationBuilder builder)
        {
            var options = builder.ApplicationServices.GetService<QuillEditorOptions>();

            var quillEditorAssembly = typeof(QuillEditorTagHelper).GetTypeInfo().Assembly;
            var quillEditorEmbeddedFileProvider = new EmbeddedFileProvider(
                quillEditorAssembly,
                "Fluxmatix.AspNetCore.TagHelpers.QuillEditor"
            );

            builder.UseStaticFiles();
            builder.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = quillEditorEmbeddedFileProvider,
                RequestPath = new PathString("/" + options.RequestPath)
            });

            return builder;
        }
    }
}