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

            //lista predicados persona
            List<Personas> gente = new List<Personas>();
            Personas P1 = new Personas();
            P1.Nombre = "Israel";
            P1.Edad = 26;

            Personas P2 = new Personas();
            P2.Nombre = "Juan";
            P2.Edad = 12;

            Personas P3 = new Personas();
            P3.Nombre = "Maria";
            P3.Edad = 14;

            gente.AddRange(new Personas[] {P1,P2,P3 });

            Predicate<Personas> elPredicado = new Predicate<Personas>(ExisteIsrael);

            bool existe = gente.Exists(elPredicado);

            if (existe) Console.WriteLine("hay personas que se llaman Israel");
            else Console.WriteLine("No hay personas que se llaman Israel");


            Predicate<Personas> elPredicado2 = new Predicate<Personas>(Existemayor);

            bool existe2 = gente.Exists(elPredicado2);

            if (existe2) Console.WriteLine("Hay personas mayores de edad");
            else Console.WriteLine("No hay personas mayores de edad");

        }
        //definicion del objeto delegado
        delegate void ObjetoDelegado();



        //estatis de numeros pares ejemplo predicado 1
        static bool DamePares(int num)
        {
            if (num % 2 == 0) return true;
            else return false;
        }

        //ejempli predicado dos existe X persona

        static bool ExisteIsrael(Personas persona)
        {
            if (persona.Nombre == "Israel") return true;
            else return false;
        }
        static bool Existemayor(Personas persona)
        {
            if (persona.Edad >=18) return true;
            else return false;
        }
    }

    class Personas
    {

        private string nombre;
        private int edad;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Edad { get => edad; set => edad = value; }

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
