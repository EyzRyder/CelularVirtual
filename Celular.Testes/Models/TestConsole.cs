namespace Celular.Testes;

public interface IConsole
{
    string ReadLine();
}

public class ConsoleWrapper : IConsole
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}

public class TestableConsole : IConsole
{
    private readonly string _output;

    public TestableConsole(string output)
    {
        _output = output;
    }

    public string ReadLine()
    {
        return _output;
    }
}

