using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DotNetProjects.Web.Lib.AspNetCore.Blog.TagHelpers
{
    [HtmlTargetElement("img")]
    public class ResizeProxyImgTagHelper : TagHelper
    {
        [HtmlAttributeName("resize-width")]
        public String ResizeWidth { get; set; }

        [HtmlAttributeName("resize-height")]
        public String ResizeHeight { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (context.AllAttributes.ContainsName("src") && (ResizeWidth != null || ResizeHeight != null))
            {
                var src = context.AllAttributes["src"].Value;
                var newSrc = $"//images.weserv.nl/?url={src}&w={ResizeWidth}&h={ResizeHeight}";
                output.Attributes.SetAttribute("src", newSrc);
            }
        }
    }
}
