using API.Data;
using API.Models;
using API.Contracts;

namespace API.Repositories;

public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(MCC79DbContext  dBContext) : base(dBContext) { }
}
