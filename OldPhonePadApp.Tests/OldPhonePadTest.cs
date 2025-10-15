namespace OldPhonePadApp.Tests;
using Xunit;

public class OldPhonePadTest
{
    [Theory]
    [InlineData("33#", "E")] 
    [InlineData("227*#", "B")]
    [InlineData("4433555 555666#", "HELLO")]
    [InlineData("8 88777444666*664#", "TURING")]
    public void OldPhonePad_ReturnsExpectedOutput(string input, string expected)
    {
        var result = OldPhonePadSetup.OldPhonePad(input);
        Assert.Equal(expected, result);
    }
}
