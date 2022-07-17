namespace PhoneBook.Core.DTOs
{
    public class PhoneNumberUpdateDto : BaseDto
    {
        public int ContactId { get; set; }
        public string PhoneNo { get; set; }
    }
}
