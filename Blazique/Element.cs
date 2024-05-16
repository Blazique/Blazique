using Radix;

namespace Blazique;

/// <summary>
/// Provides factory methods for creating element nodes
/// </summary>
public static class Element
{
    public static Data.Node Create<T>(Data.Attribute[] attributes, Data.Node[] children, object? key = null,
        int nodeId = 0) where T : Literal<T>, ElementName
        => (component, builder)
            =>
        {
            builder.OpenElement(nodeId, T.Format());
            builder.SetKey(key);

            for (int i = 0; i < attributes.Length; i++)
            {
                attributes[i](component, builder);
            }

            for (int i = 0; i < children.Length; i++)
            {
                children[i](component, builder);
            }

            builder.CloseElement();
        };

    public static Data.Node Create<T>(Data.Node[] children, object? key = null, int nodeId = 0)
        where T : Literal<T>, ElementName =>
            Create<T>(Array.Empty<Data.Attribute>(), children, key, nodeId);
}
