#pragma checksum "C:\Users\intel\source\repos\Shop\ShopUI\Pages\Admin\Orders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "75a07e5c15728e517fa86c1c352f3a71f34a03bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ShopUI.Pages.Admin.Pages_Admin_Orders), @"mvc.1.0.razor-page", @"/Pages/Admin/Orders.cshtml")]
namespace ShopUI.Pages.Admin
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
#line 1 "C:\Users\intel\source\repos\Shop\ShopUI\Pages\_ViewImports.cshtml"
using ShopUI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"75a07e5c15728e517fa86c1c352f3a71f34a03bb", @"/Pages/Admin/Orders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3d667d92b1271dbe4408bf5d755cd9b301a50d6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Admin_Orders : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\intel\source\repos\Shop\ShopUI\Pages\Admin\Orders.cshtml"
  
    ViewData["Title"] = "Orders";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Orders</h1>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopUI.Pages.Admin.OrdersModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ShopUI.Pages.Admin.OrdersModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ShopUI.Pages.Admin.OrdersModel>)PageContext?.ViewData;
        public ShopUI.Pages.Admin.OrdersModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
