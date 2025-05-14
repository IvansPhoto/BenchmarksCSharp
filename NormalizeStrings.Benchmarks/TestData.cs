namespace NormalizeStrings.Benchmarks;

public static class TestData
{
    public const string CharsRaw1 = "BlaBalLaTtaa 57123345688955214785\nTraTaaa Rettaddnnnn dfaaf HHUhDFA11P1123H DFD2\n133455642 - 100/2";
    public const string CharsRaw2 = "BlaBalLaTtaa, 57123345688955214785\nTraTaaa Rettaddnnnn dfaaf HHUhDFA11P1123H DFD2\n13345564 - 100/3";
    public const string CharsRaw3 = "BlaBalLaTtaa, 57123345688955214785\nTraTaaa Rettaddnnnn dfaaf; HHUhDFA11P1123H DFD2\n1334556 - 100/4";
    public const string CharsRaw4 = "BlaBalLaTtaa\nTraTaa 25/1";
    
    public const string CharsNormalized1 = "BlaBalLaTtaa 57123345688955214785 TraTaaa Rettaddnnnn dfaaf HHUhDFA11P1123H DFD2 133455642 - 100/2";
    public const string CharsNormalized2 = "BlaBalLaTtaa  57123345688955214785 TraTaaa Rettaddnnnn dfaaf HHUhDFA11P1123H DFD2 13345564 - 100/3";
    public const string CharsNormalized3 = "BlaBalLaTtaa  57123345688955214785 TraTaaa Rettaddnnnn dfaaf  HHUhDFA11P1123H DFD2 1334556 - 100/4";
    public const string CharsNormalized4 = "BlaBalLaTtaa TraTaa 25/1";
}