using System;
using System.Linq;
using Microsoft.AspNetCore.Html;
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
            output.TagName = "";

            if (_options.EnableSyntaxHighLighting)
                output.Content.AppendHtmlLine($"<script src=\"/" + _options.RequestPath + "/node_modules/highlightjs/highlight.pack.min.js\"></script>");
                
            output.Content.AppendHtmlLine($"<script src=\"/" + _options.RequestPath + "/node_modules/quill/dist/quill.min.js\"></script>");

            var ids = new string[] { "quilleditor" };

            if (context.AllAttributes.ContainsName("for-editors"))
            {
                ids = context.AllAttributes["for-editors"].Value.ToString().Split(",");
            }

            var initScripts = "";

            foreach(var id in ids)
            {
                initScripts += string.Format(initScriptTemplate,
                                             id,
                                             _options.EnableSyntaxHighLighting.ToString().ToLower(),
                                             _options.Theme
                                            ) + Environment.NewLine;
            }

            var syntaxConfigScript = "";

            if(_options.EnableSyntaxHighLighting)
            {
                var languages = "'" + string.Join(", ", _options.SyntaxHighLightLanguages)
                                            .Replace(", ", "', '") + "'";

                syntaxConfigScript = string.Format(syntaxConfigTemplate, languages);
            }

            var baseScript = string.Format(baseScriptTemplate, syntaxConfigScript, initScripts);
            output.Content.AppendHtmlLine(baseScript);
        }

        string baseScriptTemplate = @"
        <script>
            (function() {{

                {0}

                var toolbarOptions = [
                  ['bold', 'italic', 'underline', 'strike'],
                  ['blockquote', 'code-block'],

                  [{{ 'header': 1 }}, {{ 'header': 2 }}],
                  [{{ 'list': 'ordered'}}, {{ 'list': 'bullet' }}],
                  [{{ 'script': 'sub'}}, {{ 'script': 'super' }}],
                  [{{ 'indent': '-1'}}, {{ 'indent': '+1' }}],
                  [{{ 'direction': 'rtl' }}],

                  [{{ 'size': ['small', false, 'large', 'huge'] }}],
                  [{{ 'header': [1, 2, 3, 4, 5, 6, false] }}],

                  [{{ 'color': [] }}, {{ 'background': [] }}],
                  [{{ 'font': [] }}],
                  [{{ 'align': [] }}],

                  ['clean']
                ];

                {1}
            }})();
        </script>";

        string initScriptTemplate = @"
        if(document.getElementById('{0}'))
        {{
            var {0} = new Quill('#{0}', {{
              modules: {{
                toolbar: toolbarOptions,
                syntax: {1}
              }},
              placeholder: 'Itsa me! Mario!',
              theme: '{2}'
            }});

            {0}.root.innerHTML = document.getElementById('{0}-buffer').value;

            {0}.on('text-change', function(delta)
            {{
                document.getElementById('{0}-buffer').value = {0}.root.innerHTML;
            }});
        }}";

        string syntaxConfigTemplate = @"
        hljs.configure({{
            languages: [{0}],
            useBR: false
        }});
        
        var blocks = document.querySelectorAll('.ql-syntax');

        for (i = 0; i < blocks.length; i++) {{
            hljs.highlightBlock(blocks[i]);
        }}";
    }
}
