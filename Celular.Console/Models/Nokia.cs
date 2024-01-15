namespace DesafioPOO.Models
{
    // TODO: Herdar da classe "Smartphone"
    public class Nokia: Smartphone
    {
        public Nokia(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria) { }
        // TODO: Sobrescrever o método "InstalarAplicativo"
        public override void InstalarAplicativo(string nomeApp)
        {
            Console.WriteLine($"Instalando o aplicativo ''{nomeApp}'' no Nokia");

        }
        public override void PhoneHead()
        {
            Console.WriteLine("||===================================||");
            Console.WriteLine("||==()=o==========----===============||");
            Console.WriteLine("||-----------------------------------||");
        }
        public override void PhoneButt()
        {

            Console.WriteLine("||-----------------------------------||");
            Console.WriteLine("||        ||        ()      >        ||");
            Console.WriteLine("||===================================||");
        }
    }
}
