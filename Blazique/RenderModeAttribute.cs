using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Blazique;

public class InteractiveServerRenderModeAttribute : RenderModeAttribute
{
    public override IComponentRenderMode Mode  => RenderMode.InteractiveServer;
}

public class InteractiveWebAssemblyRenderModeAttribute : RenderModeAttribute
{
    public override IComponentRenderMode Mode  => RenderMode.InteractiveWebAssembly;
}

public class InteractiveAutoRenderModeAttribute : RenderModeAttribute
{
    public override IComponentRenderMode Mode  => RenderMode.InteractiveAuto;
}