#pragma checksum "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b97848d77f85596042cc3b29d36ed186a5851c72"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Comptes_Delete), @"mvc.1.0.view", @"/Views/Comptes/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Comptes/Delete.cshtml", typeof(AspNetCore.Views_Comptes_Delete))]
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
#line 1 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\_ViewImports.cshtml"
using ENAapp;

#line default
#line hidden
#line 2 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\_ViewImports.cshtml"
using ENAapp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b97848d77f85596042cc3b29d36ed186a5851c72", @"/Views/Comptes/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5941baf1969f5d8ed47fbf863d443e7d28c7c09c", @"/Views/_ViewImports.cshtml")]
    public class Views_Comptes_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ENAapp.Models.Compte>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(30, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
  
    ViewData["Title"] = "Delete";


#line default
#line hidden
            BeginContext(76, 167, true);
            WriteLiteral("\r\n<h2>Delete</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Compte</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(244, 44, false);
#line 16 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Passhash));

#line default
#line hidden
            EndContext();
            BeginContext(288, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(332, 40, false);
#line 19 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Passhash));

#line default
#line hidden
            EndContext();
            BeginContext(372, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(416, 41, false);
#line 22 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(457, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(501, 37, false);
#line 25 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
            EndContext();
            BeginContext(538, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(582, 42, false);
#line 28 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Imgsrc));

#line default
#line hidden
            EndContext();
            BeginContext(624, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(668, 38, false);
#line 31 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Imgsrc));

#line default
#line hidden
            EndContext();
            BeginContext(706, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(750, 42, false);
#line 34 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Profil));

#line default
#line hidden
            EndContext();
            BeginContext(792, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(836, 38, false);
#line 37 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Profil));

#line default
#line hidden
            EndContext();
            BeginContext(874, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(918, 53, false);
#line 40 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ConfirmationToken));

#line default
#line hidden
            EndContext();
            BeginContext(971, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1015, 49, false);
#line 43 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ConfirmationToken));

#line default
#line hidden
            EndContext();
            BeginContext(1064, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1108, 47, false);
#line 46 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ConfirmatAt));

#line default
#line hidden
            EndContext();
            BeginContext(1155, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1199, 43, false);
#line 49 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ConfirmatAt));

#line default
#line hidden
            EndContext();
            BeginContext(1242, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1286, 46, false);
#line 52 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ResetToken));

#line default
#line hidden
            EndContext();
            BeginContext(1332, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1376, 42, false);
#line 55 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ResetToken));

#line default
#line hidden
            EndContext();
            BeginContext(1418, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1462, 43, false);
#line 58 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ResetAt));

#line default
#line hidden
            EndContext();
            BeginContext(1505, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1549, 39, false);
#line 61 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ResetAt));

#line default
#line hidden
            EndContext();
            BeginContext(1588, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1632, 42, false);
#line 64 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(1674, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1718, 38, false);
#line 67 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(1756, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1800, 55, false);
#line 70 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.MatriculeNavigation));

#line default
#line hidden
            EndContext();
            BeginContext(1855, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1899, 61, false);
#line 73 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
       Write(Html.DisplayFor(model => model.MatriculeNavigation.Matricule));

#line default
#line hidden
            EndContext();
            BeginContext(1960, 34, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n\r\n    ");
            EndContext();
            BeginContext(1994, 207, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0ca6986ab8c41ccbf3b45cb72e32e52", async() => {
                BeginContext(2020, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(2030, 36, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f67ffeeb4a644778a317b60b0caadd20", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 78 "C:\Users\ghapgou\source\repos\ENAapp\ENAapp\Views\Comptes\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2066, 84, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(2150, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3ff706e1be5f420094cfbb6e611aa360", async() => {
                    BeginContext(2172, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2188, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2201, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ENAapp.Models.Compte> Html { get; private set; }
    }
}
#pragma warning restore 1591
