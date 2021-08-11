#pragma checksum "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\Home\Orders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94ef64d89968ee3ad10e0d3029c127b1a8f80af4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_Home_Orders), @"mvc.1.0.view", @"/Areas/User/Views/Home/Orders.cshtml")]
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
#line 1 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\_ViewImports.cshtml"
using Tesodev;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\_ViewImports.cshtml"
using Tesodev.Entities.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\_ViewImports.cshtml"
using Tesodev.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\_ViewImports.cshtml"
using Tesodev.Core.Enum;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\_ViewImports.cshtml"
using Tesodev.WebUI.Areas.User;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94ef64d89968ee3ad10e0d3029c127b1a8f80af4", @"/Areas/User/Views/Home/Orders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e061d2a86ab1a8ad4f466f512d506e362a8a69d0", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_Home_Orders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<List<Order>, List<Product>, List<Address>>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\Home\Orders.cshtml"
  
    ViewData["Title"] = "Siparişlerim";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<main>

    <div class=""row invoice justify-content-center"">
        <div class=""col-12"">
            <div class=""invoice-contents"" leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0""
                 offset=""0""
                 style=""background-color:#ffffff; height:800px; max-width:830px; font-family: Helvetica,Arial,sans-serif !important; position: relative;"">

                <table bgcolor=""#ffffff"" border=""0"" cellpadding=""0"" cellspacing=""0""
                       style=""width:100%; background-color:#ffffff;border-collapse:separate !important; border-spacing:0;color:#242128; margin:0;padding:30px;""
                       heigth=""auto"">

                    <tbody>

                        <tr>
                            <td align=""left"" valign=""center""
                                style=""padding-bottom:35px; padding-top:15px; border-top:0;width:100% !important;"">
                                <img src=""/img/logo.png"" />
                            </td>
               ");
            WriteLiteral(@"             <td align=""right"" valign=""center""
                                style=""padding-bottom:35px; padding-top:15px; border-top:0;width:100% !important;"">
                                <p style=""color: #8f8f8f; font-weight: normal; line-height: 1.2; font-size: 12px; white-space: nowrap; "">
                                    Çifte Havuzlar Mah. Eski Londra Asfaltı Cad. <br />Kuluçka Merkezi D2 Blok No: 151/1F İç Kapı No: 2B03<br> Esenler/İstanbul<br>784
                                    0543 488 84 45
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan=""2"" style=""padding-top:30px; border-top:1px solid #f1f0f0; border-bottom:1px solid #f1f0f0"">

                                <table style=""width: 100%; margin-top:40px;"">
                                    <thead>
                                        <tr>
                                            <th style=""text-");
            WriteLiteral(@"align:left; font-size: 10px; color:#8f8f8f; padding-bottom: 15px;"">
                                                ÜRÜN ADI
                                            </th>
                                            <th style=""text-align:left; font-size: 10px; color:#8f8f8f; padding-bottom: 15px;"">
                                                ADET
                                            </th>
                                            <th style=""text-align:right; font-size: 10px; color:#8f8f8f; padding-bottom: 15px;"">
                                                FİYAT
                                            </th>
                                            <th style=""text-align:right; font-size: 10px; color:#8f8f8f; padding-bottom: 15px;"">
                                                ADRES
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 53 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\Home\Orders.cshtml"
                                         foreach (var item in Model.Item1)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94ef64d89968ee3ad10e0d3029c127b1a8f80af47853", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 55 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\Home\Orders.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                            <tr>
                                                <td style=""padding-top:0px; padding-bottom:5px;"">
                                                    <h4 style=""font-size: 16px; line-height: 1; margin-bottom:0; color:#303030; font-weight:500; margin-top: 10px;"">
                                                        <p href=""#""
                                                           style=""font-size: 13px; text-decoration: none; line-height: 1; color:#909090; margin-top:0px; margin-bottom:0;"">
                                                            ");
#nullable restore
#line 61 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\Home\Orders.cshtml"
                                                       Write(Model.Item2.AsQueryable().Where(x => x.ID
== item.ProductID).Select(x => x.Name).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                        </p>
                                                    </h4>
                                                </td>

                                                <td>
                                                    <p href=""#""
                                                       style=""font-size: 13px; text-decoration: none; line-height: 1; color:#909090; margin-top:0px; margin-bottom:0;"">
                                                        ");
#nullable restore
#line 70 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\Home\Orders.cshtml"
                                                   Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                    </p>
                                                </td>
                                                <td style=""padding-top:0px; padding-bottom:0; text-align: right;"">
                                                    <p style=""font-size: 13px; line-height: 1; color:#303030; margin-bottom:0; margin-top:0; vertical-align:top; white-space:nowrap;"">
                                                        ");
#nullable restore
#line 75 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\Home\Orders.cshtml"
                                                   Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" ₺
                                                    </p>
                                                </td>
                                                <td style=""padding-top:0px; padding-bottom:0; text-align: right;"">
                                                    <p style=""font-size: 13px; line-height: 1; color:#303030; margin-bottom:0; margin-top:0; vertical-align:top; white-space:nowrap;"">
                                                        ");
#nullable restore
#line 80 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\Home\Orders.cshtml"
                                                   Write(Model.Item3.AsQueryable().Where(x => x.ID
== item.AddressID).Select(x => x.AddressLine).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                                                        ");
#nullable restore
#line 82 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\Home\Orders.cshtml"
                                                   Write(Model.Item3.AsQueryable().Where(x => x.ID
== item.AddressID).Select(x => x.City).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                                                        ");
#nullable restore
#line 84 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\Home\Orders.cshtml"
                                                   Write(Model.Item3.AsQueryable().Where(x => x.ID
== item.AddressID).Select(x => x.Country).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n                                                        ");
#nullable restore
#line 86 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\Home\Orders.cshtml"
                                                   Write(Model.Item3.AsQueryable().Where(x => x.ID
== item.AddressID).Select(x => x.CityCode).FirstOrDefault());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<br />
                                                    </p>
                                                </td>

                                            </tr>
                                            <tr >
                                                <td colspan=""3"">&nbsp;</td>
                                            </tr>
");
#nullable restore
#line 95 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\Home\Orders.cshtml"

                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    </tbody>
                                </table>

                            </td>
                        </tr>
                        <tr>
                            <td colspan=""3"" style=""border-top:1px solid #f1f0f0"">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan=""2"" style="" width: 100%; padding-bottom:15px;"">
                                <p href=""#""
                                   style=""font-size: 13px; text-decoration: none; line-height: 1.6; color:#909090; margin-top:0px; margin-bottom:0; text-align: right;"">
                                    <strong>Toplam : </strong>
                                </p>
                            </td>
                            <td style=""padding-top:0px; text-align: right; padding-bottom:15px;"">
                                <p style=""font-size: 13px; line-height: 1.6; color:#303030; margin-bottom:0; margin-top:0; vertical-align:top");
            WriteLiteral("; white-space:nowrap; margin-left:15px\">\r\n                                    <strong>\r\n                                        ");
#nullable restore
#line 116 "C:\Users\user\source\repos\Tesodev\Tesodev\Areas\User\Views\Home\Orders.cshtml"
                                   Write(ViewBag.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" ₺
                                    </strong>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan=""3"" style=""border-top:1px solid #f1f0f0"">&nbsp;</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<List<Order>, List<Product>, List<Address>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
