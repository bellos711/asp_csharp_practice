#pragma checksum "F:\BOOTCAMP\csharp_stack\object_relational\chefs_n_dishes\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff0840f0dbab7c46e1bb539705b147564a1b595b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MyApp.Namespace.Home.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace MyApp.Namespace.Home
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
#line 1 "F:\BOOTCAMP\csharp_stack\object_relational\chefs_n_dishes\Views\Home\Index.cshtml"
using chefs_n_dishes.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff0840f0dbab7c46e1bb539705b147564a1b595b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5046dae98e101a0932db0aa2a02d40121f48d425", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Chef>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff0840f0dbab7c46e1bb539705b147564a1b595b3104", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Document</title>
    <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"" integrity=""sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z"" crossorigin=""anonymous"">
    <link rel=""stylesheet"" href=""/css/style.css"">
    
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ff0840f0dbab7c46e1bb539705b147564a1b595b4494", async() => {
                WriteLiteral(@"
    <div class=""container outercontainer"">
        <div class=""innercontainer container"">
            <h3 class=""text-center"">Chefs | <a href=""/dishes"">Dishes</a></h3>
            <h4 class=""text-right""><a href=""/new"">Add a chef</a></h4>
            <div class=""container"">
                <h3>All Chefs</h3>
                <table class=""table table-striped"">
                    <tr>
                        <th>Chef</th>
                        <th>Age</th>
                        <th>Dishes</th>
                    </tr>
");
#nullable restore
#line 27 "F:\BOOTCAMP\csharp_stack\object_relational\chefs_n_dishes\Views\Home\Index.cshtml"
                     foreach(Chef chef in @Model)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 30 "F:\BOOTCAMP\csharp_stack\object_relational\chefs_n_dishes\Views\Home\Index.cshtml"
                           Write(chef.ChefFName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 30 "F:\BOOTCAMP\csharp_stack\object_relational\chefs_n_dishes\Views\Home\Index.cshtml"
                                           Write(chef.ChefLName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 31 "F:\BOOTCAMP\csharp_stack\object_relational\chefs_n_dishes\Views\Home\Index.cshtml"
                                  
                                var today = DateTime.Today;
                                var chefbday = chef.ChefAge;
                                var age = today.Year - chefbday.Year;
                                if (chefbday.Date > today.AddYears(-age)) age--;
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "F:\BOOTCAMP\csharp_stack\object_relational\chefs_n_dishes\Views\Home\Index.cshtml"
                           Write(age);

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </td>\r\n                            <td>\r\n                                <ul>\r\n");
#nullable restore
#line 40 "F:\BOOTCAMP\csharp_stack\object_relational\chefs_n_dishes\Views\Home\Index.cshtml"
                                     foreach (Dish dish in @chef.Dishes)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <li>");
#nullable restore
#line 42 "F:\BOOTCAMP\csharp_stack\object_relational\chefs_n_dishes\Views\Home\Index.cshtml"
                                       Write(dish.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                                            <ul>\r\n                                                <li>Tastiness ");
#nullable restore
#line 44 "F:\BOOTCAMP\csharp_stack\object_relational\chefs_n_dishes\Views\Home\Index.cshtml"
                                                         Write(dish.Tastiness);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                                                <li>Calories ");
#nullable restore
#line 45 "F:\BOOTCAMP\csharp_stack\object_relational\chefs_n_dishes\Views\Home\Index.cshtml"
                                                        Write(dish.Calories);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                                            </ul>\r\n");
#nullable restore
#line 47 "F:\BOOTCAMP\csharp_stack\object_relational\chefs_n_dishes\Views\Home\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                </ul>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 51 "F:\BOOTCAMP\csharp_stack\object_relational\chefs_n_dishes\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Chef>> Html { get; private set; }
    }
}
#pragma warning restore 1591
