using System.Runtime.CompilerServices;
using Blazique.Data;
using Microsoft.AspNetCore.Components;
using Radix;

namespace Blazique;

/// <summary>
/// Provides factory methods for creating attributes
/// </summary>
public static class Attribute
{
    
    public static Data.Attribute Create<T>(object[] values, int nodeId = 0)
        where T : Literal<T>, AttributeName
        =>
        (_, builder)
            =>
        {
            if (values.Length > 0)
                builder.AddAttribute(nodeId, T.Format(), values.Aggregate((current, next) => $"{current} {next}"));

        };

    public static Data.Attribute Create(string name, object[] values, int nodeId = 0)
        =>
            (_, builder)
                =>
            {
                if (values.Length > 0)
                    builder.AddAttribute(nodeId, name, values.Aggregate((current, next) => $"{current} {next}"));

            };

    public static Data.Attribute attribute(string name, object[] values, [CallerLineNumber] int nodeId = 0) =>
        Create(name, values, nodeId);

    /// <summary>
    /// Create an attribute whose value is an HTML fragment.
    /// Use this function for Blazor component attributes of type <see cref="T:Microsoft.AspNetCore.Components.RenderFragment" />.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="node"></param>
    /// <param name="nodeId"></param>
    /// <returns></returns>
    public static Blazique.Data.Attribute fragment(string name, Node[] node, [CallerLineNumber] int nodeId = 0) => 
    (component, builder) =>
        builder.AddAttribute(nodeId, name, new RenderFragment(rt => {
            foreach (var n in node)
                n.Invoke(component, rt);
        }));

    /// <summary>
    /// Create an attribute whose value is a parameterized HTML fragment.
    /// Use this function for Blazor component attributes of type <see cref="T:Microsoft.AspNetCore.Components.RenderFragment`1" />.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <param name="f"></param>
    /// <param name="nodeId"></param>
    /// <returns></returns>
    public static Blazique.Data.Attribute fragment<T>(string name, Func<T, Node[]> f, [CallerLineNumber] int nodeId = 0) => 
    (component, builder) =>
        builder.AddAttribute(nodeId, name, new RenderFragment<T>(context => 
            new RenderFragment(rt => 
            {
                var node = f(context);
                foreach (var n in node)
                    n.Invoke(component, rt);
            })));
}
