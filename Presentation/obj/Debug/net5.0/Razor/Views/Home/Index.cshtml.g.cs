#pragma checksum "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b3f87240c0922700b4ac9a44d6c3e5b68c8f26c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\_ViewImports.cshtml"
using Emarket.WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\_ViewImports.cshtml"
using Emarket.WebApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
using Emarket.Core.Application.ViewModels.Ad;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
using Emarket.Core.Application.ViewModels.Categories;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3f87240c0922700b4ac9a44d6c3e5b68c8f26c7", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2d8e14ec1db7690da42bf5787c8a1b4a1810155", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AdsVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-decoration-none col-3 mx-auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Inicio";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"container-fluid\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3f87240c0922700b4ac9a44d6c3e5b68c8f26c76058", async() => {
                WriteLiteral(@"
        <div class=""d-flex m-1"">
            <div class=""input-group "">
                <input name=""keyword"" type=""text"" class=""form-control"" placeholder=""Escriba lo que desea..."" aria-label=""Recipient's username"" aria-describedby=""button-addon2"">
                <button id=""btnGroupDrop1"" type=""button"" class=""btn btn-primary dropdown-toggle"" data-bs-toggle=""dropdown"" aria-expanded=""false"">
                    Seleccionar por categorias
                </button>
                <ul class=""dropdown-menu"" aria-labelledby=""btnGroupDrop1"">
                    <li class=""dropdown-item"">
                        <input class=""form-check-input"" value=""0"" type=""checkbox"" name=""categoryId"" id=""category"" />
                        <label class=""form-check-label"" for=""category"">Todas</label>
                    </li>
");
#nullable restore
#line 22 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
                     foreach (CategoryVM item in ViewBag.categories)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li class=\"dropdown-item\">\r\n                            <input class=\"form-check-input\"");
                BeginWriteAttribute("value", " value=\"", 1302, "\"", 1318, 1);
#nullable restore
#line 25 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
WriteAttributeValue("", 1310, item.Id, 1310, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"checkbox\" name=\"categoryId\"");
                BeginWriteAttribute("id", " id=\"", 1353, "\"", 1375, 2);
                WriteAttributeValue("", 1358, "category_", 1358, 9, true);
#nullable restore
#line 25 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
WriteAttributeValue("", 1367, item.Id, 1367, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <label class=\"form-check-label\"");
                BeginWriteAttribute("for", " for=\"", 1440, "\"", 1463, 2);
                WriteAttributeValue("", 1446, "category_", 1446, 9, true);
#nullable restore
#line 26 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
WriteAttributeValue("", 1455, item.Id, 1455, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
#nullable restore
#line 26 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
                                                                               Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                        </li>\r\n");
#nullable restore
#line 28 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </ul>\r\n                <button class=\"btn btn-primary\" type=\"submit\" id=\"button-addon2\">Buscar</button>\r\n            </div>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 34 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
     if (Model.Count != 0 || Model == null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h3 class=\"mt-4 mb-4 ps-2\">Lo mas comprado por la comunidad</h3>\r\n        <div class=\" m-1 row mt-3\">\r\n");
#nullable restore
#line 38 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3f87240c0922700b4ac9a44d6c3e5b68c8f26c712051", async() => {
                WriteLiteral("\r\n                    <div class=\"card mb-3 bg-transparent border-2 border-dark\">\r\n                        <img");
                BeginWriteAttribute("src", " src=\"", 2183, "\"", 2202, 1);
#nullable restore
#line 42 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
WriteAttributeValue("", 2189, item.Urls[0], 2189, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"card-img-top\" style=\"height:180px; width:auto;\"");
                BeginWriteAttribute("alt", " alt=\"", 2258, "\"", 2274, 1);
#nullable restore
#line 42 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
WriteAttributeValue("", 2264, item.Name, 2264, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                        <div class=\"card-body border-2 border-dark bg-transparent text-dark\">\r\n                            <h5 class=\"card-title\">");
#nullable restore
#line 44 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
                                              Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("  -   ");
#nullable restore
#line 44 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
                                                              Write(item.CategoryName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                            <p class=\"card-text\">");
#nullable restore
#line 45 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
                                            Write(item.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                            <div class=\"d-flex justify-content-end\">\r\n                                <button href\"#\" class=\"btn border-1 border-dark btn-sm text-dark\">Precio: ");
#nullable restore
#line 47 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
                                                                                                     Write(item.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("</button>\r\n                            </div>\r\n");
#nullable restore
#line 49 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
                             if (item.LastUpdate != null)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <p class=\"card-text\"><small class=\"text-muted\">Last updated ");
#nullable restore
#line 51 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
                                                                                       Write(item.LastUpdate);

#line default
#line hidden
#nullable disable
                WriteLiteral("</small></p>\r\n");
#nullable restore
#line 52 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </div>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
                                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 56 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div> ");
#nullable restore
#line 57 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
               }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""mx-auto mt-3 text-center"">
            <h4 class=""modal-title"">Upss, Nadie ha publicado nada todavia...</h4>
            <p class=""text-body"">
                Recuerda aqui podras ver todo los anuncios que los demas usuarios publiquen, los tuyos se encuentra en el apartado
                de Mis anuncios.
            </p>
        </div>
");
#nullable restore
#line 67 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\Emarket\Presentation\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AdsVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
