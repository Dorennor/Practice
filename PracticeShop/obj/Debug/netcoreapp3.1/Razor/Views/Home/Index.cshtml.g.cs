#pragma checksum "C:\Users\User\Source\Repos\Dorennor\Practice\PracticeShop\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37deb3cf4f3f7f33b05f119a79b696a50329c4c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\User\Source\Repos\Dorennor\Practice\PracticeShop\Views\_ViewImports.cshtml"
using PracticeShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Source\Repos\Dorennor\Practice\PracticeShop\Views\_ViewImports.cshtml"
using PracticeShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37deb3cf4f3f7f33b05f119a79b696a50329c4c3", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84b4e8dd663a897a17217eca6c2524c306b18a82", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Game>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div>
    <div>
        <p class=""TitleText"">НОВИНКИ</p>
    </div>
    <table class=""table"">
        <tr>
            <td>
                <p>Название игры</p>
            </td>
            <td>
                <p>Жанр</p>
            </td>
            <td>
                <p>Издатель</p>
            </td>
            <td>
                <p>Цена в $</p>
            </td>
        </tr>
");
#nullable restore
#line 22 "C:\Users\User\Source\Repos\Dorennor\Practice\PracticeShop\Views\Home\Index.cshtml"
         foreach (var game in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\n    <td>\n        <p>");
#nullable restore
#line 26 "C:\Users\User\Source\Repos\Dorennor\Practice\PracticeShop\Views\Home\Index.cshtml"
      Write(game.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n    </td>\n    <td>\n        <p>");
#nullable restore
#line 29 "C:\Users\User\Source\Repos\Dorennor\Practice\PracticeShop\Views\Home\Index.cshtml"
      Write(game.Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n    </td>\n    <td>\n        <p>");
#nullable restore
#line 32 "C:\Users\User\Source\Repos\Dorennor\Practice\PracticeShop\Views\Home\Index.cshtml"
      Write(game.Publisher);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n    </td>\n    <td>\n");
#nullable restore
#line 35 "C:\Users\User\Source\Repos\Dorennor\Practice\PracticeShop\Views\Home\Index.cshtml"
         if (game.Price == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<p>Бесплатно</p> ");
#nullable restore
#line 37 "C:\Users\User\Source\Repos\Dorennor\Practice\PracticeShop\Views\Home\Index.cshtml"
                 }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <p>");
#nullable restore
#line 40 "C:\Users\User\Source\Repos\Dorennor\Practice\PracticeShop\Views\Home\Index.cshtml"
                  Write(game.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n");
#nullable restore
#line 41 "C:\Users\User\Source\Repos\Dorennor\Practice\PracticeShop\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\n</tr>");
#nullable restore
#line 43 "C:\Users\User\Source\Repos\Dorennor\Practice\PracticeShop\Views\Home\Index.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Game>> Html { get; private set; }
    }
}
#pragma warning restore 1591
