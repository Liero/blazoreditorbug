using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace BlazorApp3.Shared;
public partial class FormGroup<TValue>
{
#nullable disable
    [Parameter] public string Id { get; set; }
    [Parameter] public TValue Value { get; set; }
#nullable enable
    [Parameter] public EventCallback<TValue> ValueChanged { get; set; }
    [Parameter] public Expression<Func<TValue>>? ValueExpression { get; set; }
    [Parameter] public Expression<Func<TValue>>? Field { get => ValueExpression; set => ValueExpression = value; }
    [Parameter] public string? Label { get; set; }
    [Parameter] public string? LabelCss { get; set; } = "form-label";
    [Parameter] public string? Hint { get; set; }
    [Parameter] public string? InputCss { get; set; }

    /// <summary>
    /// ItemsSource for select
    /// </summary>
    [Parameter] public IEnumerable? Items { get; set; }
    [Parameter] public RenderFragment<FormGroup<TValue>> ChildContent { get; set; }
    [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object>? Attributes { get; set; }

    [Parameter] public FormGroupType? Type { get; set; }
    Type FieldType => Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);
    bool IsNullable => typeof(TValue).IsClass || Nullable.GetUnderlyingType(typeof(TValue)) != null;
    public FormGroup()
    {
        ChildContent = DefaultChildContent;
    }

    RenderFragment DefaultChildContent(FormGroup<TValue> context) => (builder) =>
    {

    };
}
public enum FormGroupType
{
    Default,
    Text,
    Date,
    Number,
    Checkbox,
    Select
}
