using DesafioPOO.Models;

namespace Celular.Testes;

public class IphoneTest
{
    [Fact]
    public void VerificarLigacaoOutput()
    {
        // ARRAGE
        Smartphone _iphone = new Iphone(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        var expectedOutput = "Ligando...\r\n";
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _iphone.Ligar();

        // ASSERT
        Assert.Equal(expectedOutput, output.ToString());
    }
    [Fact]
    public void VerificarReceberLigacaoOutput()
    {
        // ARRAGE
        Smartphone _iphone = new Iphone(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        var expectedOutput = "Recebendo ligação...\r\n";
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _iphone.ReceberLigacao();

        // ASSERT
        Assert.Equal(expectedOutput, output.ToString());
    }

    [Fact]
    public void VerificarPhoneHeadOutput()
    {
        // ARRAGE
        Smartphone _iphone = new Iphone(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        var expectedOutput = "||-----------------------------------||\r\n||                 ()                ||\r\n";
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _iphone.PhoneHead();

        // ASSERT
        Assert.Equal(expectedOutput, output.ToString());
    }

    [Fact]
    public void VerificarPhoneButtOutput()
    {
        // ARRAGE
        Smartphone _iphone = new Iphone(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        var expectedOutput = "||-----------------------------------||\r\n";
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _iphone.PhoneButt();

        // ASSERT
        Assert.Equal(expectedOutput, output.ToString());
    }

    [Fact]
    public void VerificarInstalacaoOutput()
    {
        // ARRAGE
        Smartphone _iphone = new Iphone(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        string appName="Telegrame";
        var expectedOutput = $"Instalando o aplicativo ''{appName}'' no Iphone\r\n";
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _iphone.InstalarAplicativo(appName);

        // ASSERT
        Assert.Equal(expectedOutput, output.ToString());
    }

    [Fact]
    public void InstalarAplicativoNoSmartphoneErrado()
    {
        // ARRAGE
        Smartphone _iphone = new Iphone(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        string appName="Telegrame";
        var expectedOutput = $"Instalando o aplicativo ''{appName}'' no Nokia\r\n";
        var output = new StringWriter();
        Console.SetOut(output);

        // ACT
        _iphone.InstalarAplicativo(appName);

        // ASSERT
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
