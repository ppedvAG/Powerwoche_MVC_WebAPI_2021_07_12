#pragma checksum "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\Demo\Sample1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "338ba60d0df8bd2df4bc38752b19c73bf9fbde44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Demo_Sample1), @"mvc.1.0.view", @"/Views/Demo/Sample1.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"338ba60d0df8bd2df4bc38752b19c73bf9fbde44", @"/Views/Demo/Sample1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a78727764f6c6a989b69cc3a4f5c8e1d91b161e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Demo_Sample1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DependencyInversionSample.MockCar>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\Demo\Sample1.cshtml"
  
    ViewData["Title"] = "Sample1";
    //Layout = "_Layout"; // Expliziete Zuweisung 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Sample1</h1>\r\n\r\n<p>Id: ");
#nullable restore
#line 9 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\Demo\Sample1.cshtml"
  Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Marke: ");
#nullable restore
#line 10 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\Demo\Sample1.cshtml"
     Write(Model.Marke);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Modell: ");
#nullable restore
#line 11 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\Demo\Sample1.cshtml"
      Write(Model.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>Erbaut: ");
#nullable restore
#line 12 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\Demo\Sample1.cshtml"
      Write(Model.ConstructionYear.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral(";</p>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DependencyInversionSample.MockCar> Html { get; private set; }
    }
}
#pragma warning restore 1591
