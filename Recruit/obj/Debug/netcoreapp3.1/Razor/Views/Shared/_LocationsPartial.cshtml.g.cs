#pragma checksum "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Shared\_LocationsPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff88f2194fc7a4a70e2190e39318cdc5cc551f10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LocationsPartial), @"mvc.1.0.view", @"/Views/Shared/_LocationsPartial.cshtml")]
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
#line 1 "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\_ViewImports.cshtml"
using Recruit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\_ViewImports.cshtml"
using Recruit.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Shared\_LocationsPartial.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff88f2194fc7a4a70e2190e39318cdc5cc551f10", @"/Views/Shared/_LocationsPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7d2b0fb036cc4f9560fc5d5314046c811dd767f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LocationsPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Shared\_LocationsPartial.cshtml"
Write(Html.Kendo().Grid((IEnumerable<Location>)TempData["Location"])
    .Name("LocationGrid")
    .Columns(columns =>
    {
        columns.Bound(p => p.id).Title("ID");
        columns.Bound(p => p.city).Title("City");

    })
    .HtmlAttributes(new { style = "height: 550px;" })
    .Pageable(
     pageable => pageable
         .Input(true)
         .Numeric(false)
     )
    .Sortable()
    .Scrollable(scr=>scr.Height(430))

   
);

#line default
#line hidden
#nullable disable
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
