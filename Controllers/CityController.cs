using AutoMapper;
using CountryDropDownAPI.Data;
using CountryDropDownAPI.DTO;
using CountryDropDownAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CountryDropDownAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CountryDbContext _context;
        private readonly IMapper _mapper;

        public CityController(CountryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost, Route("AddCity")]
        public async Task<IActionResult> AddCity([FromBody] AddCityDto cityDto)
        {
            try
            {
                var obj = new AddCityDto()
                {
                    CityName = cityDto.CityName,
                    DistrictId = cityDto.DistrictId
                };

                var cityObj = _mapper.Map<City>(obj);
                _context.Add(cityObj);

                await _context.SaveChangesAsync();
                return Ok(cityDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetAllCities")]
        public ActionResult<IEnumerable<CityDto>> GetAllCities()
        {
            try
            {
                var cityObj = _context.Cities.ToList();
                var cityList = cityObj.Select(x => _mapper.Map<CityDto>(x)).ToList();

                return cityList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetCityById")]
        public async Task<CityDto> GetCityById(int Id)
        {
            try
            {
                var cityObj = await _context.Cities.FirstOrDefaultAsync(x => x.CityId == Id);
                if(cityObj != null)
                {
                    var res = _mapper.Map<CityDto>(cityObj);
                    return res;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetCityListByDistrict")]
        public async Task<ActionResult<List<DistrictCityDto>>> GetCityListByDistrict(int Id)
        {
            try
            {
                var district =await _context.Districts
                    .Include(a => a.Cities)
                    .FirstOrDefaultAsync(a => a.DistrictId == Id);

                var cityDto = new DistrictCityDto()
                {
                    DistrictName = district.DistrictName,
                    Cities = district.Cities.Select(x => new CityDto() { CityName = x.CityName, CityId = x.CityId }).ToList()
                };

                return Ok(cityDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
