#pragma checksum "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Home\DisplayProcessStages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bcb7bf268bd9da2bbdca1c40f760db7af31244ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DisplayProcessStages), @"mvc.1.0.view", @"/Views/Home/DisplayProcessStages.cshtml")]
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
#line 2 "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Home\DisplayProcessStages.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bcb7bf268bd9da2bbdca1c40f760db7af31244ef", @"/Views/Home/DisplayProcessStages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7d2b0fb036cc4f9560fc5d5314046c811dd767f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DisplayProcessStages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProcessStage>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Process Stage Details</h1>\r\n\r\n\r\n");
#nullable restore
#line 31 "C:\Users\LENOVO\source\repos\Recruit\Recruit\Views\Home\DisplayProcessStages.cshtml"
Write(Html.Kendo().Grid(Model)
    .Name("grid")
    .Columns(columns =>
    {
        columns.Bound(p => p.id).Title("ID");
        columns.Bound(p => p.code).Title("Code");
        columns.Bound(p => p.stage).Title("Stage");
        columns.Command(command => { command.Edit();  }).Width(160);
    })
    .ToolBar(toolbar => toolbar.Create())
    .Editable(editable => editable.Mode(GridEditMode.PopUp))
    .Pageable()
    .Sortable()
    .Scrollable()
    .HtmlAttributes(new { style = "height:430px;" })
    .DataSource(dataSource => dataSource
        .Ajax()
        .PageSize(20)
        .Events(events => events.Error("Error"))
       .Model(model => model.Id(p => p.id))
        .Create(update => update.Action("InsertProcessStages", "Home"))
        .Read(read => read.Action("DisplayProcessStages", "Home"))
        .Update(update => update.Action("InsertProcessStages", "Home",  new { id =0 }))
        .Destroy(update => update.Action("DisplayProcessStages", "Home"))
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProcessStage>> Html { get; private set; }
    }
}
#pragma warning restore 1591
