using Blazique.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System.Runtime.CompilerServices;


namespace Blazique;

public static class Components
{
    public static Node component<T>(Data.Attribute[] attributes, Node[] children, object? key = null, [CallerLineNumber] int nodeId = 0) where T : IComponent => Component.Create<T>(attributes, children, key, nodeId);

    public static Node navLinkMatchAll(Data.Attribute[] attributes, Node[] children, [CallerLineNumber] int nodeId = 0) => navLink(NavLinkMatch.All, attributes, children, nodeId);

    public static Node navLinkMatchPrefix(Data.Attribute[] attributes, Node[] children, [CallerLineNumber] int nodeId = 0) => navLink(NavLinkMatch.Prefix, attributes, children, nodeId);

    public static Node navLink(NavLinkMatch navLinkMatch, Data.Attribute[] attributes, Node[] children, [CallerLineNumber] int nodeId = 0) =>
        Component.Create<NavLink>(attributes.Prepend(Attribute.Create("Match", [navLinkMatch])).ToArray(), children, nodeId);

}
