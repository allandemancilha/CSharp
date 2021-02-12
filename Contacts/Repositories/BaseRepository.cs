using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Contacts.Model;


namespace Contacts.Repositories
{
    public class BaseRepository
    {
        private string _ProjectDirectoryPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        private string _FilePath = "\\File\\Contacts.csv";
        private string _FullPath;

        private string _BackupDirectoryPath = "\\File\\Backup\\";
        private FileStream FileTxt;
        private StreamReader ReaderTxt;
        private StreamWriter WriterTxt;

        protected BaseRepository()
        {
            _FullPath = _ProjectDirectoryPath + _FilePath;
            NewFile();
        }

        private void NewFile()
        {

            using(FileTxt = new FileStream(_FullPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            { 

            }

            FileTxt.Close();
        }


        protected void RecreateFile()
        {
            try
            {   
                using(FileTxt)
                {
                    FileTxt.Close();
                }
                
                FileInfo infoFile = new FileInfo(_FilePath);

                DirectoryInfo infoDir = new DirectoryInfo(_BackupDirectoryPath);
                int numberFiles = infoDir.GetFiles().Length + 1;
         
                infoFile.CopyTo($"{_BackupDirectoryPath}backup{numberFiles}.txt");
                infoFile.Delete();
 
                NewFile();
            }
            catch (IOException error)
            {
                Console.WriteLine("AN ERROR OCCURRED");
                Console.WriteLine(error.Message);
            }
        }

        protected bool RefreshData(List<string> contactsRefreshed)
        {
            RecreateFile();

            using (WriterTxt = new StreamWriter(_FullPath))
            {
                foreach (string contact in contactsRefreshed)
                {
                    WriterTxt.WriteLine(contact);
                }

                return true;
            }      
        }


        protected void WriteData(string data)
        {
            using (WriterTxt = new StreamWriter(_FullPath))
            {
                WriterTxt.Write(data + Environment.NewLine);
            }
        }

        protected int GenerateId()
        {
            string line = null;
            int numberLines = 0;
            int id = 0;

            using (ReaderTxt = new StreamReader(_FullPath))
            {
                while ((line = ReaderTxt.ReadLine()) != null)
                {
                    numberLines++;
                }
            }

            id = numberLines + 1;

            ReaderTxt.Close();

            return id;
        }


        protected List<string> ContactsExists(int id)
        {
            List<string> contactsFile = ReaderContacts();

            foreach (string contact in contactsFile)
            {
                if (contact.Contains($"ID={id};"))
                {
                    return contactsFile;
                }
            }

            return null;
        }


        protected List<string> ReaderContacts()
        {
            List<string> contactsFile = new List<string>();
            string line = "";

            using (ReaderTxt = new StreamReader(_FullPath))
            {
                while (!this.ReaderTxt.EndOfStream)
                {
                    line = ReaderTxt.ReadLine();
                    contactsFile.Add(line);
                }

                ReaderTxt.Close();

                return contactsFile;
            }
        }


        protected string FormatContact(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            string valueFormat = "";

            foreach (PropertyInfo property in properties)
            {
                var propertyValue = property.GetValue(obj);

                string propertyName = property.Name;

                valueFormat = valueFormat + propertyName.ToUpper() + "=" + propertyValue + ";";
            }

            valueFormat = valueFormat.Remove(valueFormat.Length - 1);

            return valueFormat;
        }


    }
}