using System;
namespace Fluxmatix.AspNetCore.TagHelpers.QuillEditor
{
    public class QuillEditorOptions
    {
        public string RequestPath { get; set; } = "Fluxmatix.AspNetCore.TagHelpers.QuillEditor.wwwroot";
        public string Theme { get; set; } = "snow";
        public bool EnableSyntaxHighLighting { get; set; } = true;
        public string SyntaxHighLightTheme { get; set; } = "default";
        public string[] SyntaxHighLightLanguages { get; set; } = { "cs", "javascript", "html", "css", "json", "markdown", "php", "python", "ruby", "sql", "xml" };
    }
}