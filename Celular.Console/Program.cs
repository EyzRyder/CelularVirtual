using System.Text.RegularExpressions;
using DesafioPOO.Models;

internal class Program
{
    public static void Main(){

        string[] Phones= new [] {"Nokia","Iphone"};

        int selectedIndex = SelectIndexFromArray(Phones,"Selecione um Celular: ");

        try
        {
            Console.WriteLine($"{Phones[selectedIndex]} foi selecionado.");
            Smartphone userPhone = createPhone(selectedIndex,Phones);

            userPhone.Ligar();
            userPhone.InstalarAplicativo("Whatsapp");

            Console.WriteLine("\n");
            if(selectedIndex==0)
            {
                Console.WriteLine("Smartphone Iphone: ");
                Smartphone iphone = new Iphone(numero:"123456",modelo:"Modelo 1",imei:"111111111",memoria:64);
                iphone.ReceberLigacao();
                iphone.InstalarAplicativo("Telegram");
            }
            if(selectedIndex==1)
            {
                Console.WriteLine("Smartphone Nokia: ");
                Smartphone nokia = new Nokia(numero:"123456",modelo:"Modelo 1",imei:"111111111",memoria:64);
                nokia.ReceberLigacao();
                nokia.InstalarAplicativo("Telegram");
            }
            Console.ReadLine();
            userPhone.TurnOn();
        }
        catch(Exception err)
        {
            Console.WriteLine(err.Message.ToString());
        }
    }

    public static void DrawSelectedMenu(string item)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine($"> {item}");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void UpdateMenu(int index, string[] StringList)
    {
        foreach (var item in StringList)
        {
            bool isSelected = item == StringList[index];
            if(isSelected)
            {
                DrawSelectedMenu(item);
            } else{
                Console.WriteLine($" {item}");
            }
        }
    }

    public static int SelectIndexFromArray(string[] List, string message = "Select an Value: ")
    {

        int previousIndexOfLine=-1, selectedIndexOfLine = 0;
        ConsoleKey pressedKey;

        do
        {
            if(previousIndexOfLine != selectedIndexOfLine)
            {
                Console.Clear();
                Console.WriteLine(message);
                UpdateMenu(selectedIndexOfLine,List);
                previousIndexOfLine = selectedIndexOfLine;
            }

            pressedKey = Console.ReadKey().Key;

            if(pressedKey == ConsoleKey.DownArrow && selectedIndexOfLine+1<List.Length)
            {
                selectedIndexOfLine++;
            }
            else if (pressedKey == ConsoleKey.UpArrow && selectedIndexOfLine - 1 >= 0)
            {
                selectedIndexOfLine--;
            }

        } while (pressedKey != ConsoleKey.Enter );

        return selectedIndexOfLine;

    }


    public static Smartphone createPhone(int index, string[] StringList)
    {
        string phoneNumber,phoneImei,phoneModel;
        int phoneMemorie;
        string[] memoria= new [] {"32","64","120","240"};
        do
        {
            Console.Clear();
            Console.WriteLine("Qual seu numero do seu Celular? (ex: 11999999999)");
            phoneNumber = Console.ReadLine();
        }
        while(Regex.IsMatch(phoneNumber,@"\d{11}")==false);

        do
        {
            Console.Clear();
            Console.WriteLine("Qual seu imei do seu Celular? (ex: 111111111)");
            phoneImei = Console.ReadLine();
        }
        while (Regex.IsMatch(phoneImei,@"\d{9}")==false);

        Console.Clear();
        Console.WriteLine("Qual seu modelo do seu Celular ?");
        phoneModel = Console.ReadLine();

        do
        {
            int memoriaIndex=SelectIndexFromArray(memoria,"Quanto memoria seu Celular tem?");
            phoneMemorie = Convert.ToInt32(memoria[memoriaIndex]);
        } while (phoneMemorie<1);

        Console.Clear();

        if(StringList[index] == StringList[0])
        {
            Console.WriteLine("Smartphone Nokia: ");
            Smartphone nokia = new Nokia(numero:phoneNumber,modelo:phoneModel,imei:phoneImei,memoria:phoneMemorie);
            return nokia;
        }
        else if(StringList[index] == StringList[1])
        {
            Console.WriteLine("Smartphone Iphone: ");
            Smartphone Iphone = new Iphone(numero:phoneNumber,modelo:phoneModel,imei:phoneImei,memoria:phoneMemorie);
            return Iphone;
        }
        throw new InvalidOperationException("Invalid index");
    }
}
