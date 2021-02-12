using System.Collections.Generic;



namespace Contacts.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        public Contact (){

            this.Id = 0;
            this.Name = "";
            this.Lastname = "";
            this.Nickname = "";
            this.Phone1 = "";
            this.Phone2 = "";
        }
        
    }
}