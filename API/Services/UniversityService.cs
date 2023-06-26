using API.Contracts;
using API.Controllers;
using API.DTO.Universities;

namespace API.Services
{
    public class UniversityService
    {
        private readonly IUniversityRepository _universityRepository;

        public UniversityService(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        public ICollection<GetUniversitiesDto> GetUniversity()
        {
            var universities = _universityRepository.GetAll();
            if(!universities.Any())
            {
                return null; // No universities found
            }

            var toDto = universities.Select(university => 
                                                new GetUniversitiesDto {
                                                    Guid = university.Guid,
                                                    Name = university.Name,
                                                    Code = university.Code
                                                }).ToList();

            return toDto;
        }

        public ICollection<GetUniversitiesDto> GetUniversityByGuid()
        {
            var universities = _universityRepository.GetAll();
            if (!universities.Any())
            {
                return null; // No universities found
            }

            var toDto = universities.Select(university =>
                                                new GetUniversitiesDto
                                                {
                                                    Guid = university.Guid,
                                                    Name = university.Name,
                                                    Code = university.Code
                                                }).ToList();

            return toDto;
        }
    }
}
