namespace PhoneBook.Core.DTOs
{
    public class PhoneNumbersWithContactDto : PhoneNumberDto
    {
        public ContactDto Contact { get; set; }
    }
}
