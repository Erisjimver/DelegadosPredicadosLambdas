using System;

namespace DelegadosPredicadosLambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //creacion del objeto delegado apuntando a mensaje bienvenida
            ObjetoDelegado ElDelegado = new ObjetoDelegado(mensajeBienvenida.SaludoBienvenida);

            //utilizacion del objeto delegado para llamar al metodo saludoBienvenida
            ElDelegado();

            ElDelegado = new ObjetoDelegado(MensajeDespedida.SaludoDespedida);
            ElDelegado();
        }
        //definicion del objeto delegado
        delegate void ObjetoDelegado();
    }

    class mensajeBienvenida
    {
        public static void SaludoBienvenida()
        {
            Console.WriteLine("Hola acabo de llegar. Que tal");
        }
    }

    class MensajeDespedida
    {
        public static void SaludoDespedida()
        {
            Console.WriteLine("Hola ya me marcho. Hasta luego");
        }
    }
}
