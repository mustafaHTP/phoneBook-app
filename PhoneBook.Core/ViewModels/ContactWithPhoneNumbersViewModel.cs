namespace PhoneBook.Core.DTOs
{
    public class ContactWithPhoneNumbersViewModel : ContactViewModel
    {
        public List<PhoneNumberViewModel> PhoneNumbers { get; set; }
    }
}
