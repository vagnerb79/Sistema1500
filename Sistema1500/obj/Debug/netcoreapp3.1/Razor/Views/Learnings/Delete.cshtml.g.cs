#pragma checksum "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "48558aa2f2f2a9afd6122e7f12fce6f9f7405be6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Learnings_Delete), @"mvc.1.0.view", @"/Views/Learnings/Delete.cshtml")]
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
#line 1 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\_ViewImports.cshtml"
using Sistema1500;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\_ViewImports.cshtml"
using Sistema1500.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"48558aa2f2f2a9afd6122e7f12fce6f9f7405be6", @"/Views/Learnings/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b33113ca21b158be967869cf1447bb97358afe8f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Learnings_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Sistema1500.Models.Learning>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-size:16px; color:blue;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""content-header"">
    <h1>1500fh<small>Desenvolvedor Full Stack</small></h1>
</section>

<section class=""content"">
    <div class=""row"">
        <div class=""col-xs-12"">
            <div class=""box"">
                <div class=""box-header"">
                    <h3 class=""box-title"">Aprendizados</h3>
                </div>
                <div class=""box-body"">
                    <div class=""row"" style=""font-size: 16px; justify-content:center; display:flex"">
                        <div>
                            <h3 class=""box-title"">Deseja realmente deletar?</h3>
                            <hr />
                            <dl class=""dl-horizontal"">
                                <dt>
                                    ");
#nullable restore
#line 25 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd>\r\n                                    ");
#nullable restore
#line 28 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt>\r\n                                    ");
#nullable restore
#line 31 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.Circle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd>\r\n                                    ");
#nullable restore
#line 34 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.Circle.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt>\r\n                                    ");
#nullable restore
#line 37 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.Theme));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd>\r\n                                    ");
#nullable restore
#line 40 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.Theme.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt>\r\n                                    ");
#nullable restore
#line 43 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.OportunityLearning));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd>\r\n                                    ");
#nullable restore
#line 46 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.OportunityLearning));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt>\r\n                                    ");
#nullable restore
#line 49 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.LearningAction));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd>\r\n                                    ");
#nullable restore
#line 52 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.LearningAction));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt>\r\n                                    ");
#nullable restore
#line 55 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.MeasurementDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd>\r\n                                    ");
#nullable restore
#line 58 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.MeasurementDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt>\r\n                                    ");
#nullable restore
#line 61 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.MeasurementForm));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd>\r\n                                    ");
#nullable restore
#line 64 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.MeasurementForm));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt>\r\n                                    ");
#nullable restore
#line 67 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.Result));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd>\r\n                                    ");
#nullable restore
#line 70 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.Result));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt>\r\n                                    ");
#nullable restore
#line 73 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.Comment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd>\r\n                                    ");
#nullable restore
#line 76 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.Comment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                                <dt>\r\n                                    ");
#nullable restore
#line 79 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dt>\r\n                                <dd>\r\n                                    ");
#nullable restore
#line 82 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
                               Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </dd>\r\n                            </dl>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48558aa2f2f2a9afd6122e7f12fce6f9f7405be614131", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "48558aa2f2f2a9afd6122e7f12fce6f9f7405be614398", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 92 "C:\Users\xboxb\OneDrive\Documentos\Sistema1500\Sistema1500\Views\Learnings\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "48558aa2f2f2a9afd6122e7f12fce6f9f7405be616194", async() => {
                    WriteLiteral(" <i class=\"fa fa-undo\"> </i> Voltar");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Sistema1500.Models.Learning> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
