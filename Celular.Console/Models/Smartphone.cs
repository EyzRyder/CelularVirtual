namespace DesafioPOO.Models
{
    public abstract class Smartphone
    {
        public string Numero { get; set; }
        private string Modelo { get; set; }
        private string IMEI { get; set; }
        private int Memoria { get; set; }
        private bool isOn { get; set; }

        public Smartphone(string numero, string modelo, string imei, int memoria)
        {
            Numero = numero;
            Modelo = modelo;
            IMEI = imei;
            Memoria = memoria;
        }

        public void TurnOn()
        {
            isOn=true;
            string input;
            string screenOption="HELP";

            while(isOn)
            {
                Console.Clear();
                Console.WriteLine("||===================================||");
                Console.WriteLine("||===============o=O=================||");
                Console.WriteLine("||-----------------------------------||");
                Screen(screenOption);
                Console.WriteLine("||-----------------------------------||");
                Console.WriteLine("||-----------------------------------||");
                Console.WriteLine("||        ||       O        >        ||");
                Console.WriteLine("||===================================||");

                if(screenOption == "OFF")
                {
                    return;
                }
                input = Console.ReadLine();

                switch (input)
                {
                    case "q":
                        screenOption="OFF";
                        break;
                    case "h":
                          screenOption="HELP";
                          break;
                    case "c":
                          screenOption="CALCULATOR";
                          break;
                    case "t":
                          screenOption="TIME";
                          break;
                    default:
                        screenOption="HELP";
                        Console.WriteLine("Input Invalido");
                        break;
                }
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadLine();
            }
        }

        public void Screen(string option="BLANK")
        {
            void printEmptyRow(int quantaty)
            {
                for(int i = 0; i < quantaty; i++)
                {
                    Console.WriteLine("||                                   ||");
                }
            }

            switch (option)
            {
                case "BLANK":
                    printEmptyRow(26);
                    break;
                case "HELP":
                    printEmptyRow(11);
                    Console.WriteLine("||-----------------------------------||");
                    Console.WriteLine("||     Digite h - Para ter ajuda     ||");
                    Console.WriteLine("||    Digite c - Abrir Calculador    ||");
                    Console.WriteLine("||     Digite t - Abrir Relogio      ||");
                    Console.WriteLine("||        Digite q - Desligar        ||");
                    Console.WriteLine("||-----------------------------------||");
                    printEmptyRow(11);
                    break;
                case "":
                    break;
                case "OFF":
                    printEmptyRow(13);
                    Console.WriteLine("||         Celular Desligando        ||");
                    printEmptyRow(13);
                    isOn=false;
                    break;
                default:
                    printEmptyRow(26);
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
    }
}
