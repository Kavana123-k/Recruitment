#pragma checksum "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Home\DisplayProcessStatus.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "68e5775b1deba775bbfacac42560bf7985b05896"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DisplayProcessStatus), @"mvc.1.0.view", @"/Views/Home/DisplayProcessStatus.cshtml")]
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
#line 4 "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Home\DisplayProcessStatus.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68e5775b1deba775bbfacac42560bf7985b05896", @"/Views/Home/DisplayProcessStatus.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7d2b0fb036cc4f9560fc5d5314046c811dd767f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DisplayProcessStatus : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Recruit.Models.ProcessStatus>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
            WriteLiteral("<h1 align=\"center\"style=\"color: white;\">Process Status Details</h1>\r\n\r\n\r\n    ");
#nullable restore
#line 8 "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Home\DisplayProcessStatus.cshtml"
Write(Html.Kendo().Grid(Model)
    .Name("Grid")
    .Columns(columns =>
    {
        columns.Bound(p => p.id).Title("ID");
        columns.Bound(p => p.code).Title("code").Width(130);
        columns.Bound(p => p.status).Title("Status");
        columns.Bound(p => p.colour).Title("colour").Width(130);
        columns.Template(
                           "<a class='k-button k-button-icontext' onclick='addMaterialPopup()' href='" +
                               Url.Action("InsertProcessStatus", "Home") +
                             "/#=id#'" +
                           ">Edit</a>"
                       );
    })
    .ToolBar(toolbar => toolbar.ClientTemplate("<a class='k-button k-button-icontext' onclick='addMaterialPopup()' href='InsertProcessStatus/'></span>Add Process Status</a>"))
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
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Recruit.Models.ProcessStatus>> Html { get; private set; }
    }
}
#pragma warning restore 1591
