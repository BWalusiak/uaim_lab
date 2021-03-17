using System;
using System.Diagnostics;
using MyLib;

namespace Lab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IPersonRepository personRepository = new PersonRepository();

            Debug.Assert(personRepository != null);

            foreach (var person in personRepository.Find(Sex.Male))
            {
                var personDescription = person.GetDescription();
                var canOperate = person.CanOperate();

                Console.WriteLine($"person description = {personDescription}; person can operate = {canOperate}");
            }
        }
    }
}