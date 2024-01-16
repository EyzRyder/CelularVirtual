
using DesafioPOO.Models;

namespace Celular.Testes;

public class NokiaTest
{
    [Fact]
    public void VerificarLigacaoOutput()
    {
        // ARRAGE
        Smartphone _nokia = new Nokia(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        var expectedOutput = "Ligando...\r\n";
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _nokia.Ligar();

        // ASSERT
        Assert.Equal(expectedOutput, output.ToString());
    }
    [Fact]
    public void VerificarReceberLigacaoOutput()
    {
        // ARRAGE
        Smartphone _nokia = new Nokia(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        var expectedOutput = "Recebendo ligação...\r\n";
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _nokia.ReceberLigacao();

        // ASSERT
        Assert.Equal(expectedOutput, output.ToString());
    }

    [Fact]
    public void VerificarPhoneHeadOutput()
    {
        // ARRAGE
        Smartphone _nokia = new Nokia(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        var expectedOutput = "||===================================||\r\n||==()=o==========----===============||\r\n||-----------------------------------||\r\n";
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _nokia.PhoneHead();

        // ASSERT
        Assert.Equal(expectedOutput, output.ToString());
    }

    [Fact]
    public void VerificarPhoneButtOutput()
    {
        // ARRAGE
        Smartphone _nokia = new Nokia(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        var expectedOutput = "||-----------------------------------||\r\n||        ||        ()      >        ||\r\n||===================================||\r\n";
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _nokia.PhoneButt();

        // ASSERT
        Assert.Equal(expectedOutput, output.ToString());
    }

    [Fact]
    public void VerificarInstalacaoOutput()
    {
        // ARRAGE
        Smartphone _nokia = new Nokia(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        string appName="Telegrame";
        var expectedOutput = $"Instalando o aplicativo ''{appName}'' no Nokia\r\n";
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _nokia.InstalarAplicativo(appName);

        // ASSERT
        Assert.Equal(expectedOutput, output.ToString());
    }

    [Fact]
    public void InstalarAplicativoNoSmartphoneErrado()
    {
        // ARRAGE
        Smartphone _nokia = new Nokia(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        string appName="Telegrame";
        var expectedOutput = $"Instalando o aplicativo ''{appName}'' no Iphone\r\n";
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _nokia.InstalarAplicativo(appName);

        // ASSERT
        Assert.NotEqual(expectedOutput, output.ToString());
    }

    [Fact]
    public void PhoneNumberIsSameFromeCreated()
    {
        //ARRAGE
        Smartphone Phone = new Nokia(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        var expectedPhoneNumber = "119123456789";
        //ACT
        var phoneNumber = Phone.Numero;

        //ASSERT
        Assert.Equal(expectedPhoneNumber,phoneNumber);
    }
}
