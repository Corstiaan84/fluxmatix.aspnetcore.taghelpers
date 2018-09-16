using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fluxmatix.AspNetCore.TagHelpers.QuillEditor
{
    [HtmlTargetElement("quill-editor-style-sheets")]
    public class QuillEditorStyleSheetsTagHelper : TagHelper
    {
        QuillEditorOptions _options;

        public QuillEditorStyleSheetsTagHelper(QuillEditorOptions options)
        {
            _options = options;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "";
            output.Content.AppendHtmlLine($"<link rel='stylesheet' href='/{_options.RequestPath}/node_modules/quill/dist/quill.core.css' />");

            if(_options.Theme == "snow")
                output.Content.AppendHtmlLine($"<link rel='stylesheet' href='/{_options.RequestPath}/node_modules/quill/dist/quill.snow.css' />");

            if(_options.Theme == "bubble")
                output.Content.AppendHtmlLine($"<link rel='stylesheet' href='/{_options.RequestPath}/node_modules/quill/dist/quill.bubble.css' />");

            if(_options.EnableSyntaxHighLighting)
                output.Content.AppendHtmlLine($"<link rel='stylesheet' href='/{_options.RequestPath}/node_modules/highlightjs/styles/{_options.SyntaxHighLightTheme}.css' />");
        }
    }
}