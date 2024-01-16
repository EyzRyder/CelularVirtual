using DesafioPOO.Models;

namespace Celular.Testes;

public class PhoneTest
{
    [Fact]
    public void IphoneVerificarLigacaoOutput()
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
    public void IphoneVerificarReceberLigacaoOutput()
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
    public void IphoneVerificarPhoneHeadOutput()
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
    public void IphoneVerificarPhoneButtOutput()
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
    public void IphoneVerificarInstalacaoOutput()
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
    public void IphoneInstalarAplicativoNoSmartphoneErrado()
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
    public void IphonePhoneNumberIsSameFromeCreated()
    {
        //ARRAGE
        Smartphone Phone = new Iphone(numero:"119123456789",modelo:"Modelo 1",imei:"111111111",memoria:64);
        var expectedPhoneNumber = "119123456789";
        //ACT
        var phoneNumber = Phone.Numero;

        //ASSERT
        Assert.Equal(expectedPhoneNumber,phoneNumber);
    }
    [Fact]

    public void NokiaVerificarLigacaoOutput()
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
    public void NokiaVerificarReceberLigacaoOutput()
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
    public void NokiaVerificarPhoneHeadOutput()
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
    public void NokiaVerificarPhoneButtOutput()
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
    public void NokiaVerificarInstalacaoOutput()
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
    public void NokiaInstalarAplicativoNoSmartphoneErrado()
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
    public void NokiaPhoneNumberIsSameFromeCreated()
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
