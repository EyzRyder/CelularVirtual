﻿using System.Text.RegularExpressions;
using DesafioPOO.Models;

void Main(){

    string[] Phones= new []
    {
        "Nokia",
            "Iphone",
    };

    int selectedIndex = SelectIndexFromArray(Phones,"Selecione um Celular: ");

    try
    {
        Console.WriteLine($"{Phones[selectedIndex]} foi selecionado.");
        Smartphone userPhone = createPhone(selectedIndex,Phones);

        userPhone.Ligar();
        userPhone.InstalarAplicativo("Whatsapp");
    }
    catch(Exception err)
    {
        Console.WriteLine(err.Message.ToString());
    }

    Console.WriteLine("\n");

    Console.WriteLine("Smartphone Iphone: ");
    Smartphone iphone = new Iphone(numero:"123456",modelo:"Modelo 1",imei:"111111111",memoria:64);
    iphone.ReceberLigacao();
    iphone.InstalarAplicativo("Telegram");
}

void DrawSelectedMenu(string item)
{
    Console.BackgroundColor = ConsoleColor.White;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine($"> {item}");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;
}

void UpdateMenu(int index, string[] StringList)
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

int SelectIndexFromArray(string[] List, string message = "Select an Value: ")
{

    int previousIndexOfLine=-1, selectedIndexOfLine = 0;
    ConsoleKey pressedKey;

    do
    {
        if(previousIndexOfLine != selectedIndexOfLine)
        {
            Console.Clear();
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


Smartphone createPhone(int index, string[] StringList)
{
    string phoneNumber,phoneImei,phoneModel;
    int phoneMemorie;

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
        Console.WriteLine("Qual seu imei do seu Celular ?");
        phoneImei = Console.ReadLine();
    }
    while (Regex.IsMatch(phoneImei,@"\d{9}")==false);

    Console.Clear();
    Console.WriteLine("Qual seu modelo do seu Celular ?");
    phoneModel = Console.ReadLine();

    do
    {
        Console.Clear();
        Console.WriteLine("Quanto memoria seu Celular tem? ");
        phoneMemorie = Convert.ToInt32(Console.ReadLine());
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

Main();
