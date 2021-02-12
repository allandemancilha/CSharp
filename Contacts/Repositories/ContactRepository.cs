using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Contacts.Model;
using Contacts.DTO;


namespace Contacts.Repositories
{
    public class ContactRepository : BaseRepository
    {
        public ContactRepository()
        {

        }


        public void WriteContact(ContactDTO contactDTO)
        {
            Contact contact = new Contact()
            {
                Id = GenerateId(),
                Name = contactDTO.Name,
                Lastname = contactDTO.Lastname,
                Nickname = contactDTO.Nickname,
                Phone1 = contactDTO.Phone1,
                Phone2 = contactDTO.Phone2
            };

            string valueFormat = FormatContact(contact);

            WriteData(valueFormat);
        }


        public List<Contact> ListContacts()
        {
            List<Contact> contacts = new List<Contact>();

            List<string> contactsList = ReaderContacts();

            foreach (string contact in contactsList)
            {
                if (!contact.Contains("DELETED"))
                {
                    string[] contactSplit = Regex.Replace(contact, @"[A-Z0-9]+=+", "").Split(";");

                    Contact contactParse = new Contact()
                    {
                        Id = int.Parse(contactSplit[0]),
                        Name = contactSplit[1],
                        Lastname = contactSplit[2],
                        Nickname = contactSplit[3],
                        Phone1 = contactSplit[4],
                        Phone2 = contactSplit[5]
                    };

                    contacts.Add(contactParse);
                }
            }
            return contacts;
        }


        public string DeleteContact(int id)
        {
            int index = id - 1;
            List<string> contactsList;

            if ((contactsList = ContactsExists(id)) != null)
            {
                contactsList[index] = contactsList[index].Replace(contactsList[index], "DELETED");

                if (RefreshData(contactsList))
                {
                    return "CONTATO DELETADO";
                }
                else
                {
                    return "OCORREU UM ERRO AO DELETAR OS DADOS DO CONTATO";
                }
            }
            return "CONTATO NÃO ENCONTRADO";
        }


        public string UpdateContact(int id, ContactDTO contactDTO)
        {
            int index = id - 1;
            List<string> contactsList;

            if ((contactsList = ContactsExists(id)) != null)
            {
                string newValue = FormatContact(contactDTO);
                newValue = $"ID={id};{newValue}";

                contactsList[index] = contactsList[index].Replace(contactsList[index], $"{newValue}");

                if (RefreshData(contactsList))
                {
                    return "CONTATO ATUALIZADO";
                }
                else
                {
                    return "OCORREU UM ERRO AO ATUALIZAR OS DADOS DO CONTATO";
                }
            }

            return "CONTATO NÃO ENCONTRADO";
        }
    }
}

