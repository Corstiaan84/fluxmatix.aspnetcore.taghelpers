using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fluxmatix.AspNetCore.TagHelpers
{
    [HtmlTargetElement("img")]
    public class ResizeProxyImgTagHelper : TagHelper
    {
        [HtmlAttributeName("resize-width")]
        public String ResizeWidth { get; set; }

        [HtmlAttributeName("resize-height")]
        public String ResizeHeight { get; set; }

        [HtmlAttributeName("mask")]
        public String Mask { get; set; }

        [HtmlAttributeName("mask-trim")]
        public bool MaskTrim { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Apply())
            {
                var src = context.AllAttributes["src"].Value;
                var newSrc = $"//images.weserv.nl/?url={src}";

                if (!string.IsNullOrEmpty(ResizeWidth))
                    newSrc += $"&w={ResizeWidth}";

                if (!string.IsNullOrEmpty(ResizeHeight))
                    newSrc += $"&h={ResizeHeight}";

                if (!string.IsNullOrEmpty(Mask))
                    newSrc += $"&mask={Mask}";

                if (MaskTrim)
                    newSrc += "&mtrim";

                output.Attributes.SetAttribute("src", newSrc);
            }
        }

        bool Apply()
        {
            if (!string.IsNullOrEmpty(ResizeWidth) || !string.IsNullOrEmpty(ResizeWidth) || Mask != null)
                return true;

            return false;
        }
    }
}