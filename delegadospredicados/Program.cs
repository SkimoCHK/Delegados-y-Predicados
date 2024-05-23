namespace delegadospredicados
{
    //BASICAMENTE UN PREDICADO ES LO MISMO QUE UN DELEGADO, SOLO QUE ESTE SOLO REGRESA VALORES BOOLEANOS, TRUE O FALSE
    // ENTONCES, SOLO SE APUNTA A METODOS QUE DEVUELVAN TRUE
    internal class Program
    {


        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            ///AddRange sirve para agregar una coleccion de numeros existentes ala lista!!
            list.AddRange(new int[] { 100, 99, 24, 58, 66, 88, 77, 45, 32, 92, 89, 68, 47, 54, 45 });

            //Declaramos delegado predicado

            Predicate<int> ElDelegadoPredicado = new Predicate<int>(NumerosPares);


           List<int> pares = list.FindAll(ElDelegadoPredicado);
           
            foreach(int i in pares)
            {
                Console.WriteLine(i);
            }

            List<Persona> listaPersonas = new List<Persona>()
            {
                new Persona()
                {
                    Nombre = "Alex",
                    Apellido = "Guillen"
                },
                new Persona() 
                {
                    Nombre = "Skimo",
                    Apellido = "Peraza"
                },
                new Persona()
                {
                    Nombre = "Jose",
                    Apellido = "Santos"
                },
                new Persona()
                {
                    Nombre = "Ivan",
                    Apellido = "Soto"
                },
                new Persona()
                { 
                    Nombre = "Paulina",
                    Apellido = "De leon"
                }
            };

            ////////////
            Predicate<Persona> existePersona = new Predicate<Persona>(ExistePersona);
            bool existePaulina = listaPersonas.Exists(existePersona);
            Console.WriteLine($"¿Existe Paulina? {existePaulina}");

            ///////////
            //Otra forma de hacerlo!
            Predicate<Persona> existePersonav2 = p => p.Nombre == "Alex";
            bool existeAlex = listaPersonas.Exists(existePersona);
            Console.WriteLine($"¿Existe Alex? {existeAlex}");

            ///////////
            //Otra forma de hacerlo!
            //AQUI EN ESTA FORMA PODEMOS VER QUE NO USAMOS PREDICADOS COMO TAL
            //SINO QUE ABREVIAMOS TODO CON UNA EXPRESION LAMBDA
            bool existeJose = listaPersonas.Exists(p => p.Nombre == "Jose");
            Console.WriteLine($"¿Existe Jose? {existeJose}");




        }

        static bool NumerosPares(int x)
        {
            if(x % 2 == 0)
            {
                return true;
            }
            return false;
        }


        static bool ExistePersona(Persona persona)
        {
            if(persona.Nombre == "Paulina") 
                return true;
            return false;
        }
    }

    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
