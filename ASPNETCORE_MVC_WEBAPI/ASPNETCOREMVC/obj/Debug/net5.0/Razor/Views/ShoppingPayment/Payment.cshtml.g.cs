#pragma checksum "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\ShoppingPayment\Payment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fcf507d417e8cfe41604d071f111153b132a8bce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShoppingPayment_Payment), @"mvc.1.0.view", @"/Views/ShoppingPayment/Payment.cshtml")]
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
#line 1 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\ShoppingPayment\Payment.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fcf507d417e8cfe41604d071f111153b132a8bce", @"/Views/ShoppingPayment/Payment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49070ca63c06389e2b2840af86ef89c4ea528cd8", @"/Views/_ViewImports.cshtml")]
    public class Views_ShoppingPayment_Payment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\ShoppingPayment\Payment.cshtml"
  
    ViewData["Title"] = "Payment";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Payment</h1>\r\n");
#nullable restore
#line 10 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\ShoppingPayment\Payment.cshtml"
 if (SignInManager.IsSignedIn(User))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <ul>\r\n        <li>Paypal</li>\r\n        <li>SofortÜberweisung</li>\r\n    </ul>\r\n");
#nullable restore
#line 16 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\ShoppingPayment\Payment.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h5>Bitte regisitrieren Sie sich!</h5>\r\n");
#nullable restore
#line 20 "C:\Aktueller Kurs\Powerwoche_MVC_WebAPI_2021_07_12\ASPNETCORE_MVC_WEBAPI\ASPNETCOREMVC\Views\ShoppingPayment\Payment.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
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