using DesafioPOO.Models;

namespace Celular.Testes;

public class IphoneTest
{
    private Smartphone iphone = new Iphone(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);

    [Fact]
    public void VerificarLigacaoOutput()
    {
        // ARRAGE
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        iphone.Ligar();

        // ASSERT
        var expectedOutput = "";
        Assert.Equal(expectedOutput, output.ToString());
    }
}
