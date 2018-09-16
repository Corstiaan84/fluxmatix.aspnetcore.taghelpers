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
            output.TagName = "";

            var attrStr = "";

            foreach(var attr in context.AllAttributes)
            {
                if(attr.Name != "asp-for" || attr.Name == "id")
                    attrStr += attr.Name + $"=\"{attr.Value}\" ";
            }

            var id = "quilleditor";

            if (context.AllAttributes.ContainsName("id"))
            {
                id = context.AllAttributes["id"].Value.ToString();
            }

            attrStr += $"id=\"{id}\"";

            var value = "";

            if(Content.Model != null)
            {
                value = WebUtility.HtmlEncode(Content.Model.ToString());
            }

            output.Content.AppendHtmlLine($"<div {attrStr}></div>");
            output.Content.AppendHtmlLine($"<input type=\"hidden\" id=\"{id}-buffer\" name=\"{Content.Name}\" value=\"{value}\" />");
        }
    }
}