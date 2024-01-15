namespace DesafioPOO.Models
{
    // TODO: Herdar da classe "Smartphone"
    public class Iphone : Smartphone
    {
        public Iphone(string numero, string modelo, string imei, int memoria) : base(numero, modelo, imei, memoria) { }
        // TODO: Sobrescrever o método "InstalarAplicativo"
        public override void InstalarAplicativo(string nomeApp)
        {
            Console.WriteLine($"Instalando o aplicativo ''{nomeApp}'' no Iphone");
        }
        public override void PhoneHead()
        {
            Console.WriteLine("||-----------------------------------||");
            Console.WriteLine("||                 ()                ||");
        }
        public override void PhoneButt()
        {

            Console.WriteLine("||-----------------------------------||");
        }
    }
}
