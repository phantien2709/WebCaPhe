#pragma checksum "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5812bcdeab1a9b8c86ada55a2973c4b380cc1468"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sanpham_Index), @"mvc.1.0.view", @"/Views/Sanpham/Index.cshtml")]
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
#line 1 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\_ViewImports.cshtml"
using doan;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\_ViewImports.cshtml"
using doan.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
using PagedList.Core.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5812bcdeab1a9b8c86ada55a2973c4b380cc1468", @"/Views/Sanpham/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f41b37742cf350e2c7d5a13df020201896b51862", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Sanpham_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList.Core.IPagedList<doan.Models.Sanpham>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/images/icon/all-product.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("product-name"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("pager-container"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Sanpham", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::PagedList.Core.Mvc.PagerTagHelper __PagedList_Core_Mvc_PagerTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
  
    int PageCurrent = ViewBag.CurrentPage;
    int PageNext = PageCurrent + 1;
    ViewData["Title"] = "Index" + ViewBag.CurrentPage;
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<main class=""main-content"">
    <div class=""breadcrumb-area breadcrumb-height pb-5"" data-bg-image=""/assets/images/slider/bg/slide-shop.jpg""></div>
    <div class=""container pt-5 h-100"">
            <div class=""row h-100"">
                <div class=""col-lg-12"">
                    <div class=""breadcrumb-item"">
                    <h2 class=""breadcrumb-heading"" style=""font-family:'Segoe UI'; color:orangered"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5812bcdeab1a9b8c86ada55a2973c4b380cc14687266", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        Tất cả sản phẩm</h2>
                    <ul>
                        <li>
                            <a href=""/"">Trang chủ<i class=""pe-7s-angle-right""></i></a>
                        </li>
                        <li>Danh sách sản phẩm</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    <div class=""shop-area pt-5 pb-5"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-1 order-lg-1 order-2 pt-10 pt-lg-0""></div>
                <div class=""col-lg-11 order-lg-2 order-1"">
                    <div class=""product-topbar"">
                        <ul>
                            <li class=""product-view-wrap"">
                                <ul class=""nav"" role=""tablist"">
                                    <li class=""grid-view"" role=""presentation"">
                                        <a id=""grid-view-tab"" data-bs-toggle=""tab"" href=""#grid-view"" r");
            WriteLiteral(@"ole=""tab"" aria-selected=""true"">
                                            <i class=""fa fa-th""></i>
                                        </a>
                                    </li>
                                    <li class=""list-view"" role=""presentation"">
                                        <a class=""active"" id=""list-view-tab"" data-bs-toggle=""tab"" href=""#list-view"" role=""tab"" aria-selected=""true"">
                                            <i class=""fa fa-th-list""></i>
                                        </a>
                                    </li>
                                </ul>
                            </li>
                            <li class=""page-count"">
                                <span>Trang này có ");
#nullable restore
#line 52 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
                                              Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral(@" sản phẩm</span>
                            </li>
                        </ul>
                    </div>
                    <div class=""tab-content text-charcoal pt-8"">
                        <div class=""tab-pane fade"" id=""grid-view"" role=""tabpanel"" aria-labelledby=""grid-view-tab"">
                            <div class=""product-grid-view row"" id=""gia1"">
");
#nullable restore
#line 59 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
                                 if (Model != null && Model.Count() > 0)
                                {
                                    var stt = 0;
                                    foreach (var item in Model)
                                    {
                                        string url = $"/{item.MaSp}.html";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <div class=""col-lg-4 col-sm-6"">
                                            <div class=""product-item rounded"" style=""background-color: #ffefe4"">
                                                <div class=""product-img img-zoom-effect rounded"">
                                                    <a");
            BeginWriteAttribute("href", " href=\"", 3620, "\"", 3631, 1);
#nullable restore
#line 68 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
WriteAttributeValue("", 3627, url, 3627, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 69 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
                                                          
                                                            string temp = item.MaSp + ".jpg";
                                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <img class=\"img-full rounded\"");
            BeginWriteAttribute("src", " src=\"", 3934, "\"", 3952, 2);
            WriteAttributeValue("", 3940, "/Image/", 3940, 7, true);
#nullable restore
#line 72 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
WriteAttributeValue("", 3947, temp, 3947, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 3953, "\"", 3969, 1);
#nullable restore
#line 72 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
WriteAttributeValue("", 3959, item.MoTa, 3959, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                    </a>
                                                    <div class=""product-add-action"">
                                                        <ul>
                                                            <li>
");
#nullable restore
#line 77 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
                                                                  
                                                                    stt += 1;
                                                                    var id_add = "add_cart" + @stt.ToString();
                                                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5812bcdeab1a9b8c86ada55a2973c4b380cc146814171", async() => {
                WriteLiteral("\r\n                                                                    <a class=\"bg-warning rounded\" href=\"#\"");
                BeginWriteAttribute("onclick", " onclick=\"", 4825, "\"", 4879, 3);
                WriteAttributeValue("", 4835, "document.getElementById(\'", 4835, 25, true);
#nullable restore
#line 82 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
WriteAttributeValue("", 4860, id_add, 4860, 7, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 4867, "\').submit();", 4867, 12, true);
                EndWriteAttribute();
                WriteLiteral(@">
                                                                        <i class=""pe-7s-cart"" style=""font-size:24px; font-weight:bold""></i>
                                                                    </a>
                                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 4649, "/GioHang/Add_cart?product_id=", 4649, 29, true);
#nullable restore
#line 81 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
AddHtmlAttributeValue("", 4678, item.MaSp, 4678, 10, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 81 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
AddHtmlAttributeValue("", 4708, id_add, 4708, 7, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                            </li>

                                                        </ul>
                                                    </div>
                                                </div>
                                                <div class=""product-content"">
                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5812bcdeab1a9b8c86ada55a2973c4b380cc146817943", async() => {
#nullable restore
#line 92 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
                                                                                            Write(item.TenSp);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    <div class=\"price-box pb-1\">\r\n                                                        <span class=\"new-price text-danger\" style=\"font-weight: bold\">");
#nullable restore
#line 94 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
                                                                                                                 Write(item.GiaTien.Value.ToString("#,##0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ</span>\r\n                                                    </div>\r\n                                                </div>\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 99 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </div>
                        </div>
                        <div class=""tab-pane fade show active"" id=""list-view"" role=""tabpanel"" aria-labelledby=""list-view-tab"">
                            <div class=""product-list-view with-sidebar row"">
");
#nullable restore
#line 105 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
                                 if (Model != null && Model.Count() > 0)
                                {
                                    var stt = 0;
                                    foreach (var item in Model)
                                    {
                                        string url = $"/{item.MaSp}.html";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        <div class=""col-12 pt-6"">
                                            <div class=""product-item rounded"" style=""background-color: #ffefe4"">
                                                <div class=""product-img img-zoom-effect rounded"">
                                                    <a");
            BeginWriteAttribute("href", " href=\"", 7099, "\"", 7110, 1);
#nullable restore
#line 114 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
WriteAttributeValue("", 7106, url, 7106, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 115 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
                                                          
                                                            string temp = item.MaSp + ".jpg";
                                                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <img class=\"img-full rounded\"");
            BeginWriteAttribute("src", " src=\"", 7413, "\"", 7431, 2);
            WriteAttributeValue("", 7419, "/Image/", 7419, 7, true);
#nullable restore
#line 118 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
WriteAttributeValue("", 7426, temp, 7426, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 7432, "\"", 7449, 1);
#nullable restore
#line 118 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
WriteAttributeValue(" ", 7438, item.MoTa, 7439, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                    </a>
                                                    <div class=""product-add-action"">
                                                        <ul>
                                                            <li>
");
#nullable restore
#line 123 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
                                                                  
                                                                    stt += 1;
                                                                    var id_add = "add_cart2" + @stt.ToString();
                                                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5812bcdeab1a9b8c86ada55a2973c4b380cc146824124", async() => {
                WriteLiteral("\r\n                                                                    <a class=\"bg-warning rounded\" href=\"#\"");
                BeginWriteAttribute("onclick", " onclick=\"", 8306, "\"", 8360, 3);
                WriteAttributeValue("", 8316, "document.getElementById(\'", 8316, 25, true);
#nullable restore
#line 128 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
WriteAttributeValue("", 8341, id_add, 8341, 7, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 8348, "\').submit();", 8348, 12, true);
                EndWriteAttribute();
                WriteLiteral(@">
                                                                        <i class=""pe-7s-cart"" style=""font-size:24px; font-weight:bold""></i>
                                                                    </a>
                                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 8130, "/GioHang/Add_cart?product_id=", 8130, 29, true);
#nullable restore
#line 127 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
AddHtmlAttributeValue("", 8159, item.MaSp, 8159, 10, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 127 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
AddHtmlAttributeValue("", 8189, id_add, 8189, 7, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                            </li>

                                                        </ul>
                                                    </div>
                                                </div>
                                                <div class=""product-content"">
                                                    <a class=""product-name pb-2""");
            BeginWriteAttribute("href", " href=\"", 9059, "\"", 9070, 1);
#nullable restore
#line 138 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
WriteAttributeValue("", 9066, url, 9066, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><b>");
#nullable restore
#line 138 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
                                                                                           Write(item.TenSp);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b></a>\r\n                                                    <div class=\"price-box pb-1\">\r\n                                                        <span class=\"new-price text-danger\" style=\"font-weight: bold\">");
#nullable restore
#line 140 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
                                                                                                                 Write(item.GiaTien.Value.ToString("#,##0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ</span>\r\n                                                    </div>\r\n                                                    <p class=\"short-desc mb-0\">");
#nullable restore
#line 142 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
                                                                          Write(item.MoTa);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                                </div>\r\n                                            </div>\r\n                                        </div>\r\n");
#nullable restore
#line 146 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
                                    }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"pagination-area pt-10\">\r\n                        <ul class=\"pagination justify-content-center\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5812bcdeab1a9b8c86ada55a2973c4b380cc146830322", async() => {
            }
            );
            __PagedList_Core_Mvc_PagerTagHelper = CreateTagHelper<global::PagedList.Core.Mvc.PagerTagHelper>();
            __tagHelperExecutionContext.Add(__PagedList_Core_Mvc_PagerTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
#nullable restore
#line 153 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
__PagedList_Core_Mvc_PagerTagHelper.Options = PagedListRenderOptions.Bootstrap4PageNumbersOnly;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("options", __PagedList_Core_Mvc_PagerTagHelper.Options, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 153 "C:\Users\TRAN VAN QUANG\source\repos\framework_Fivemen\Views\Sanpham\Index.cshtml"
__PagedList_Core_Mvc_PagerTagHelper.List = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("list", __PagedList_Core_Mvc_PagerTagHelper.List, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __PagedList_Core_Mvc_PagerTagHelper.AspArea = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __PagedList_Core_Mvc_PagerTagHelper.AspController = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __PagedList_Core_Mvc_PagerTagHelper.AspAction = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </ul>\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</main>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $(""#giasanpham"").keyup(function () {
                var strkeyword = $('#giasanpham').val();
                $.ajax({
                    url: '/Searchtheogia/Searchgia/',
                    datatype: ""json"",
                    type: ""POST"",
                    data: { giasanpham: strkeyword },
                    async: true,
                    success: function (results) {
                        $(""#gia1"").html("""");
                        $(""#gia1"").html(results);
                    },
                    error: function (xhr) {
                        alert('error');
                    }
                });
            });
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList.Core.IPagedList<doan.Models.Sanpham>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
