using EmployeeDiscount.Domain.Entities.Interfaces;
using System;

namespace EmployeeDiscount.Domain.Repositories
{
    public interface IRepository<T> where T : IAggregateRoot
    {
    }
}
