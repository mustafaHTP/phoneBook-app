﻿namespace PhoneBook.Core.Models
{
    public class PhoneNumber : BaseEntity
    {
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public string PhoneNo { get; set; }
    }
}
