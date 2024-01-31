using AutoMapper;
using CountryDropDownAPI.Data;
using CountryDropDownAPI.DTO;
using CountryDropDownAPI.Models;
using CountryDropDownAPI.PageExtension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CountryDropDownAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly CountryDbContext _context;
        private readonly IMapper _mapper;
   

        public PersonController(CountryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost, Route("AddPerson")]
        public async Task<IActionResult> AddPerson([FromBody] AddPersonDto personDto)
        {
            try
            {
                var obj = new AddPersonDto()
                {
                    FirstName = personDto.FirstName,
                    LastName = personDto.LastName,
                    JoinDate = personDto.JoinDate,
                    CountryId = personDto.CountryId,
                    StateId = personDto.StateId,
                    DistrictId = personDto.DistrictId,
                    CityId  = personDto.CityId
                };

                var personObj = _mapper.Map<Person>(obj);
                _context.Add(personObj);
                await _context.SaveChangesAsync();

                return Ok(personDto);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut, Route("UpdatePerson")]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonDto updatePerson)
        {
            try
            {
                var obj = new UpdatePersonDto()
                {
                    PersonId = updatePerson.PersonId,
                    FirstName = updatePerson.FirstName,
                    LastName = updatePerson.LastName,
                    JoinDate = updatePerson.JoinDate,
                    CountryId = updatePerson.CountryId,
                    StateId = updatePerson.StateId,
                    DistrictId = updatePerson.DistrictId,
                    CityId = updatePerson.CityId
                };

                var upersonObj = _mapper.Map<Person>(obj);
                _context.Update(upersonObj);
                await _context.SaveChangesAsync();

                return Ok(upersonObj);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetAllPersons")]
        public ActionResult<PagedList<PersonDto>> GetAllPersons([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string name = "")
        {
            try
            {
                var skip = (pageNumber - 1) * pageSize;
                var take = pageSize;

                IQueryable<Person> persons = _context.Persons.OrderBy(x => x.PersonId);

                if (!string.IsNullOrEmpty(name))
                {
                    persons = persons.Where(x => x.FirstName.Contains(name));
                }

                var query = (from p in persons
                             join c in _context.Countries on p.CountryId equals c.CountryId
                               join s in _context.States on p.StateId equals s.StateId
                               join d in _context.Districts on p.DistrictId equals d.DistrictId
                               join ct in _context.Cities on p.CityId equals ct.CityId
                               select new PersonDto
                               {
                                   PersonId = p.PersonId,
                                   FirstName = p.FirstName,
                                   LastName = p.LastName,
                                   JoinDate = p.JoinDate,
                                   CountryName = c.CountryName,
                                   StateName = s.StateName,
                                   DistrictName = d.DistrictName,
                                   CityName = ct.CityName
                               
                               })
                               //.OrderBy(x => x.PersonId)
                               .Skip(skip)
                               .Take(take)
                               .ToList();

                var totalCount = query.Count();

                var results = new PagedList<PersonDto>(query, pageNumber, pageSize, totalCount);

                return Ok(results);

            }
            catch (Exception)
            {
                throw;
            }
        }


        //[HttpGet, Route("GetPerson")]
        //public ActionResult<IEnumerable<PersonDto>> GetPerson()
        //{
        //    try
        //    {
        //        var persons = _context.Persons
        //        .Include(a => a.Country)
        //        .ThenInclude(s => s.States)
        //        .ThenInclude(d => d.Districts)
        //        .ThenInclude(c => c.Cities)
        //        .ToList();

        //        //var personDto = persons.Select(x => _mapper.Map<PersonDto>(x)).ToList();

        //        var personDto = persons.Select(person => new PersonDto
        //        {
        //            FirstName = person.FirstName,
        //            LastName = person.LastName,
        //            JoinDate = person.JoinDate,
        //            Countries = new CountryStateDto
        //            {
        //                CountryName = person.Country?.CountryName,
        //                stateDistrictDtos = person.Country?.States?.Select(state => new StateDistrictDto
        //                {
        //                    StateName = state.StateName,
        //                    DistrictCity = state.Districts?.Select(district => new DistrictCityOnlyDto
        //                    {
        //                        DistrictName = district.DistrictName,
        //                        Cities = district.Cities?.Select(city => new CityDto
        //                        {
        //                            CityId = city.CityId,
        //                            CityName = city.CityName
        //                        }).ToList()
        //                    }).ToList()
        //                }).ToList()
        //            }

        //        }).ToList();
        //        return Ok(personDto);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
