using Microsoft.AspNetCore.Components.Web;

namespace Blazique.Benchmarks.Counter;

public class BlaziqueCounter : Web.Component
{
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }

    private static readonly Node[] TitleAndHeader = [
        component<PageTitle>([], [text("Counter")]),
        h1([], [text("Counter")])
    ];

    public override Node[] Render() =>
     [
        .. TitleAndHeader,
        p([role(["status"])], [text($"Current count: {currentCount}")]),
        button([type(["button"]), @class(["btn", "btn-primary"]), on.click(_ => IncrementCount())], [text("Click me")])
    ];
}
