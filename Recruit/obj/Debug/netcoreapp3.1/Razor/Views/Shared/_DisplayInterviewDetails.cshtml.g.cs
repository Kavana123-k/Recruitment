#pragma checksum "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Shared\_DisplayInterviewDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a9223b7f67f70e3d35fc39784a3a59fe5b39a8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__DisplayInterviewDetails), @"mvc.1.0.view", @"/Views/Shared/_DisplayInterviewDetails.cshtml")]
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
#line 2 "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Shared\_DisplayInterviewDetails.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a9223b7f67f70e3d35fc39784a3a59fe5b39a8c", @"/Views/Shared/_DisplayInterviewDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7d2b0fb036cc4f9560fc5d5314046c811dd767f", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__DisplayInterviewDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 5 "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Shared\_DisplayInterviewDetails.cshtml"
Write(Html.Kendo().Grid((IEnumerable<InterviewDetail>)TempData["interview"])
    .Name("grid")
    .Columns(columns =>
    {
        columns.Bound(p => p.id).Title("ID").Filterable(ftb => ftb.Multi(true).Search(true)).Width(10);
        columns.Bound(p => p.first_name).Title("Candidate Name").Filterable(ftb => ftb.Multi(true).Search(true)).Width(20);
        columns.Bound(p => p.start_date_time).Title("Start Time & Date").Width(40);
        columns.Bound(p => p.end_date_time).Title("End Time & Date").Width(40);
        columns.Bound(p => p.status).Title("Status").Filterable(ftb => ftb.Multi(true).Search(true)).Width(10);
        columns.Bound(p => p.reason).Title("Reason").Width(40);
       
                         
    })
   
    .Pageable()
    .Sortable()
    .Sortable()
    .Scrollable()
    .HtmlAttributes(new { style = "height:430px;" })
    .DataSource(dataSource => dataSource
        .Ajax()
        .PageSize(20)
     
    )
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