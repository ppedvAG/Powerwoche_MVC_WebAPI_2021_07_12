#pragma checksum "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\RazorSamples\HTMLTagHelperSample.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "820a0c407059473ef88fde11ebc4b4eeda21ce3a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RazorSamples_HTMLTagHelperSample), @"mvc.1.0.view", @"/Views/RazorSamples/HTMLTagHelperSample.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\_ViewImports.cshtml"
using ASPNETCOREMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\_ViewImports.cshtml"
using ASPNETCOREMVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\RazorSamples\HTMLTagHelperSample.cshtml"
using ASPNETCOREMVC.TagHelpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"820a0c407059473ef88fde11ebc4b4eeda21ce3a", @"/Views/RazorSamples/HTMLTagHelperSample.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49070ca63c06389e2b2840af86ef89c4ea528cd8", @"/Views/_ViewImports.cshtml")]
    public class Views_RazorSamples_HTMLTagHelperSample : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\RazorSamples\HTMLTagHelperSample.cshtml"
  
    ViewData["Title"] = "HTMLTagHelperSample";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>HTMLTagHelperSample</h1>\r\n\r\n");
#nullable restore
#line 10 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\RazorSamples\HTMLTagHelperSample.cshtml"
Write(Html.HelloWorld("Kevin"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 12 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\RazorSamples\HTMLTagHelperSample.cshtml"
Write(Html.HelloWorldHTMLString());

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n\r\n");
#nullable restore
#line 14 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\RazorSamples\HTMLTagHelperSample.cshtml"
Write(Html.HelloWorldString());

#line default
#line hidden
#nullable disable
            WriteLiteral(";");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
