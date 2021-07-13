﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.TagHelpers
{
    public static class MyHTMLHelpers
    {
        public static IHtmlContent HelloWorldHTMLString(this IHtmlHelper htmlHelper)
        {
            return new HtmlString("<strong>Hello World</strong>");
        }

        public static String HelloWorldString (this IHtmlHelper htmlHelper)
        {
            return "<strong>Hello World</strong>";
        }

        public static IHtmlContent HelloWorld(this IHtmlHelper htmlHelper, string name)
        {
            var span = new TagBuilder("span");
            span.InnerHtml.Append("Hello, " + name + "!");

            var br = new TagBuilder("br") { TagRenderMode = TagRenderMode.SelfClosing };

            string result;

            using (var writer = new StringWriter())
            {
                span.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                br.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                result = writer.ToString();
            }

            return new HtmlString(result);
        }
    }
}
