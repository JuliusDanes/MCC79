using API.Models;

namespace API.Contracts;

public interface IEmployeeRepository : IGeneralRepository<Employee>
{
    Employee? GetLast();

    Employee? GetByEmail(string email);
}
