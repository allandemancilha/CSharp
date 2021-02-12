namespace Contacts.DTO
{
    public class ContactDTO
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }

        public ContactDTO ()
        {
            this.Name = "";
            this.Lastname = "";
            this.Nickname = "";
            this.Phone1 = "";
            this.Phone2 = "";
        }    
    }
}