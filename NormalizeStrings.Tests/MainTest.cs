using NormalizeStrings.Benchmarks;

namespace NormalizeStrings.Tests;

public class Tests
{
    [Test]
    public void TestReplace()
    {
        // Arrange, Act
        var result1 = NormalizeTextForCsv.Replace(TestData.CharsRaw1);
        var result2 = NormalizeTextForCsv.Replace(TestData.CharsRaw2);
        var result3 = NormalizeTextForCsv.Replace(TestData.CharsRaw3);
        var result4 = NormalizeTextForCsv.Replace(TestData.CharsRaw4);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result1.SequenceEqual(TestData.CharsNormalized1), Is.True);
            Assert.That(result2.SequenceEqual(TestData.CharsNormalized2), Is.True);
            Assert.That(result3.SequenceEqual(TestData.CharsNormalized3), Is.True);
            Assert.That(result4.SequenceEqual(TestData.CharsNormalized4), Is.True);
        });
    }
    
    [Test]
    public void TestStringNewSelect()
    {
        // Arrange, Act
        var resultSelect1 = NormalizeTextForCsv.StringNewSelect(TestData.CharsRaw1);
        var resultSelect2 = NormalizeTextForCsv.StringNewSelect(TestData.CharsRaw2);
        var resultSelect3 = NormalizeTextForCsv.StringNewSelect(TestData.CharsRaw3);
        var resultSelect4 = NormalizeTextForCsv.StringNewSelect(TestData.CharsRaw4);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultSelect1.SequenceEqual(TestData.CharsNormalized1), Is.True);
            Assert.That(resultSelect2.SequenceEqual(TestData.CharsNormalized2), Is.True);
            Assert.That(resultSelect3.SequenceEqual(TestData.CharsNormalized3), Is.True);
            Assert.That(resultSelect4.SequenceEqual(TestData.CharsNormalized4), Is.True);
        });
    }
    
    [Test]
    public void TestReplaceRegex()
    {
        // Arrange, Act
        var resultSelect1 = NormalizeTextForCsv.ReplaceRegex(TestData.CharsRaw1);
        var resultSelect2 = NormalizeTextForCsv.ReplaceRegex(TestData.CharsRaw2);
        var resultSelect3 = NormalizeTextForCsv.ReplaceRegex(TestData.CharsRaw3);
        var resultSelect4 = NormalizeTextForCsv.ReplaceRegex(TestData.CharsRaw4);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultSelect1.SequenceEqual(TestData.CharsNormalized1), Is.True);
            Assert.That(resultSelect2.SequenceEqual(TestData.CharsNormalized2), Is.True);
            Assert.That(resultSelect3.SequenceEqual(TestData.CharsNormalized3), Is.True);
            Assert.That(resultSelect4.SequenceEqual(TestData.CharsNormalized4), Is.True);
        });
    }    
    
    [Test]
    public void TestStringBuilder()
    {
        // Arrange, Act
        var resultSelect1 = NormalizeTextForCsv.StringBuilder(TestData.CharsRaw1);
        var resultSelect2 = NormalizeTextForCsv.StringBuilder(TestData.CharsRaw2);
        var resultSelect3 = NormalizeTextForCsv.StringBuilder(TestData.CharsRaw3);
        var resultSelect4 = NormalizeTextForCsv.StringBuilder(TestData.CharsRaw4);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultSelect1.SequenceEqual(TestData.CharsNormalized1), Is.True);
            Assert.That(resultSelect2.SequenceEqual(TestData.CharsNormalized2), Is.True);
            Assert.That(resultSelect3.SequenceEqual(TestData.CharsNormalized3), Is.True);
            Assert.That(resultSelect4.SequenceEqual(TestData.CharsNormalized4), Is.True);
        });
    }

    [Test]
    public void TestStringCreateReplace()
    {
        // Arrange, Act
        var resultSelect1 = NormalizeTextForCsv.StringCreateReplace(TestData.CharsRaw1);
        var resultSelect2 = NormalizeTextForCsv.StringCreateReplace(TestData.CharsRaw2);
        var resultSelect3 = NormalizeTextForCsv.StringCreateReplace(TestData.CharsRaw3);
        var resultSelect4 = NormalizeTextForCsv.StringCreateReplace(TestData.CharsRaw4);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultSelect1.SequenceEqual(TestData.CharsNormalized1), Is.True);
            Assert.That(resultSelect2.SequenceEqual(TestData.CharsNormalized2), Is.True);
            Assert.That(resultSelect3.SequenceEqual(TestData.CharsNormalized3), Is.True);
            Assert.That(resultSelect4.SequenceEqual(TestData.CharsNormalized4), Is.True);
        });
    }
    
    
    [Test]
    public void TestValueStringBuilder()
    {
        // Arrange, Act
        var resultSelect1 = NormalizeTextForCsv.ValueStringBuilder(TestData.CharsRaw1);
        var resultSelect2 = NormalizeTextForCsv.ValueStringBuilder(TestData.CharsRaw2);
        var resultSelect3 = NormalizeTextForCsv.ValueStringBuilder(TestData.CharsRaw3);
        var resultSelect4 = NormalizeTextForCsv.ValueStringBuilder(TestData.CharsRaw4);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultSelect1.SequenceEqual(TestData.CharsNormalized1), Is.True);
            Assert.That(resultSelect2.SequenceEqual(TestData.CharsNormalized2), Is.True);
            Assert.That(resultSelect3.SequenceEqual(TestData.CharsNormalized3), Is.True);
            Assert.That(resultSelect4.SequenceEqual(TestData.CharsNormalized4), Is.True);
        });
    }
}