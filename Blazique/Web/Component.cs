using Blazique.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Diagnostics.Contracts;

namespace Blazique.Web;

/// <summary>
/// Base for components that do not have a model, or interaction based on MVU.
/// </summary>
public abstract class Component : ComponentBase
{

    /// <summary>
    /// Build an array of Nodes that need to be rendered
    /// </summary>
    /// <returns>An array of Node delegates that instruct the <see cref="RenderTreeBuilder"/> which content to add</returns>
    public abstract Node[] Render();

    /// <inheritdoc />
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);
        var nodes = Render();
        
        foreach (Node node in nodes)
        {
            node(this, builder);
        }
    }
}

/// <summary>
/// A component that has an underlying model that represents the state of the component
/// </summary>
/// <typeparam name="TModel"></typeparam>
public abstract class Component<TModel> : Component
    where TModel : notnull, new()
{
    protected TModel Model { get; set; } = new();

    protected sealed override async Task OnInitializedAsync()
    {
        Model = await Initialize(Model);
        await base.OnInitializedAsync();
    }

    protected virtual Task<TModel> Initialize(TModel model) => 
        Task.FromResult(Model);
}

/// <summary>
/// Base class for building components that support the MVU pattern
/// </summary>
/// <typeparam name="TModel">The type of the model</typeparam>
/// <typeparam name="TCommand">The base type of the commands the component can handle</typeparam>
public abstract class Component<TModel, TCommand> : Component<TModel>
    where TModel : notnull, new()
{
    /// <summary>
    /// Contains the logic for rendering the view and possible (user) interaction
    /// </summary>
    /// <param name="model"></param>
    /// <param name="dispatch"></param>
    /// <returns></returns>
    [Pure]
    public abstract Node[] View(TModel model, Func<TCommand, Task> dispatch);

    /// <summary>
    /// Contains the logic for updating the model given a command
    /// </summary>
    /// <param name="model">The model containing the state the command should act on</param>
    /// <param name="command"></param>
    /// <returns>The model that was potentially updated</returns>
    [Pure]
    public abstract ValueTask<TModel> Update(TModel model, TCommand command);

    private async Task Dispatch(TCommand command)
    {
        Model = await Update(Model, command);
        StateHasChanged();
    }

    /// <inheritdoc />
    public override Node[] Render() =>
        View(Model, Dispatch);

}


