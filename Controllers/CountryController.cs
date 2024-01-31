using AutoMapper;
using CountryDropDownAPI.Data;
using CountryDropDownAPI.DTO;
using CountryDropDownAPI.Models;
using CountryDropDownAPI.PageExtension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Text.Json;

namespace CountryDropDownAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryDbContext _context;
        private readonly IMapper _mapper;

        public CountryController(CountryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost, Route("AddCountry")]
        public async Task<IActionResult> AddCountry([FromBody] AddCountryDto countryDto)
        {
            var obj = new AddCountryDto()
            {
                CountryName = countryDto.CountryName
            };
            var countryObj = _mapper.Map<Country>(obj);

            _context.Add(countryObj);

            await _context.SaveChangesAsync();

            return Ok(countryDto);
        }

        [HttpGet, Route("GetAllCountry")]
        public async Task<IEnumerable<CountryDto>> GetAllCountries()
        {
            try
            {
               
                var listObj = await _context.Countries.ToListAsync();
                var countryList = listObj.Select(x => _mapper.Map<CountryDto>(x)).ToList();
                //if(countryList.Count > 0)
                //{
                //    Expression<Func<CountryDto, bool>> filters = null;
                //    //First, we are checking our SearchTerm. If it contains information we are creating a filter.
                //    var searchTerm = "";
                //    if (!string.IsNullOrEmpty(searchParam.SearchTerm))
                //    {
                //        searchTerm = searchParam.SearchTerm.Trim().ToLower();
                //        filters = x => x.CountryName.ToLower().Contains(searchTerm);
                //    }
                //}

                return countryList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetCountryById")]
        public async Task<CountryDto> GetCountryById(int? Id)
        {
            try
            {
                var obj = await _context.Countries.FirstOrDefaultAsync(x => x.CountryId == Id);
                if(obj != null)
                {
                    var res = _mapper.Map<CountryDto>(obj);
                    return res;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[HttpGet, Route("GetCountryList")]
        //public ActionResult<IEnumerable<CountryListDto>> GetCountryList()
        //{
        //    try
        //    {
        //        var countries = _context.Countries
        //            .Include(a => a.States)
        //                .ThenInclude(d => d.Districts)
        //                    .ThenInclude(c => c.Cities)
        //            .ToList();

        //        var countryDtoList = countries.Select(country => new CountryListDto
        //        {
        //            CountryName = country.CountryName,
        //            States = country.States.Select(state => new StateDistrictDto
        //            {
        //                StateName = state.StateName,
        //                Districts = state.Districts.Select(district => new DistrictCityOnlyDto
        //                {
        //                    DistrictName = district.DistrictName,
        //                    Cities = district.Cities.Select(city => city.CityName).ToList()
        //                }).ToList()
        //            }).ToList()
        //        }).ToList();

        //       return Ok(new {countries = countryDtoList});
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
