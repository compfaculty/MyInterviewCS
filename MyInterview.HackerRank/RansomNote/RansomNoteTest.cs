namespace MyInterview.Test.RansomNote;

public class RansomNoteTest
{
    [Theory]
    [InlineData("Give them me grows a money", "Give me a money", true)]
    [InlineData("Ruzzia go fuck youself", "Give me a money", false)]
    [InlineData("", "", true)]
    public void TestRun(string magazine, string note, bool retVal)
    {
        var res = RansomNote.Run(magazine.Split(" "), note.Split(" "));
        Assert.Equal(retVal, res);
    }
}