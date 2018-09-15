using System;
using System.Net;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fluxmatix.AspNetCore.TagHelpers.QuillEditor
{
    [HtmlTargetElement("quill-editor")]
    public class QuillEditorTagHelper : TagHelper
    {
        QuillEditorOptions _options;

        [HtmlAttributeName("asp-for")]
        public ModelExpression Content { get; set; }

        public QuillEditorTagHelper(QuillEditorOptions options)
        {
            _options = options;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(Content.Model != null)
            {
                output.TagName = "";

                var attrStr = "";

                foreach(var attr in context.AllAttributes)
                {
                    if(attr.Name != "asp-for")
                        attrStr += attr.Name + $"=\"{attr.Value}\" ";
                }

                output.Content.AppendHtmlLine($"<div id=\"quill-editor\" {attrStr}></div>");
                output.Content.AppendHtmlLine($"<input type=\"hidden\" id=\"quill-editor-buffer\" name=\"{Content.Name}\" value=\"{WebUtility.HtmlEncode(Content.Model.ToString())}\" />");
            }
        }
    }
}