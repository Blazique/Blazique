using Blazique.Data;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace Blazique;

public static class Nodes
{
    public static Node text(string text, [CallerLineNumber] int nodeId = 0) =>
        (component, builder) => builder.AddContent(nodeId, text);

    /// <summary>
    /// This prevents the need to create a new instance of an empty node every time
    /// </summary>
    private static readonly Node EmptyNode = (_, __) => { };
    public static Node empty([CallerLineNumber] int _ = 0) => EmptyNode;

    public static Node fragment(RenderFragment renderFragment, [CallerLineNumber] int _ = 0) =>
        (component, builder) =>
            renderFragment.Invoke(builder);
}
