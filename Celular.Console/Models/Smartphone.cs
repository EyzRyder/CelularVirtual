using System.Text.RegularExpressions;

namespace DesafioPOO.Models
{
    public abstract class Smartphone
    {
        private string _numero;
        public string Numero
        {
            get => _numero;
            set
            {
                if(value == "")
                {
                    throw new ArgumentException("O numero não pode ser vazio;");
                }

                if(Regex.IsMatch(value,@"\d{11}")==false)
                {
                    throw new ArgumentException("O numero deve conter 11 caracteres, incluindo o dd;");
                }

                _numero =value;
            }
        }

        private string _modelo;
        private string Modelo
        {
            get => _modelo;
            set
            {
                if(value == "")
                {
                    throw new ArgumentException("O modelo não pode ser vazio;");
                }

                _modelo =value;
            }
        }

        private string _imei;
        private string IMEI
        {
            get => _imei;
            set
            {
                if(value == "")
                {
                    throw new ArgumentException("O IMEI não pode ser vazio;");
                }

                if(!Regex.IsMatch(value,@"\d{9}"))
                {
                    throw new ArgumentException("O IMEI deve conter 9 caracteres;");
                }

                _imei = value;
            }
        }

        private int _memoria;
        private int Memoria
        {
            get => _memoria;
            set
            {
                if(value <0)
                {
                    throw new ArgumentException("A memoria não pode ser menor que 0 (zero);");
                }

                _memoria = value;
            }
        }

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

            Mode.TryAdd("HOME",HomeSwitch);
            Mode.TryAdd("CALCULATOR",CalculatorSwitch);
            Mode.TryAdd("CLOCK",ClockSwitch);
            Mode.TryAdd("OFF",NOTHING);
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

                        Console.WriteLine("Digit um numero: ");
                        string userInput = Console.ReadLine();
                        if(float.TryParse(userInput,out float number))
                        {
                            Calculation["n1"]=userInput;
                        }
                    }
                    break;
                case "y":
                    {
                        Console.WriteLine("Digit um numero: ");
                        string userInput = Console.ReadLine();
                        if(float.TryParse(userInput,out float number))
                        {
                            Calculation["n2"]=userInput;
                        }
                    }
                    break;
                case "o":
                    {
                        Console.WriteLine("Digit um simbolo de operação: ");
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

            void printSpaceColumn(int spaces=0)
            {
                for(int i = 0; i< spaces;i++)
                {
                    Console.Write(" ");
                }
            }
            void printTextCenter(string s)
            {
                int stringLength = s.Length;
                float length = 35-stringLength;
                float halfLength = length/2;

                int lengthSides = ((int)halfLength);
                Console.Write("||");
                printSpaceColumn(lengthSides);
                Console.Write(s);
                if((lengthSides*2)==length){
                printSpaceColumn(lengthSides);
                }
                else
                {
                printSpaceColumn(lengthSides+1);
                }
                Console.WriteLine("||");
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
                        printTextCenter("y - mudar 2 numero | o - operacao");
                        Console.WriteLine("||-----------------------------------||");
                        printEmptyRow(2);
                        string textResult = "= "+Calculation["result"];
                        printTextCenter(textResult);
                        string textCalc = Calculation["n1"]+" "+Calculation["operation"]+" "+Calculation["n2"];
                        printTextCenter(textCalc);
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
                        string todaysDate = date.ToString("D");
                        printEmptyRow(1);
                        printTextCenter("s - sair");
                        printEmptyRow(11);
                        printTextCenter(todaysDate);
                        printEmptyRow(11);
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
