#pragma checksum "D:\Projetos\C#\EstudoTDD\Estudo\C#\ControleFinanceiroCore\Backend\Backend\Views\ContaDespesas\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b091bf09c7981742dad3bdd212a9738e843c4fbb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContaDespesas_Create), @"mvc.1.0.view", @"/Views/ContaDespesas/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b091bf09c7981742dad3bdd212a9738e843c4fbb", @"/Views/ContaDespesas/Create.cshtml")]
    public class Views_ContaDespesas_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Backend.Models.ContaDespesa>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Projetos\C#\EstudoTDD\Estudo\C#\ControleFinanceiroCore\Backend\Backend\Views\ContaDespesas\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Create</h1>

<h4>ContaDespesa</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""Codigo"" class=""control-label""></label>
                <input asp-for=""Codigo"" class=""form-control"" />
                <span asp-validation-for=""Codigo"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Descricao"" class=""control-label""></label>
                <input asp-for=""Descricao"" class=""form-control"" />
                <span asp-validation-for=""Descricao"" class=""text-danger""></span>
            </div>
            <div class=""form-group form-check"">
                <label class=""form-check-label"">
                    <input class=""form-check-input"" asp-for=""Ativo"" /> ");
#nullable restore
#line 27 "D:\Projetos\C#\EstudoTDD\Estudo\C#\ControleFinanceiroCore\Backend\Backend\Views\ContaDespesas\Create.cshtml"
                                                                  Write(Html.DisplayNameFor(model => model.Ativo));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </label>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 42 "D:\Projetos\C#\EstudoTDD\Estudo\C#\ControleFinanceiroCore\Backend\Backend\Views\ContaDespesas\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Backend.Models.ContaDespesa> Html { get; private set; }
    }
}
#pragma warning restore 1591
