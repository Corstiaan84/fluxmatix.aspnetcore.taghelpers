using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fluxmatix.AspNetCore.TagHelpers.QuillEditor
{
    [HtmlTargetElement("quill-editor-script")]
    public class QuillEditorScriptTagHelper : TagHelper
    {
        QuillEditorOptions _options;

        public QuillEditorScriptTagHelper(QuillEditorOptions options)
        {
            _options = options;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "script";
            output.Attributes.Add("src", "/" + _options.RequestPath + "/node_modules/quill/dist/quill.min.js");
        }
    }
}
