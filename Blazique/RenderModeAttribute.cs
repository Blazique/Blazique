using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Blazique;

public class InteractiveServerRenderModeAttribute : RenderModeAttribute
{
    public bool Prerender { get; set; }
    public override IComponentRenderMode Mode  => new InteractiveServerRenderMode(Prerender);
}

public class InteractiveWebAssemblyRenderModeAttribute : RenderModeAttribute
{
    public bool Prerender { get; set; }
    public override IComponentRenderMode Mode  => new InteractiveWebAssemblyRenderMode(Prerender);
}

public class InteractiveAutoRenderModeAttribute : RenderModeAttribute
{
    public bool Prerender { get; set; }
    public override IComponentRenderMode Mode  => new InteractiveAutoRenderMode(Prerender);
}