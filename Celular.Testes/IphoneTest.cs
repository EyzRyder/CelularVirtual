using DesafioPOO.Models;

namespace Celular.Testes;

public class IphoneTest
{
    private Smartphone _iphone = new Iphone(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);

    [Fact]
    public void VerificarLigacaoOutput()
    {
        // ARRAGE
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _iphone.Ligar();

        // ASSERT
        var expectedOutput = "Ligando...\r\n";
        Assert.Equal(expectedOutput, output.ToString());
    }
    [Fact]
    public void VerificarReceberLigacaoOutput()
    {
        // ARRAGE
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _iphone.ReceberLigacao();

        // ASSERT
        var expectedOutput = "Recebendo ligação...\r\n";
        Assert.Equal(expectedOutput, output.ToString());
    }

    [Fact]
    public void VerificarPhoneHeadOutput()
    {
        // ARRAGE
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _iphone.PhoneHead();

        // ASSERT
        var expectedOutput = "||-----------------------------------||\r\n||                 ()                ||\r\n";
        Assert.Equal(expectedOutput, output.ToString());
    }

    [Fact]
    public void VerificarPhoneButtOutput()
    {
        // ARRAGE
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _iphone.PhoneButt();

        // ASSERT
        var expectedOutput = "||-----------------------------------||\r\n";
        Assert.Equal(expectedOutput, output.ToString());
    }

    [Fact]
    public void VerificarInstalacaoOutput()
    {
        // ARRAGE
        string appName="Telegrame";
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _iphone.InstalarAplicativo(appName);

        // ASSERT
        var expectedOutput = $"Instalando o aplicativo ''{appName}'' no Iphone\r\n";
        Assert.Equal(expectedOutput, output.ToString());
    }

    [Fact]
    public void InstalarAplicativoNoSmartphoneErrado()
    {
        // ARRAGE
        string appName="Telegrame";
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _iphone.InstalarAplicativo(appName);

        // ASSERT
        var expectedOutput = $"Instalando o aplicativo ''{appName}'' no Nokia\r\n";
        Assert.NotEqual(expectedOutput, output.ToString());
    }

    [Fact]
    public void PhoneNumberIsSameFromeCreated()
    {
        //ARRAGE
        Smartphone Phone = new Iphone(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        var expectedPhoneNumber = "119123456789";
        //ACT
        var phoneNumber = Phone.Numero;

        //ASSERT
        Assert.Equal(expectedPhoneNumber,phoneNumber);
    }
}
