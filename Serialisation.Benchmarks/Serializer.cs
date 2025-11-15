using System.Text.Json;
using System.Text.Json.Serialization;

namespace Serialisation.Benchmarks;

public static class Serilizator
{
    public static (EntityStruct[] Structs, EntityClass[] Classes) Create(int quantity)
    {
        var data = Enumerable
            .Range(0, quantity)
            .Select(i =>
            {
                var dateTime = DateOnly.FromDateTime(DateTime.UtcNow).ToDateTime(new TimeOnly());
                var guid = Guid.CreateVersion7();

                var integer3 = dateTime.Ticks;
                var integer1 = guid.GetHashCode();
                var string1 = guid.ToString();
                var string2 = dateTime.ToString("O");
                var integer2 = i;
                var string3 = integer2.ToString();

                var entityStruct = new EntityStruct
                {
                    Guid = guid,
                    DateTime = dateTime,
                    Integer1 = integer1,
                    Integer2 = integer2,
                    Integer3 = integer3,
                    String1 = string1,
                    String2 = string2,
                    String3 = string3
                };
                var entityClass = new EntityClass
                {
                    Guid = guid,
                    DateTime = dateTime,
                    Integer1 = integer1,
                    Integer2 = integer2,
                    Integer3 = integer3,
                    String1 = string1,
                    String2 = string2,
                    String3 = string3
                };

                return (EntityStruct: entityStruct, EntityClass: entityClass);
            })
            .ToArray();

        return (
            data.Select(tuple  => tuple.EntityStruct).ToArray(),
            data.Select(tuple => tuple.EntityClass).ToArray()
        );
    }
}

public sealed record EntityClass
{
    [JsonPropertyName("Id")]
    public required Guid Guid { get; init; }

    [JsonPropertyName("DateTime")]
    public required DateTime DateTime { get; init; }

    [JsonPropertyName("Integer1")]
    public required int Integer1 { get; init; }

    [JsonPropertyName("Integer2")]
    public required int Integer2 { get; init; }

    [JsonPropertyName("Integer3")]
    public required long Integer3 { get; init; }

    [JsonPropertyName("IntegerZero")]
    public int IntegerZero { get; init; }

    [JsonPropertyName("String1")]
    public required string String1 { get; init; }

    [JsonPropertyName("String2")]
    public required string String2 { get; init; }

    [JsonPropertyName("String3")]
    public required string String3 { get; init; }

    [JsonPropertyName("StringNull")]
    public string? StringNull { get; init; }
}

public readonly record struct EntityStruct
{
    [JsonPropertyName("Id")]
    public required Guid Guid { get; init; }

    [JsonPropertyName("DateTime")]
    public required DateTime DateTime { get; init; }

    [JsonPropertyName("Integer1")]
    public required int Integer1 { get; init; }

    [JsonPropertyName("Integer2")]
    public required int Integer2 { get; init; }

    [JsonPropertyName("Integer3")]
    public required long Integer3 { get; init; }

    [JsonPropertyName("IntegerZero")]
    public int IntegerZero { get; init; }

    [JsonPropertyName("String1")]
    public required string String1 { get; init; }

    [JsonPropertyName("String2")]
    public required string String2 { get; init; }

    [JsonPropertyName("String3")]
    public required string String3 { get; init; }

    [JsonPropertyName("StringNull")]
    public string? StringNull { get; init; }
}

[JsonSourceGenerationOptions(WriteIndented = true, RespectNullableAnnotations = true)]
[JsonSerializable(typeof(EntityClass[]))]
[JsonSerializable(typeof(EntityStruct[]))]
public partial class JsonCtx : JsonSerializerContext;