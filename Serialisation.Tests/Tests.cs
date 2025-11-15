using System.Text.Json;
using Serialisation.Benchmarks;

namespace Serialisation.Tests;

public class Tests
{
    [Test]
    public void Serialize_Equality()
    {
        const int quantity = 10;
        var data = Serilizator.Create(quantity);
        var classJson = JsonSerializer.Serialize<EntityClass[]>(data.Classes, JsonCtx.Default.EntityClassArray);
        var structJson = JsonSerializer.Serialize<EntityStruct[]>(data.Structs, JsonCtx.Default.EntityStructArray);

        Assert.Multiple(() =>
        {
            Assert.That(classJson.Equals(structJson, StringComparison.Ordinal));
            Assert.That(classJson.SequenceEqual(structJson));
        });
    }
}