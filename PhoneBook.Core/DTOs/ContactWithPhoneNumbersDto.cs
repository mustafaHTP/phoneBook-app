namespace PhoneBook.Core.DTOs
{
    public class ContactWithPhoneNumbersDto : ContactDto
    {
        public List<PhoneNumberDto> PhoneNumbers { get; set; }
    }
}
