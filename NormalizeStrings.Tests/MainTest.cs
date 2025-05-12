using NormalizeStrings.Benchmarks;

namespace NormalizeStrings.Tests;

public class Tests
{
    [Test]
    public void TestReplace()
    {
        // Arrange, Act
        var result = NormalizeTextForCsv.Replace(TestData.Chars1);

        // Assert
        Assert.That(result, Does.Not.Contain(NormalizeTextForCsv.CharToReplace[0]));
        Assert.That(result, Does.Not.Contain(NormalizeTextForCsv.CharToReplace[1]));
        Assert.That(result, Does.Not.Contain(NormalizeTextForCsv.CharToReplace[2]));
        Assert.That(result, Does.Not.Contain(NormalizeTextForCsv.CharToReplace[3]));
    }
    
    [Test]
    public void TestSelect()
    {
        // Arrange, Act
        var result = NormalizeTextForCsv.Select(TestData.Chars1);

        // Assert
        Assert.That(result, Does.Not.Contain(NormalizeTextForCsv.CharToReplace[0]));
        Assert.That(result, Does.Not.Contain(NormalizeTextForCsv.CharToReplace[1]));
        Assert.That(result, Does.Not.Contain(NormalizeTextForCsv.CharToReplace[2]));
        Assert.That(result, Does.Not.Contain(NormalizeTextForCsv.CharToReplace[3]));
    }
    
        
    [Test]
    public void TestEquality()
    {
        // Arrange, Act
        var resultSelect1 = NormalizeTextForCsv.Select(TestData.Chars1);
        var resultReplace1 = NormalizeTextForCsv.Replace(TestData.Chars1);

        var resultSelect2 = NormalizeTextForCsv.Select(TestData.Chars2);
        var resultReplace2 = NormalizeTextForCsv.Replace(TestData.Chars2);
        
        var resultSelect3 = NormalizeTextForCsv.Select(TestData.Chars3);
        var resultReplace3 = NormalizeTextForCsv.Replace(TestData.Chars3);
       
        var resultSelect4 = NormalizeTextForCsv.Select(TestData.Chars4);
        var resultReplace4 = NormalizeTextForCsv.Replace(TestData.Chars4);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(resultSelect1.SequenceEqual(resultReplace1), Is.True);
            Assert.That(resultSelect2.SequenceEqual(resultReplace2), Is.True);
            Assert.That(resultSelect3.SequenceEqual(resultReplace3), Is.True);
            Assert.That(resultSelect4.SequenceEqual(resultReplace4), Is.True);
        });
    }
}