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
    public class DistrictController : ControllerBase
    {
        private readonly CountryDbContext _context;
        private readonly IMapper _mapper;

        public DistrictController(CountryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost, Route("AddDistrict")]
        public async Task<IActionResult> AddDistrict([FromBody] AddDistrictDto districtDto)
        {
            try
            {
                var obj = new AddDistrictDto()
                {
                    DistrictName = districtDto.DistrictName,
                    StateId = districtDto.StateId
                };

                var districtObj = _mapper.Map<District>(obj);

                _context.Add(districtObj);
                await _context.SaveChangesAsync();

                return Ok(districtDto);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetAllDistricts")]
        public ActionResult<PagedList<DistrictDto>> GetAllDistricts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize=10, [FromQuery] string name = "")
        {
            try
            {
                var skip = (pageNumber - 1) * pageSize;
                var take = pageSize;

                IOrderedQueryable<District> distQuery = _context.Districts.OrderBy(x => x.DistrictId);

                IQueryable<District> districts = distQuery;


                if (!string.IsNullOrEmpty(name))
                {
                    districts = districts.Where(x => x.DistrictName.Contains(name));
                }

                var districtList = districts
                    //.OrderBy(x => x.DistrictId)
                    .Skip(skip)
                    .Take(take)
                    .ToList();


                var totalCount = districtList.Count();

                var DistrictList = districtList.Select(x => _mapper.Map<DistrictDto>(x)).ToList();

                var results = new PagedList<DistrictDto>(DistrictList, pageNumber, pageSize, totalCount);

                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetDistrictById")]
        public async Task<DistrictDto> GetDistrictById(int Id)
        {
            try
            {
                var obj = await _context.Districts.FirstOrDefaultAsync(x => x.DistrictId == Id);
                if(obj != null)
                {
                    var res = _mapper.Map<DistrictDto>(obj);
                    return res;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet, Route("GetDistrictListByState")]
        public async Task<ActionResult<StateDistrictDto>> GetDistrictListByState(int id)
        {
            try
            {
                var state = await _context.States
                    .Include(s => s.Districts)
                    .FirstOrDefaultAsync(s => s.StateId == id);

                if (state == null)
                {
                    return NotFound("Not Found");
                }

                var stateDto = new StateDistrictDto
                {
                    StateName = state.StateName,
                    Districts = state.Districts.Select(d => new DistrictDto
                    {
                        DistrictName = d.DistrictName,
                        DistrictId = d.DistrictId
                    }).ToList()
                };

                return Ok(stateDto);
            }
            catch (Exception)
            {
                // Consider logging the exception here
                throw;
            }
        }

        //[HttpGet, Route("GetDistrictListByState")]
        //public async Task<ActionResult<List<StateDistrictDto>>> GetDistrictListByState(int Id)
        //{
        //    try
        //    {
        //        var state = await _context.States
        //            .Include(a => a.Districts)
        //            .FirstOrDefaultAsync(a => a.StateId ==  Id);

        //        var stateDto = new StateDistrictDto()
        //        {
        //            StateName = state.StateName,
        //            Districts = state.Districts.Select(s => new DistrictDto() { DistrictName = s.DistrictName, DistrictId= s.DistrictId }).ToList()
        //        };

        //        return Ok(stateDto);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}
