#pragma checksum "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65e08713afc2e52f943f5f05f257f93fff4bf58e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Invoice_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Invoice/Index.cshtml")]
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
#line 1 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\_ViewImports.cshtml"
using TubeStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\_ViewImports.cshtml"
using TubeStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\_ViewImports.cshtml"
using TubeStore.Models.Cart;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\_ViewImports.cshtml"
using TubeStore.Models.Chat;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\_ViewImports.cshtml"
using TubeStore.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\_ViewImports.cshtml"
using TubeStore.Areas.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\_ViewImports.cshtml"
using TubeStore.Areas.Admin.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\_ViewImports.cshtml"
using TubeStore.ViewModels.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\_ViewImports.cshtml"
using TubeStore.DataLayer;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65e08713afc2e52f943f5f05f257f93fff4bf58e", @"/Areas/Admin/Views/Invoice/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"393714c0089c41708b2c9b08c3d4b711890e044c", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Invoice_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PaginatedList<Invoice>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Invoice", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""content mt-4"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-body table-responsive p-0"" style=""height: 80Vh;"">

                        <table class=""table"">
                            <thead>
                                <tr>
                                    <th>
                                        ");
#nullable restore
#line 18 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.First().InvoiceId));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </th>
                                    <th>
                                        Customer
                                    </th>
                                    <th>
                                        ");
#nullable restore
#line 24 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.First().OrderDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </th>\r\n                                    <th>\r\n                                        ");
#nullable restore
#line 27 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.First().Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </th>\r\n                                    <th>\r\n                                        ");
#nullable restore
#line 30 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                   Write(Html.DisplayNameFor(model => model.First().Total));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </th>
                                    <th>
                                        Actions
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 38 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 42 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.InvoiceId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 45 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                       Write(item.Customer.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 48 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                       Write(item.OrderDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 51 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 54 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                       Write(item.Total.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 57 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                       Write(Html.ActionLink("Mark Payed", "SetPayed", new { id = item.InvoiceId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                            ");
#nullable restore
#line 58 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                       Write(Html.ActionLink("Details", "Details", new { id = item.InvoiceId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                                            ");
#nullable restore
#line 59 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                       Write(Html.ActionLink("Delete", "SetInactive", new { id = item.InvoiceId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 62 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                    <div class=\"card-footer clearfix\">\r\n                        <ul class=\"pagination pagination-sm m-0 float-right\">\r\n");
#nullable restore
#line 68 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                             if (@Model.PageIndex > 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65e08713afc2e52f943f5f05f257f93fff4bf58e12952", async() => {
                WriteLiteral("&laquo;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 71 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                                                                                                           WriteLiteral(Model.PageIndex-1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </li>\r\n");
#nullable restore
#line 73 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"page-item\"><a class=\"page-link\">");
#nullable restore
#line 74 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                                                  Write(Model.PageIndex);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 75 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                             if (@Model.TotalPages > @Model.PageIndex)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65e08713afc2e52f943f5f05f257f93fff4bf58e16692", async() => {
                WriteLiteral("&raquo;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 78 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                                                                                                                           WriteLiteral(Model.PageIndex+1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </li>\r\n");
#nullable restore
#line 80 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Invoice\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ul>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PaginatedList<Invoice>> Html { get; private set; }
    }
}
#pragma warning restore 1591
