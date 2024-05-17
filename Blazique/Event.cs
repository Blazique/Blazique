using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Radix;
namespace Blazique;

/// <summary>
/// Provides factory methods for creating events
/// </summary>
public static class Event
{
    /// <summary>
    /// A class that creates an attribute for an event. This prevents the allocations for the closure that would be created when using a lambda.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TEventArgs"></typeparam>
    private class AttributeCreator<T, TEventArgs> where T : Literal<T>, EventName where TEventArgs : EventArgs
    {
        private readonly Action<TEventArgs> _callback;
        private readonly int _nodeId;

        public AttributeCreator(Action<TEventArgs> callback, int nodeId)
        {
            _callback = callback;
            _nodeId = nodeId;
        }

        public void AddAttribute(RenderTreeBuilder builder, object component)
        {
            builder.AddAttribute(_nodeId, GetEventName<T>(), EventCallback.Factory.Create(component, _callback));
        }
    }

    private static readonly Dictionary<Type, string> EventNames = [];

    private static string GetEventName<T>() where T : Literal<T>, EventName
    {
        if (!EventNames.TryGetValue(typeof(T), out var eventName))
        {
            eventName = "on" + T.Format();
            EventNames[typeof(T)] = eventName;
        }

        return eventName;
    }

    public static Data.Attribute Create<T, TEventArgs>(Action<TEventArgs> callback, int nodeId = 0)
        where T : Literal<T>, EventName
        where TEventArgs : EventArgs
    {
        var creator = new AttributeCreator<T, TEventArgs>(callback, nodeId);
        return (component, builder) => creator.AddAttribute(builder, component);
    }

    public static Data.Attribute Create<T>(Action<EventArgs> callback, int nodeId = 0)
        where T : Literal<T>, EventName
    {
        var creator = new AttributeCreator<T, EventArgs>(callback, nodeId);
        return (component, builder) => creator.AddAttribute(builder, component);
    }
}