#pragma checksum "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Home\DisplayInterviewDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5df2346a71e34613317213e0449650e42aba7d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DisplayInterviewDetails), @"mvc.1.0.view", @"/Views/Home/DisplayInterviewDetails.cshtml")]
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
#line 3 "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Home\DisplayInterviewDetails.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5df2346a71e34613317213e0449650e42aba7d8", @"/Views/Home/DisplayInterviewDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7d2b0fb036cc4f9560fc5d5314046c811dd767f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DisplayInterviewDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<InterviewDetail>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<h1>Employee Details</h1>\r\n");
#nullable restore
#line 5 "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Home\DisplayInterviewDetails.cshtml"
Write(Html.Kendo().Grid(Model)
    .Name("Grid")
    .Columns(columns =>
    {
        columns.Bound(p => p.id).Title("ID").Filterable(ftb => ftb.Multi(true).Search(true)).Width(80);
        columns.Bound(p => p.first_name).Title("Candidate Name").Filterable(ftb => ftb.Multi(true).Search(true)).Width(200);
        columns.Bound(p => p.start_date_time).Title("Start Time & Date").Width(400);
        columns.Bound(p => p.end_date_time).Title("End Time & Date").Width(400);
        columns.Bound(p => p.status).Title("Status").Filterable(ftb => ftb.Multi(true).Search(true)).Width(100);
        columns.Bound(p => p.reason).Title("Reason").Width(400);
        columns.Template(
                             "<a class='k-button k-button-icontext' onclick='addMaterialPopup()' href='" +
                                 Url.Action("InsertInterviewDetails", "Home") +
                               "/#=id#'" +
                             ">Edit</a>"
                         ).Width(200);
    })
      .ToolBar(toolbar => toolbar.ClientTemplate("<a class='k-button k-button-icontext' onclick='addMaterialPopup()' href='InsertInterviewDetails/'></span>Add Interview Details</a>"))
    .HtmlAttributes(new { style = "height: 550px;" })
    .Pageable(
     pageable => pageable
         .Input(true)
         .Numeric(false)
     )
    .Sortable()
    .Scrollable(scr=>scr.Height(430))
    .Filterable()
   
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<InterviewDetail>> Html { get; private set; }
    }
}
#pragma warning restore 1591
