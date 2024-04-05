using Microsoft.AspNetCore.Components.Web;

namespace Blazique.Benchmarks.Counter;

public class BlaziqueCounter : Web.Component
{
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }

    public override Node[] Render() =>
     [
        component<PageTitle>([], [text("Counter")]),
        h1([], [text("Counter")]),
        p([role(["status"])], [text("Current count: "), text(currentCount)]),
        button([type(["button"]), @class(["btn", "btn-primary"]), on.click(_ => IncrementCount())], [text("Click me")])
    ];
}
