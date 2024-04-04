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

            foreach (Data.Attribute attribute in attributes)
            {
                attribute(component, builder);
            }

            foreach (Data.Node child in children)
            {
                child(component, builder);
            }

            builder.CloseElement();
        };

    public static Data.Node Create<T>(Data.Node[] children, object? key = null, int nodeId = 0)
        where T : Literal<T>, ElementName =>
            Create<T>([], children, key, nodeId);
}
