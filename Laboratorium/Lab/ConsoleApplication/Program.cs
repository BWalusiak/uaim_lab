namespace Lab
{
    using System;
    using MyLib.Models;
    using MyLib.Repositories;

    public class Program
    {
        public static void Main(string[] args)
        {
            IPersonRepository personRepository = new PersonRepository();

            foreach (var person in personRepository.Find(Sex.Male))
            {
                var personDescription = person.GetDescription();
                var canOperate = person.CanOperate();

                Console.WriteLine($"person description = {personDescription}; person can operate = {canOperate}");
            }
        }
    }
}