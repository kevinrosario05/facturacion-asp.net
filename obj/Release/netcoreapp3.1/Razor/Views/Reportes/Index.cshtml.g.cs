#pragma checksum "C:\Users\lenovo x1 carbon\Videos\proyecto\Views\Reportes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f32d850acd06fc695f576bfa856f1eec90eccde5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reportes_Index), @"mvc.1.0.view", @"/Views/Reportes/Index.cshtml")]
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
#line 1 "C:\Users\lenovo x1 carbon\Videos\proyecto\Views\_ViewImports.cshtml"
using proyecto;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lenovo x1 carbon\Videos\proyecto\Views\_ViewImports.cshtml"
using proyecto.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f32d850acd06fc695f576bfa856f1eec90eccde5", @"/Views/Reportes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c408a981cda364cb3b7366a3e1aa09923cb88b9e", @"/Views/_ViewImports.cshtml")]
    public class Views_Reportes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<proyecto.Models.Productos>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\lenovo x1 carbon\Videos\proyecto\Views\Reportes\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<div id=\"pdfContainer\">\r\n    <table class=\"table\" style=\"border: 1px solid; padding:20px\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 15 "C:\Users\lenovo x1 carbon\Videos\proyecto\Views\Reportes\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Nombre_Produc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 18 "C:\Users\lenovo x1 carbon\Videos\proyecto\Views\Reportes\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Precio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 21 "C:\Users\lenovo x1 carbon\Videos\proyecto\Views\Reportes\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Cantidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody style=\"color:red\">\r\n");
#nullable restore
#line 26 "C:\Users\lenovo x1 carbon\Videos\proyecto\Views\Reportes\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 30 "C:\Users\lenovo x1 carbon\Videos\proyecto\Views\Reportes\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Nombre_Produc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 33 "C:\Users\lenovo x1 carbon\Videos\proyecto\Views\Reportes\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Precio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 36 "C:\Users\lenovo x1 carbon\Videos\proyecto\Views\Reportes\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Cantidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 39 "C:\Users\lenovo x1 carbon\Videos\proyecto\Views\Reportes\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
</div>

<div>
    <button class=""btn btn-primary"" type=""submit"" id=""btnPdf"" name=""Productos"">Descargar Productos</button>
</div>

<script type=""text/javascript"">
    $(""#btnPdf"").click(function () {
        var sHtml = $(""#pdfContainer"").html();
        sHtml = sHtml.replace(/</g, ""StrTag"").replace(/>/g, ""EndTag"");
        window.open('../Reportes/Exportar?html=' + sHtml, '_blank');

    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<proyecto.Models.Productos>> Html { get; private set; }
    }
}
#pragma warning restore 1591