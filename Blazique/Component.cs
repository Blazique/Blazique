using Blazique.Data;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace Blazique;

public static class Component
{

    public static Data.Node Create<T>(Data.Attribute[] attributes, Data.Node[] children, object? key = null,
        [CallerLineNumber] int nodeId = 0) where T : IComponent
        => (component, builder) =>
            {
                builder.OpenRegion(nodeId);
                builder.OpenComponent<T>(nodeId);
                builder.SetKey(key);

                foreach (Data.Attribute attribute in attributes)
                {
                    attribute(component, builder);
                }

                if (children.Length > 0)
                {
                    RenderFragment fragment = treeBuilder => treeBuilder.AddContent(
                        nodeId,
                        renderTreeBuilder =>
                        {
                            foreach (Node elementChild in children)
                            {
                                elementChild(component, renderTreeBuilder);
                            }
                        });
                    builder.AddAttribute(1, "ChildContent", fragment);
                }

                builder.CloseComponent();
                builder.CloseRegion();
            };
}
