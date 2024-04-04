using Radix;

namespace Blazique;

/// <summary>
/// Provides factory methods for creating attributes
/// </summary>
public static class Attribute
{
    public static Data.Attribute Create<T>(string[] values, int nodeId = 0)
        where T : Literal<T>, AttributeName
        =>
        (_, builder)
            =>
        {
            if (values.Length > 0)
                builder.AddAttribute(nodeId, T.Format(), values.Aggregate((current, next) => $"{current} {next}"));

        };

    public static Data.Attribute Create(string name, object[] values, int nodeId = 0)
        =>
            (_, builder)
                =>
            {
                if (values.Length > 0)
                    builder.AddAttribute(nodeId, name, values.Aggregate((current, next) => $"{current} {next}"));

            };
}
