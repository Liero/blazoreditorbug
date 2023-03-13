namespace BlazorApp3.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Syncfusion.Blazor.Calendars;
using System.Linq.Expressions;

public class DatePicker<T> : ComponentBase
{
    static DateTime Min = new DateTime(1900, 1, 1);

    [Parameter] public T Value { get; set; } = default!;
    [Parameter] public EventCallback<T> ValueChanged { get; set; }
    [Parameter] public Expression<Func<T>>? ValueExpression { get; set; }
    [Parameter] public bool Enabled { get; set; } = true;
    [Parameter] public string? CssClass { get; set; }
    [Parameter] public string? Width { get; set; }
    [Parameter] public string? Placeholder { get; set; }
    [Parameter] public List<DateTime>? Dates { get; set; }
    [Parameter] public string? DatesCssClass { get; set; }
    [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object>? AdditionalAttributes { get; set; }

    public void HandleCellRender(RenderDayCellEventArgs args)
    {
        if (Dates?.Count > 0)
        {
            if (Dates.Contains(args.Date))
            {
                args.CellData.ClassList += (" " + DatesCssClass);
            }
        }
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenComponent<SfDatePicker<T>>(0);
        builder.AddAttribute(0, nameof(SfDatePicker<T>.Value), Value);
        if (ValueChanged.HasDelegate)
        {
            builder.AddAttribute(1, nameof(SfDatePicker<T>.ValueChanged), ValueChanged);
        }
        if (ValueExpression != null)
        {
            builder.AddAttribute(2, nameof(SfDatePicker<T>.ValueExpression), ValueExpression);
        }
        if (!Enabled)
        {
            builder.AddAttribute(3, nameof(SfDatePicker<T>.Enabled), Enabled);
        }
        builder.AddAttribute(5, nameof(SfDatePicker<T>.Min), Min);
        builder.AddAttribute(6, nameof(SfDatePicker<T>.WeekNumber), true);
        builder.AddAttribute(7, nameof(SfDatePicker<T>.Format), "dd.MM.yyyy");
        if (Width != null)
        {
            builder.AddAttribute(8, nameof(SfDatePicker<T>.Width), Width);
        }
        if (CssClass != null)
        {
            builder.AddAttribute(9, nameof(SfDatePicker<T>.CssClass), CssClass);
        }
        if (Placeholder != null)
        {
            builder.AddAttribute(10, nameof(SfDatePicker<T>.Placeholder), Placeholder);
        }

        if (AdditionalAttributes?.Count > 0)
        {
            builder.AddAttribute(11, nameof(SfDatePicker<T>.HtmlAttributes), AdditionalAttributes);
        }
        if (DatesCssClass != null && Dates?.Count > 0)
        {
            RenderFragment childContent = _builder =>
            {
                _builder.OpenComponent<DatePickerEvents<T>>(14);
                _builder.AddAttribute(15, nameof(DatePickerEvents<T>.OnRenderDayCell), EventCallback.Factory.Create<RenderDayCellEventArgs>(this, HandleCellRender));
                _builder.CloseComponent();
            };
            builder.AddAttribute(12, nameof(SfDatePicker<T>.ChildContent), childContent);        
        }
        builder.CloseComponent();
    }
}