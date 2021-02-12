using System;
using Contacts.Repositories;
using Contacts.DTO;

namespace Contacts.Views
{
    public class Menu
    {
        ContactRepository ContactRepo;

        public Menu()
        {
            ContactRepo = new ContactRepository();
        }

        public void Option()
        {

            int option = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("(1) ADD CONTACT");
                Console.WriteLine("(2) LIST CONTACT");
                Console.WriteLine("(3) DELETE CONTACT");
                Console.WriteLine("(4) UPDATE CONTACT");
                Console.WriteLine("(5) EXIT PROGRAM");
                Console.WriteLine();
                Console.Write("SELECT OPTION: ");
                option = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (option)
                {
                    case 1:
                        this.ContactRepo.WriteContact(GetContact());
                        break;

                    case 2:
                        ShowContacts();
                        break;

                    case 3:
                        ShowContacts();

                        Console.Write("SELECT THE CONTACT TO BE DELETED: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Clear();
                        Console.WriteLine(this.ContactRepo.DeleteContact(id));
                        break;

                    case 4:
                        ShowContacts();

                        Console.Write("SELECT THE CONTACT TO BE UPDATED: ");
                        id = int.Parse(Console.ReadLine());

                        Console.Clear();
                        Console.WriteLine(this.ContactRepo.UpdateContact(id, GetContact()));

                        break;

                    case 5:
                        Console.WriteLine("GOOD BYE :(");
                        break;

                    default:
                        Console.WriteLine("INVALID OPTION!");
                        break;

                }

            } while (option != 4);
        }


        private void ShowContacts()
        {
            var contacts = this.ContactRepo.ListContacts();

            foreach (var contact in contacts)
            {
                Console.WriteLine($"ID: {contact.Id}");
                Console.WriteLine($"NICKNAME: {contact.Nickname}");
                Console.WriteLine($"NAME: {contact.Name}");
                Console.WriteLine($"LASTNAME: {contact.Lastname}");
                Console.WriteLine($"PHONE 1: {contact.Phone1}");
                Console.WriteLine($"PHONE2 2: {contact.Phone2}");
                Console.WriteLine();
            }

            while(true)
            {
                Console.WriteLine("Tecle ENTER Para Voltar ao MENU");
                int keyEnterNumber = Convert.ToInt32(Console.ReadKey());

                if(keyEnterNumber == 13)
                {
                    break;
                }

            } 
        }


        private ContactDTO GetContact()
        {
            ContactDTO contactData = new ContactDTO();

            Console.Write("Name: ");
            contactData.Name = Console.ReadLine();

            Console.Write("Last Name: ");
            contactData.Lastname = Console.ReadLine();

            Console.Write("Nickname: ");
            contactData.Nickname = Console.ReadLine();

            Console.Write("Phone 1: ");
            contactData.Phone1 = Console.ReadLine();

            Console.Write("Phone 2: ");
            contactData.Phone2 = Console.ReadLine();

            return contactData;
        }


    }
}