using API.Data;
using API.Models;
using API.Contracts;

namespace API.Repositories;

public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(MCC79DbContext  dBContext) : base(dBContext) { }
    public Employee? GetLast()
    {
        var entity = _context.Set<Employee>().OrderByDescending(employee => employee.Nik).FirstOrDefault();
        _context.ChangeTracker.Clear();
        return entity;
    }
}
