using Blazique.Data;
using System.Runtime.CompilerServices;

namespace Blazique;

public static class Nodes
{
    public static Node text(object text, [CallerLineNumber] int nodeId = 0) =>
        (component, builder) => builder.AddContent(nodeId, text.ToString());

    public static Node empty([CallerLineNumber] int nodeId = 0) => (_, __) => { };
}
