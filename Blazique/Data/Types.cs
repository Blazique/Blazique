using Microsoft.AspNetCore.Components.Rendering;

namespace Blazique.Data;

/// <summary>
/// The type of a function that is intended to use for adding nodes to a RenderTreeBuilder
/// </summary>
public delegate void Node(object parentComponent, RenderTreeBuilder builder);

/// <summary>
/// An type of a function that is intended to use for adding attributes to a RenderTreeBuilder
/// </summary>
/// <param name="parentComponent"></param>
/// <param name="builder"></param>
public delegate void Attribute(object parentComponent, RenderTreeBuilder builder);
