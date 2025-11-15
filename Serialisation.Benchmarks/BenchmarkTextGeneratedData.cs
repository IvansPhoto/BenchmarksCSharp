using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace Serialisation.Benchmarks;

[MemoryDiagnoser]
[MarkdownExporterAttribute.GitHub]
public class BenchmarkDeserialize
{
    [ParamsSource(nameof(Generator))]
    public string Text { get; set; } = null!;

    public static IEnumerable<string> Generator()
    {
        var data10 = Serilizator.Create(10);
        yield return JsonSerializer.Serialize<EntityClass[]>(data10.Classes, JsonCtx.Default.EntityClassArray);
        var data100 = Serilizator.Create(100);
        yield return JsonSerializer.Serialize<EntityStruct[]>(data100.Structs, JsonCtx.Default.EntityStructArray);
        var data1000 = Serilizator.Create(1000);
        yield return JsonSerializer.Serialize<EntityClass[]>(data1000.Classes, JsonCtx.Default.EntityClassArray);
        var data10000 = Serilizator.Create(10000);
        yield return JsonSerializer.Serialize<EntityStruct[]>(data10000.Structs, JsonCtx.Default.EntityStructArray);
    }

    [Benchmark(Baseline = true)]
    public EntityClass[] DeserializeClass()
    {
        return JsonSerializer.Deserialize<EntityClass[]>(Text, JsonCtx.Default.EntityClassArray) ?? [];
    }

    [Benchmark]
    public EntityStruct[] DeserializeStruct()
    {
        return JsonSerializer.Deserialize<EntityStruct[]>(Text, JsonCtx.Default.EntityStructArray) ?? [];
    }

    [Benchmark]
    public EntityClass[] DeserializeClassReflections()
    {
        return JsonSerializer.Deserialize<EntityClass[]>(Text) ?? [];
    }

    [Benchmark]
    public EntityStruct[] DeserializeStructReflections()
    {
        return JsonSerializer.Deserialize<EntityStruct[]>(Text) ?? [];
    }
}

[MemoryDiagnoser]
[MarkdownExporterAttribute.GitHub]
public sealed class BenchmarkSerialize
{
    [ParamsSource(nameof(Generator))]
    public (EntityStruct[] Structs, EntityClass[] Classes) Data { get; set; }

    public static IEnumerable<(EntityStruct[] Structs, EntityClass[] Classes)> Generator()
    {
        yield return Serilizator.Create(10);
        yield return Serilizator.Create(100);
        yield return Serilizator.Create(1000);
        yield return Serilizator.Create(10000);
    }

    [Benchmark(Baseline = true)]
    public string DeserializeClass()
    {
        return JsonSerializer.Serialize<EntityClass[]>(Data.Classes, JsonCtx.Default.EntityClassArray);
    }

    [Benchmark]
    public string DeserializeStruct()
    {
        return JsonSerializer.Serialize<EntityStruct[]>(Data.Structs, JsonCtx.Default.EntityStructArray);
    }

    [Benchmark]
    public string DeserializeClassReflection()
    {
        return JsonSerializer.Serialize(Data.Classes);
    }

    [Benchmark]
    public string DeserializeClassEff()
    {
        return JsonSerializer.Serialize(Data.Classes);
    }
    
    [Benchmark]
    public string DeserializeStructReflection()
    {
        return JsonSerializer.Serialize(Data.Structs);
    }
}