#pragma checksum "C:\Users\Mich\Documents\tooVSCORE\Sistema_TOO\TiendaOnline.solucion\TiendaOnline\Views\Home\Categoria.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f4de3f0784fba84cd17a64aad3561f4d528681c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Categoria), @"mvc.1.0.view", @"/Views/Home/Categoria.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Categoria.cshtml", typeof(AspNetCore.Views_Home_Categoria))]
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
#line 1 "C:\Users\Mich\Documents\tooVSCORE\Sistema_TOO\TiendaOnline.solucion\TiendaOnline\Views\_ViewImports.cshtml"
using TiendaOnline;

#line default
#line hidden
#line 2 "C:\Users\Mich\Documents\tooVSCORE\Sistema_TOO\TiendaOnline.solucion\TiendaOnline\Views\_ViewImports.cshtml"
using TiendaOnline.Models;

#line default
#line hidden
#line 3 "C:\Users\Mich\Documents\tooVSCORE\Sistema_TOO\TiendaOnline.solucion\TiendaOnline\Views\_ViewImports.cshtml"
using TiendaOnline.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4de3f0784fba84cd17a64aad3561f4d528681c8", @"/Views/Home/Categoria.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e93f7432df440ab1b28935e4dfa14ed4c983176", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Categoria : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<TiendaOnline.Models.Categoria>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(51, 11, true);
            WriteLiteral("\r\n<p>\r\n    ");
            EndContext();
            BeginContext(62, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84fa93480b0f485aa07c6e3da325eed3", async() => {
                BeginContext(85, 10, true);
                WriteLiteral("Create New");
                EndContext();
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
            EndContext();
            BeginContext(99, 38, true);
            WriteLiteral("\r\n</p>\r\n    <div class=\"list-group\">\r\n");
            EndContext();
#line 7 "C:\Users\Mich\Documents\tooVSCORE\Sistema_TOO\TiendaOnline.solucion\TiendaOnline\Views\Home\Categoria.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(186, 68, true);
            WriteLiteral("        <a href=\"#\" class=\"list-group-item list-group-item-action\"> ");
            EndContext();
            BeginContext(255, 50, false);
#line 9 "C:\Users\Mich\Documents\tooVSCORE\Sistema_TOO\TiendaOnline.solucion\TiendaOnline\Views\Home\Categoria.cshtml"
                                                               Write(Html.DisplayFor(modelItem => item.NombreCategoria));

#line default
#line hidden
            EndContext();
            BeginContext(305, 6, true);
            WriteLiteral("</a>\r\n");
            EndContext();
#line 10 "C:\Users\Mich\Documents\tooVSCORE\Sistema_TOO\TiendaOnline.solucion\TiendaOnline\Views\Home\Categoria.cshtml"
            /**/
        }

#line default
#line hidden
            BeginContext(340, 14, true);
            WriteLiteral("    </div>\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<TiendaOnline.Models.Categoria>> Html { get; private set; }
    }
}
#pragma warning restore 1591
