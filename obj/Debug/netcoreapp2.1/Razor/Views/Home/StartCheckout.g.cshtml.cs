#pragma checksum "/home/mehmet/project/dotnet/Dietcore/Views/Home/StartCheckout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9cd6bbff000f5e3ea7d7a6657317db00bbbbc960"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_StartCheckout), @"mvc.1.0.view", @"/Views/Home/StartCheckout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/StartCheckout.cshtml", typeof(AspNetCore.Views_Home_StartCheckout))]
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
#line 1 "/home/mehmet/project/dotnet/Dietcore/Views/_ViewImports.cshtml"
using Dietcore;

#line default
#line hidden
#line 2 "/home/mehmet/project/dotnet/Dietcore/Views/_ViewImports.cshtml"
using Dietcore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cd6bbff000f5e3ea7d7a6657317db00bbbbc960", @"/Views/Home/StartCheckout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa3fc75ec92efd793b714d0dba710451dea1e00d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_StartCheckout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(1, 31, false);
#line 1 "/home/mehmet/project/dotnet/Dietcore/Views/Home/StartCheckout.cshtml"
Write(Html.Raw(@ViewData["Checkout"]));

#line default
#line hidden
            EndContext();
            BeginContext(32, 54, true);
            WriteLiteral("\n\n<div id=\"iyzipay-checkout-form\" class=\"popup\"></div>");
            EndContext();
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