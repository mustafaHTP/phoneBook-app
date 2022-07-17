﻿namespace PhoneBook.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
    }
}
