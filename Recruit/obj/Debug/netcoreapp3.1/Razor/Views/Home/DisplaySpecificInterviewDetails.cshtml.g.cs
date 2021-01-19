#pragma checksum "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Home\DisplaySpecificInterviewDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6731892002e0840bce3a71a532aeb93ecccd171f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DisplaySpecificInterviewDetails), @"mvc.1.0.view", @"/Views/Home/DisplaySpecificInterviewDetails.cshtml")]
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
#line 2 "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Home\DisplaySpecificInterviewDetails.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6731892002e0840bce3a71a532aeb93ecccd171f", @"/Views/Home/DisplaySpecificInterviewDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7d2b0fb036cc4f9560fc5d5314046c811dd767f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DisplaySpecificInterviewDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Recruit.Models.Timeline>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DisplayCandidatesDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Home\DisplaySpecificInterviewDetails.cshtml"
Write(Html.Kendo().Grid(Model)
        .Name("Grid")
        .Columns(columns =>
        {
            columns.Bound(p => p.id).Title("ID").Filterable(ftb => ftb.Multi(true).Search(true)).Width(80);
            columns.Bound(p => p.stage).Title("Interview Stage").Filterable(ftb => ftb.Multi(true).Search(true)).Width(200);
            columns.Bound(p => p.first_name).Title("Candidate Name").Filterable(ftb => ftb.Multi(true).Search(true)).Width(200);
            columns.Bound(p => p.start_date_time).Title("Start Time & Date").Width(400);
            columns.Bound(p => p.end_date_time).Title("End Time & Date").Width(400);
            columns.Bound(p => p.status_id).Title("Status").Filterable(ftb => ftb.Multi(true).Search(true)).Width(100);
            columns.Bound(p => p.status).Title("Status").Filterable(ftb => ftb.Multi(true).Search(true)).Width(100);
            columns.Bound(p => p.reason).Title("Reason").Width(400);
            columns.Bound(p => p.employee_id).Title("Emp_id").Filterable(ftb => ftb.Multi(true).Search(true)).Width(400);
            columns.Bound(p => p.emp_name).Title("Interviewer").Filterable(ftb => ftb.Multi(true).Search(true)).Width(400);
            columns.Template(
                                 "<a class='k-button k-button-icontext' onclick='addMaterialPopup()' href='" +
                                     Url.Action("InsertInterviewDetails","Home") +
                                   "/#=id#'" +
                                 ">Edit</a>"
                             ).Width(200);
        })
          .ToolBar(toolbar => toolbar.ClientTemplate("<a class='k-button k-button-icontext' onclick='addMaterialPopup()' href='" +
                                     Url.Action("InsertInterviewDetails","Home") +
                                   "/#=0#'" +
                                 ">Add Interview Details</a>"))
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
            WriteLiteral("\r\n        )\r\n<div>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6731892002e0840bce3a71a532aeb93ecccd171f6083", async() => {
                WriteLiteral("Back to Display Candidate Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Recruit.Models.Timeline>> Html { get; private set; }
    }
}
#pragma warning restore 1591
