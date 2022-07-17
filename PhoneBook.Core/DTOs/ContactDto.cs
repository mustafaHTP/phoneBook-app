namespace PhoneBook.Core.DTOs
{
    public class ContactDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string Email { get; set; }
        public string Profession { get; set; }
        public string Address { get; set; }
        public string WebAddress { get; set; }
        public string NickName { get; set; }

    }
}

