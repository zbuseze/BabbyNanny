#pragma checksum "C:\Users\busez\source\repos\BabbyNanny\Pages\ListToDo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e33122d37f566d23643764d36079a49f3e9bae15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(BabbyNanny.Pages.Pages_ListToDo), @"mvc.1.0.razor-page", @"/Pages/ListToDo.cshtml")]
namespace BabbyNanny.Pages
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
#line 1 "C:\Users\busez\source\repos\BabbyNanny\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\busez\source\repos\BabbyNanny\Pages\_ViewImports.cshtml"
using BabbyNanny;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\busez\source\repos\BabbyNanny\Pages\_ViewImports.cshtml"
using BabbyNanny.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e33122d37f566d23643764d36079a49f3e9bae15", @"/Pages/ListToDo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a391b1eecf0a786cffa09301f5b08bfa8f32153", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ListToDo : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/create.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\busez\source\repos\BabbyNanny\Pages\ListToDo.cshtml"
  
    ViewData["Title"] = "List Todos";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e33122d37f566d23643764d36079a49f3e9bae154074", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<h1>List Ads</h1>
<h4>View the active advertisements in the system.</h4>
<div class=""row"">
    <div class=""col-lg-7 mx-auto"">
        <div class=""card mt-2 mx-auto p-4 bg-light"">
            <div class=""card-body bg-light"">
                <div class=""container"">
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th>
                                    ");
#nullable restore
#line 18 "C:\Users\busez\source\repos\BabbyNanny\Pages\ListToDo.cshtml"
                               Write(Html.DisplayNameFor(model => model.Todos[0].Task));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 21 "C:\Users\busez\source\repos\BabbyNanny\Pages\ListToDo.cshtml"
                               Write(Html.DisplayNameFor(model => model.Todos[0].Deadline));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 24 "C:\Users\busez\source\repos\BabbyNanny\Pages\ListToDo.cshtml"
                               Write(Html.DisplayNameFor(model => model.Todos[0].Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 27 "C:\Users\busez\source\repos\BabbyNanny\Pages\ListToDo.cshtml"
                               Write(Html.DisplayNameFor(model => model.Todos[0].Priority));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </th>
                                <th>
                                    Is approved?
                                </th>

                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 36 "C:\Users\busez\source\repos\BabbyNanny\Pages\ListToDo.cshtml"
                             foreach (var item in Model.Todos)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 39 "C:\Users\busez\source\repos\BabbyNanny\Pages\ListToDo.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Task));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 40 "C:\Users\busez\source\repos\BabbyNanny\Pages\ListToDo.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Deadline));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 41 "C:\Users\busez\source\repos\BabbyNanny\Pages\ListToDo.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Category));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 42 "C:\Users\busez\source\repos\BabbyNanny\Pages\ListToDo.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Priority));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 43 "C:\Users\busez\source\repos\BabbyNanny\Pages\ListToDo.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.IsApproved));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 45 "C:\Users\busez\source\repos\BabbyNanny\Pages\ListToDo.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BabbyNanny.Pages.ListToDoModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BabbyNanny.Pages.ListToDoModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<BabbyNanny.Pages.ListToDoModel>)PageContext?.ViewData;
        public BabbyNanny.Pages.ListToDoModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
