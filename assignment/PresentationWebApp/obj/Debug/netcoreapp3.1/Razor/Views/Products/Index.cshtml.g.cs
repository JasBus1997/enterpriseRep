#pragma checksum "C:\Users\jasmi\Desktop\school notes\Level 6\second year\Enterprise Programming\enterpriseRep\assignment\PresentationWebApp\Views\Products\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1493270f80ba28b41f9eba6ac8c73e836900ba38"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Index), @"mvc.1.0.view", @"/Views/Products/Index.cshtml")]
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
#line 1 "C:\Users\jasmi\Desktop\school notes\Level 6\second year\Enterprise Programming\enterpriseRep\assignment\PresentationWebApp\Views\_ViewImports.cshtml"
using PresentationWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jasmi\Desktop\school notes\Level 6\second year\Enterprise Programming\enterpriseRep\assignment\PresentationWebApp\Views\_ViewImports.cshtml"
using PresentationWebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1493270f80ba28b41f9eba6ac8c73e836900ba38", @"/Views/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d37c9bc11724120768bc51102823a04d56debf5", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ShoppingCart.Application.ViewModels.ProductViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\jasmi\Desktop\school notes\Level 6\second year\Enterprise Programming\enterpriseRep\assignment\PresentationWebApp\Views\Products\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Product Catalogue</h1>\r\n\r\n\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 11 "C:\Users\jasmi\Desktop\school notes\Level 6\second year\Enterprise Programming\enterpriseRep\assignment\PresentationWebApp\Views\Products\Index.cshtml"
         foreach (var p in Model)
         {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-4\">\r\n                <div class=\"card\" style=\"width: 18rem;\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 360, "\"", 377, 1);
#nullable restore
#line 15 "C:\Users\jasmi\Desktop\school notes\Level 6\second year\Enterprise Programming\enterpriseRep\assignment\PresentationWebApp\Views\Products\Index.cshtml"
WriteAttributeValue("", 366, p.ImageUrl, 366, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("class=\"card-img-top\" alt=\"..\">\r\n                    <div class=\"card-body\">\r\n                        <h5 class=\"card-title\">");
#nullable restore
#line 17 "C:\Users\jasmi\Desktop\school notes\Level 6\second year\Enterprise Programming\enterpriseRep\assignment\PresentationWebApp\Views\Products\Index.cshtml"
                                          Write(p.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        <p class=\"card-text\">");
#nullable restore
#line 18 "C:\Users\jasmi\Desktop\school notes\Level 6\second year\Enterprise Programming\enterpriseRep\assignment\PresentationWebApp\Views\Products\Index.cshtml"
                                        Write(p.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 601, "\"", 634, 2);
            WriteAttributeValue("", 608, "/Products/Details?id=", 608, 21, true);
#nullable restore
#line 19 "C:\Users\jasmi\Desktop\school notes\Level 6\second year\Enterprise Programming\enterpriseRep\assignment\PresentationWebApp\Views\Products\Index.cshtml"
WriteAttributeValue("", 629, p.Id, 629, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">View Specification</a>\r\n                    </div>\r\n                </div>\r\n            </div>            \r\n");
#nullable restore
#line 23 "C:\Users\jasmi\Desktop\school notes\Level 6\second year\Enterprise Programming\enterpriseRep\assignment\PresentationWebApp\Views\Products\Index.cshtml"
         }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ShoppingCart.Application.ViewModels.ProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
