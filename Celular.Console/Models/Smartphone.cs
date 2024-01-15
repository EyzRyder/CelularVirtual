namespace DesafioPOO.Models
{
    public abstract class Smartphone
    {
        public string Numero { get; set; }
        private string Modelo { get; set; }
        private string IMEI { get; set; }
        private int Memoria { get; set; }

        private bool isOn { get; set; }
        private string input { get; set; }
        private string screenOption { get; set; }
        private Dictionary <string, Action> Mode = new Dictionary <string, Action>();
        private Dictionary <string, string> Calculation = new Dictionary <string, string>(4)
        {
            {"n1","0"},
                {"operation","+"},
                {"n2","0"},
                {"result","0"},
        };

        public Smartphone(string numero, string modelo, string imei, int memoria)
        {
            Numero = numero;
            Modelo = modelo;
            IMEI = imei;
            Memoria = memoria;

            Console.WriteLine("Istalando Aplicativos do Sistemas ...");
            Mode.TryAdd("HOME",HomeSwitch);
            Mode.TryAdd("CALCULATOR",CalculatorSwitch);
            Mode.TryAdd("CLOCK",ClockSwitch);
            Mode.TryAdd("OFF",NOTHING);
            Console.WriteLine("Aplicativos do Sistemas Istalando");
        }

        private void NOTHING(){
            return;
        }

        public void TurnOn()
        {
            isOn=true;
            screenOption="HOME";
            while(isOn)
            {
                Console.Clear();
                PhoneHead();
                Screen(screenOption);
                PhoneButt();

                input = Console.ReadLine();
                Mode[screenOption]();

                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadLine();
            }
        }

        private void HomeSwitch()
        {

            switch (input)
            {
                case "q":
                    screenOption="OFF";
                    break;
                case "h":
                    screenOption="HOME";
                    break;
                case "c":
                    screenOption="CALCULATOR";
                    break;
                case "r":
                    screenOption="CLOCK";
                    break;
                default:
                    screenOption="HOME";
                    Console.WriteLine("Input Invalido");
                    break;
            }
        }

        private void CalculatorSwitch()
        {
            switch (input)
            {
                case "x":
                    {
                        string userInput = Console.ReadLine();
                        if(float.TryParse(userInput,out float number))
                        {
                            Calculation["n1"]=userInput;
                        }
                    }
                    break;
                case "y":
                    {
                        string userInput = Console.ReadLine();
                        if(float.TryParse(userInput,out float number))
                        {
                            Calculation["n2"]=userInput;
                        }
                    }
                    break;
                case "o":
                    {
                        string userInput = Console.ReadLine();
                        if(userInput.ToLower()=="x" || userInput=="+" || userInput =="-" || userInput =="/")
                        {
                            Calculation["operation"]=userInput;
                        }
                    }
                    break;
                case "s":
                    screenOption="HOME";
                    break;
                default:
                    Console.WriteLine("Input Invalido");
                    break;
            }
        }

        private void ClockSwitch()
        {
            switch (input)
            {
                case "s":
                    screenOption ="HOME";
                    break;
                default:
                    Console.WriteLine("Input Invalido");
                    break;
            }
        }


        public void Screen(string option="BLANK")
        {
            void printEmptyRow(int quantaty=0)
            {
                for(int i = 0; i <= quantaty; i++)
                {
                    Console.WriteLine("||                                   ||");
                }
            }

            switch (option)
            {
                case "BLANK":
                    printEmptyRow(25);
                    break;
                case "HOME":
                    printEmptyRow(10);
                    Console.WriteLine("||-----------------------------------||");
                    Console.WriteLine("||     Digite h - Para ter ajuda     ||");
                    Console.WriteLine("||    Digite c - Abrir Calculador    ||");
                    Console.WriteLine("||     Digite r - Abrir Relogio      ||");
                    Console.WriteLine("||        Digite q - Desligar        ||");
                    Console.WriteLine("||-----------------------------------||");
                    printEmptyRow(9);
                    break;
                case "CALCULATOR":
                    {
                        bool isN1ANumber = float.TryParse(Calculation["n1"],out float n1);
                        bool isN2ANumber = float.TryParse(Calculation["n2"],out float n2);
                        if(isN1ANumber && isN2ANumber)
                        {
                            if(Calculation["operation"]=="+")
                            {
                                Calculation["result"]= (n1+n2).ToString();
                            }
                            if(Calculation["operation"]=="-")
                            {
                                Calculation["result"]= (n1-n2).ToString();
                            }
                            if(Calculation["operation"].ToLower()=="x")
                            {
                                Calculation["result"]= (n1*n2).ToString();
                            }
                            if(Calculation["operation"]=="/")
                            {
                                Calculation["result"]= (n1/n2).ToString();
                            }
                        }
                        Console.WriteLine("|| s - sair | x - mudar 1° numero    ||");
                        Console.WriteLine("|| y - mudar 2° numero | o - operacao||");
                        Console.WriteLine("||-----------------------------------||");
                        printEmptyRow(2);
                        Console.WriteLine($"|| = {Calculation["result"]} ");
                        Console.WriteLine($"||{Calculation["n1"]} {Calculation["operation"]} {Calculation["n2"]}");
                        printEmptyRow(2);
                        Console.WriteLine("||-----------------------------------||");
                        Console.WriteLine("||         |         |         |     ||");
                        Console.WriteLine("||    1    |    2    |    3    |  +  ||");
                        Console.WriteLine("||         |         |         |     ||");
                        Console.WriteLine("||-----------------------------------||");
                        Console.WriteLine("||         |         |         |     ||");
                        Console.WriteLine("||    4    |    5    |    6    |  -  ||");
                        Console.WriteLine("||         |         |         |     ||");
                        Console.WriteLine("||-----------------------------------||");
                        Console.WriteLine("||         |         |         |     ||");
                        Console.WriteLine("||    7    |    8    |    9    |  x  ||");
                        Console.WriteLine("||         |         |         |     ||");
                        Console.WriteLine("||-----------------------------------||");
                        Console.WriteLine("||         |         |         |     ||");
                        Console.WriteLine("||         |    0    |         |  /  ||");
                        Console.WriteLine("||         |         |         |     ||");
                    }
                    break;
                case "CLOCK":
                    {
                        DateTime date = DateTime.Today;

                        printEmptyRow(12);
                        Console.WriteLine($"{date.ToString("D")}");
                        printEmptyRow(12);
                    }
                    break;
                case "OFF":
                    printEmptyRow(12);
                    Console.WriteLine("||         Celular Desligando        ||");
                    printEmptyRow(12);
                    isOn=false;
                    break;
                default:
                    printEmptyRow(25);
                    break;
            }

        }

        public void Ligar()
        {
            Console.WriteLine("Ligando...");
        }

        public void ReceberLigacao()
        {
            Console.WriteLine("Recebendo ligação...");
        }

        public abstract void InstalarAplicativo(string nomeApp);
        public  abstract void PhoneHead();
        public  abstract void PhoneButt();

    }
}
