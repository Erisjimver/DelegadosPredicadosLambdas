using System;
using System.Collections.Generic;

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


            //lista de preducados
            List<int> ListaNumeros = new List<int>();
            ListaNumeros.AddRange(new int[] {1,2,3,4,5,6,7,8,9 });
            Predicate<int> elDelegadoPred = new Predicate<int>(DamePares);
            List<int> numPares = ListaNumeros.FindAll(elDelegadoPred);

            foreach (var num in numPares)
            {
                Console.WriteLine(num);
            }


        }
        //definicion del objeto delegado
        delegate void ObjetoDelegado();




        static bool DamePares(int num)
        {
            if (num % 2 == 0) return true;
            else return false;
        }
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
