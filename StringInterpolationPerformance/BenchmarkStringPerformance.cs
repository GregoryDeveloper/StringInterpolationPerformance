using BenchmarkDotNet.Attributes;
using System.Text;

[MemoryDiagnoser]
public class BenchmarkStringPerformance
{
    string message1 = "message 1";
    string message2 = "message 2";
    string message3 = "message 3";
    string message4 = "message 4";
    string message5 = "message 5";

    string message6 = "message 1 ";
    string message7 = "message 2 ";
    string message8 = "message 3 ";
    string message9 = "message 4 ";
    string message10 = "message 5 ";
    StringBuilder sb = new StringBuilder();

   [Benchmark]
    public void StringInterpolation()
    {
        var s = $"Message: {message1} {message2} {message3} {message4} {message5}";
    }

    [Benchmark]
    public void StringFormat()
    {
        var s = String.Format("Message: {0} {1} {2} {3} {4}", message1, message2, message3, message4, message5);
    }

    [Benchmark]
    public void StringConcat()
    {
        var s = string.Concat("Message: ", message6, message7, message8, message9, message10);
    }

    [Benchmark]
    public void StringAddOperator()
    {
        var s = "Message: " + message1 + message2 + message3 + message4 + message5;
    }

    [Benchmark]
    public void StringBuilder()
    {
        sb.Clear();
        sb.Append("Message: ")
            .Append(message1)
            .Append(' ')
            .Append(message2)
            .Append(' ')
            .Append(message3)
            .Append(' ')
            .Append(message4)
            .Append(' ')
            .Append(message5)
            .ToString();
    }

    [Benchmark]
    public void StringBuilderNewInstance()
    {
        new StringBuilder("Message: ")
            .Append(message1)
            .Append(' ')
            .Append(message2)
            .Append(' ')
            .Append(message3)
            .Append(' ')
            .Append(message4)
            .Append(' ')
            .Append(message5)
            .ToString();
    }
}