#pragma checksum "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8cfdc43284cf40ff8e7962ace03042cb4e93e3dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Tube_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Tube/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cfdc43284cf40ff8e7962ace03042cb4e93e3dc", @"/Areas/Admin/Views/Tube/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"393714c0089c41708b2c9b08c3d4b711890e044c", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Tube_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PaginatedList<Tube>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Tube", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger mx-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""content mt-4"">
    <div class=""container-fluid"">
        <!-- /.row -->
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8cfdc43284cf40ff8e7962ace03042cb4e93e3dc8397", async() => {
                WriteLiteral("\r\n                            Tube Stock\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8cfdc43284cf40ff8e7962ace03042cb4e93e3dc10212", async() => {
                WriteLiteral("\r\n                            <i class=\"fas fa-plus-circle\"></i> New Tube\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                    <!-- /.card-header -->
                    <div class=""card-body table-responsive p-0"" style=""height: 80Vh;"">
                        <table class=""table table-head-fixed"">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Tube</th>
                                    <th>Date</th>
                                    <th style=""width: 10%"">Description</th>
                                    <th style=""width: 40%"">Full Description</th>
                                    <th>Available</th>
                                    <th>Pairs</th>
                                    <th>Price</th>
                                    <th>Bestseller</th>
                                    <th>New</th>
                                    <th>Category</th>
                                </tr>
                            </thead>
              ");
            WriteLiteral("              <tbody>\r\n");
#nullable restore
#line 41 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                 foreach (var tube in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 44 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                   Write(tube.TubeId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>\r\n                                        <img");
            BeginWriteAttribute("src", " src=\"", 2119, "\"", 2148, 1);
#nullable restore
#line 46 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
WriteAttributeValue("", 2125, tube.ImageThumbnailUrl, 2125, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"80\" />\r\n                                        <p>");
#nullable restore
#line 47 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                      Write(tube.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 47 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                                 Write(tube.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8cfdc43284cf40ff8e7962ace03042cb4e93e3dc14788", async() => {
                WriteLiteral("\r\n                                            <i class=\"fas fa-edit\"></i>Edit\r\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-tubeId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 49 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                                                                                                               WriteLiteral(tube.TubeId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["tubeId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-tubeId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["tubeId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                    </td>\r\n                                    <td>");
#nullable restore
#line 54 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                   Write(tube.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 55 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                   Write(tube.ShortDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 56 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                   Write(tube.FullDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 57 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                   Write(tube.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 58 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                     if (@tube.MatchedPair)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td><span class=\"badge bg-primary\">Yes</span></td>\r\n");
#nullable restore
#line 61 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td><span class=\"badge bg-danger\">No</span></td>\r\n");
#nullable restore
#line 65 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                <td>\r\n                                    ");
#nullable restore
#line 68 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                               Write(tube.Price.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 69 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                     if (tube.Discount != 0)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <a class=\"text-danger\">-");
#nullable restore
#line 71 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                                           Write(tube.Discount.ToString("P0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 72 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n");
#nullable restore
#line 74 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                     if (@tube.IsTubeOfTheWeek)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td><span class=\"badge bg-primary\">Yes</span></td>\r\n");
#nullable restore
#line 77 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td><span class=\"badge bg-danger\">No</span></td>\r\n");
#nullable restore
#line 81 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 82 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                     if (@tube.IsNewArrival)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td><span class=\"badge bg-primary\">Yes</span></td>\r\n");
#nullable restore
#line 85 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <td><span class=\"badge bg-danger\">No</span></td>\r\n");
#nullable restore
#line 89 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    <td>");
#nullable restore
#line 91 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                   Write(tube.Category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 93 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                    <div class=\"card-footer clearfix\">\r\n                        <ul class=\"pagination pagination-sm m-0 float-right\">\r\n");
#nullable restore
#line 99 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                             if (@Model.PageIndex > 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8cfdc43284cf40ff8e7962ace03042cb4e93e3dc24226", async() => {
                WriteLiteral("&laquo;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 102 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
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
#line 104 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"page-item\"><a class=\"page-link\">");
#nullable restore
#line 105 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                                                                  Write(Model.PageIndex);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 106 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                             if (@Model.TotalPages > @Model.PageIndex)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li class=\"page-item\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8cfdc43284cf40ff8e7962ace03042cb4e93e3dc27955", async() => {
                WriteLiteral("&raquo;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 109 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
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
#line 111 "D:\Repos\05 - TubeStore\TubeStore\Areas\Admin\Views\Tube\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ul>\r\n                    </div>\r\n                    <!-- /.card-body -->\r\n                </div>\r\n                <!-- /.card -->\r\n            </div>\r\n        </div>\r\n        <!-- /.row -->\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PaginatedList<Tube>> Html { get; private set; }
    }
}
#pragma warning restore 1591
