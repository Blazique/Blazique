﻿using Microsoft.AspNetCore.Components;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Blazique;

public static class bind
{

    private const string InputEventName = "oninput";
    private const string ChangeEventName = "onchange";

    private static Data.Attribute binder<T>(int nodeId, string name, T currentValue, Action<T> callback, CultureInfo cultureInfo)
        =>
        (component, builder) =>
        {
            builder.AddAttribute(nodeId, name, EventCallback.Factory.CreateBinder(component, callback, currentValue, cultureInfo));
        };

    public static Data.Attribute input<T>(T value, Action<T> callback, CultureInfo cultureInfo = default!, [CallerLineNumber] int nodeId = 0) =>
        binder(nodeId, InputEventName, value, callback, cultureInfo);

    public static Data.Attribute change<T>(T value, Action<T> callback, CultureInfo cultureInfo = default!, [CallerLineNumber] int nodeId = 0) =>
        binder(nodeId, ChangeEventName, value, callback, cultureInfo);
}

