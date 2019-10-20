using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        enum Jours
        {
            Lundi, //Lundi vaut 0
            Mardi, //Mardi vaut 1
            Mercredi, //...
	        Jeudi,
            Vendredi,
            Samedi,
            Dimanche
        }


        static void Main(string[] args)
        {
            testCSharp();
            bonjour();

            Console.WriteLine(ConsoleKey.E.Equals(Console.ReadKey()));

        }

        static void bonjour()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                if(DateTime.Now.Hour <= 18)
                {
                    Console.WriteLine("Nous sommes samedi, 18h n'est pas encore passé");
                }
            }
        }







        static void testCSharp()
        {
            Console.WriteLine("Heeey you there \n");
            Console.WriteLine("\t I see you over there");

            //TAB
            string[] tab = new string[] { "hey", "coucou", "hola" };

            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine(tab[i]);
            }


            //LIST
            List<int> liste = new List<int>();
            liste.Add(1);
            liste.Add(2);
            liste.Add(3);

            foreach (int element in liste)
            {
                Console.WriteLine(element);
            }


            //.NET
            Console.WriteLine(Environment.UserName);


            Complex c = Complex.One;
            Console.WriteLine(c);
            Console.WriteLine("Partie réelle : " + c.Real);
            Console.WriteLine("Partie imaginaire : " + c.Imaginary);
        }
    }
}
