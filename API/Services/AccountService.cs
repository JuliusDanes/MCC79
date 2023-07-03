using API.Contracts;
using API.DTOs;
using API.DTOs.Accounts;
using API.DTOs.Universities;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.Claims;
using System.Security.Principal;
using System.Security.Claims;

namespace API.Services;

public class AccountService
{
    private readonly IAccountRepository _servicesRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUniversityRepository _universityRepository;
    private readonly IEducationRepository _educationRepository;
    private readonly ITokenHandler _tokenHandler;

    public AccountService(IAccountRepository repository,
                         IEmployeeRepository employeeRepository,
                         IUniversityRepository universityRepository,
                         IEducationRepository educationRepository,
                         ITokenHandler tokenHandler)
    {
        _servicesRepository = repository;
        _employeeRepository = employeeRepository;
        _universityRepository = universityRepository;
        _educationRepository = educationRepository;
        _tokenHandler = tokenHandler;
    }
    public RegisterDto? Register(RegisterDto registerDto)
    {
        EmployeeService employeService = new EmployeeService(_employeeRepository);
        Employee employee = new Employee
        {
            Guid = new Guid(),
            Nik = employeService.GenerateNik(),
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            BirthDate = registerDto.BirthDate,
            Gender = registerDto.Gender,
            HiringDate = registerDto.HiringDate,
            Email = registerDto.Email,
            PhoneNumber = registerDto.PhoneNumber,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var createdEmployee = _employeeRepository.Create(employee);
        if (createdEmployee is null)
        {
            return null;
        }


        University university = new University
        {
            Guid = new Guid(),
            Code = registerDto.UniversityCode,
            Name = registerDto.UniversityName
        };

        var createdUniversity = _universityRepository.Create(university);
        if (createdUniversity is null)
        {
            return null;
        }

        Education education = new Education
        {
            Guid = employee.Guid,
            Major = registerDto.Major,
            Degree = registerDto.Degree,
            Gpa = registerDto.Gpa,
            UniversityGuid = university.Guid

        };

        var createdEducation = _educationRepository.Create(education);
        if (createdEducation is null)
        {
            return null;
        }

        Account account = new Account
        {
            Guid = employee.Guid,
            Password = HashingHandler.HashPassword(registerDto.Password),
            ConfirmPassword = registerDto.ConfirmPassword
        };

        var createdAccount = _servicesRepository.Create(account);
        if (createdAccount is null)
        {
            return null;
        }


        var toDto = new RegisterDto
        {
            FirstName = createdEmployee.FirstName,
            LastName = createdEmployee.LastName,
            BirthDate = createdEmployee.BirthDate,
            Gender = createdEmployee.Gender,
            HiringDate = createdEmployee.HiringDate,
            Email = createdEmployee.Email,
            PhoneNumber = createdEmployee.PhoneNumber,
            Password = createdAccount.Password,
            Major = createdEducation.Major,
            Degree = createdEducation.Degree,
            Gpa = createdEducation.Gpa,
            UniversityCode = createdUniversity.Code,
            UniversityName = createdUniversity.Name
        };

        return toDto;
    }

    public string Login(LoginDto login)
    {
        var employee = _employeeRepository.GetByEmail(login.Email);
        if (employee is null)
            return "0";

        var account = _servicesRepository.GetByGuid(employee.Guid);
        if (account is null)
            return "0";

        if (!HashingHandler.Validate(login.Password, account!.Password))
            return "-1";


        var claims = new List<Claim>()
        {
            new Claim("NIK", employee.Nik),
            new Claim("FullName", $"{employee.FirstName} {employee.LastName}"),
            new Claim("Email", employee.Email)
        };

        claims.AddRange(accountRole.Select(role => new Claim("Role", role.RoleGuid.ToString())));

        try
        {
            var getToken = _tokenHandler.GenerateToken(claims);
            return getToken;
        }
        catch
        {
            return "-2";
        }
    }
    public int GenerateOtp()
    {
        Random random = new Random();
        int otp = random.Next(100000, 999999);
        return otp;
    }

    public ForgetPasswordDto? ForgotPassword(string email)
    {
        // Get Employee Account By Email
        var entityEmployee = _employeeRepository.GetAll().Where(employee => employee.Email == email).FirstOrDefault();

        if (entityEmployee is null)
        {
            return null;
        }

        // Get Related Account By Guid
        var entityAccount = _servicesRepository.GetAll().Where(account => account.Guid == entityEmployee.Guid).FirstOrDefault();

        if (entityAccount is null)
        {
            return null;
        }

        // Generate OTP and Expired Time For 5 Minutes
        int otp = GenerateOtp();
        DateTime expiredTime = DateTime.Now.AddMinutes(5);

        // Update Otp, Expired Time, isUsed in Account
        var toAccountDto = new UpdateAccountDto
        {
            Guid = entityAccount.Guid,
            Password = entityAccount.Password,
            IsDeleted = entityAccount.IsDeleted,
            Otp = otp,
            IsUsed = false,
            ExpiredTime = expiredTime
        };
        UpdateAccount(toAccountDto);

        // Create OTP and Update the Account Model
        var toDto = new ForgetPasswordDto
        {
            Email = entityEmployee.Email,
            Otp = otp,
            ExpiredTime = expiredTime
        };

        return toDto;
    }
    public IEnumerable<GetAccountDto>? GetAccount()
    {
        var entities = _servicesRepository.GetAll();
        if(!entities.Any()) 
        {
            return null;
        }

        var Dto = entities.Select(entity => new GetAccountDto
        {
            Guid = entity.Guid,
            IsDeleted = entity.IsDeleted,
            IsUsed = entity.IsUsed
        }).ToList();
        return Dto;
    }

    public GetAccountDto? GetAccount(Guid guid)
    {
        var entity = _servicesRepository.GetByGuid(guid);
        if (entity is null)
        {
            return null;
        }

        var toDto = new GetAccountDto
        {
            Guid = entity.Guid,
            IsDeleted = entity.IsDeleted,
            IsUsed = entity.IsUsed
        };

        return toDto;
    }

    public GetAccountDto? CreateAccount(NewAccountDto entity)
    {
        var entityAccount = new Account
        {
            Guid = new Guid(),
            Password = HashingHandler.HashPassword(entity.Password),
            IsDeleted = entity.IsDeleted,
            IsUsed = entity.IsUsed,
            CreatedDate = DateTime.Now,
            ModifiedDate = DateTime.Now
        };

        var created = _servicesRepository.Create(entityAccount);
        if (created is null)
        {
            return null;
        }

        var Dto = new GetAccountDto
        {
            Guid = created.Guid,
            IsDeleted = created.IsDeleted,
            IsUsed = created.IsUsed,
        };

        return Dto;
    }

    public int UpdateAccount(UpdateAccountDto entity) 
    {
        var isExist = _servicesRepository.IsExist(entity.Guid);
        if (!isExist)
        {
            return -1;
        }

        var getEntity = _servicesRepository.GetByGuid(entity.Guid);

        var account = new Account
        {
            Guid = entity.Guid,
            IsUsed = entity.IsUsed,
            IsDeleted = entity.IsDeleted,
            ModifiedDate = DateTime.Now,
            CreatedDate = getEntity!.CreatedDate
        };

        var isUpdate = _servicesRepository.Update(account);
        if (!isUpdate)
        {
            return 0;
        }

        return 1;
    }

    public int DeleteAccount(Guid guid)
    {
        var isExist = (_servicesRepository.IsExist(guid));
        if (!isExist)
        {
            return -1;
        }

        var account = _servicesRepository.GetByGuid(guid);
        var isDelete = _servicesRepository.Delete(account!);

        if (!isDelete)
        {
            return 0;
        }

        return 1;
    }
}
