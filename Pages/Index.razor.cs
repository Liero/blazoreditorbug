using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Popups;
using System.ComponentModel;

namespace BlazorApp3.Pages
{
    public partial class Index
    {

        public static RenderFragment DisplayIO(V io, bool addPrefix = false) => __builder =>
        {
            if (io.Id > 0) __builder.AddContent(0, $"{(addPrefix ? "IO-" : null)}{io.Id}");
            else __builder.AddMarkupContent(0, $"<span>#{io.PC} <i>(nová)</i><span>");
        };

        protected object Dialogs { get; set; } = default!;
        public Z? Order { get; set; }
        public V? InternalOrder => Order?.InternalOrder;


        public IOModelVM IOModel { get; set; } = new();
    }

    public class IOModelVM
    {
        public List<SubsetVM> Subsets = new();
    }

    public class SubsetVM
    {
        public int OrderId { get; set; }
        public int IO { get; set; }

    }

    public class Z
    {
        public V? InternalOrder { get; set; }
    }

    public class V
    {
        public Z? Order { get; set; }
        public int Id { get; set; }
        public string? PC { get; set; }
        public int? Podset { get; set; }
        public bool HasFinishedGoodMaterial() => true;
    }

    public class OrderDetail
    {
        public static RenderFragment DialogLink(object dialogService, int? orderId, int? io = null, object? content = null, string? css = null) =>
    builder => { };

        public static async Task OpenDialog(object dialogService, int? orderId, int? io = null) =>
            await Task.CompletedTask;
    }
}
