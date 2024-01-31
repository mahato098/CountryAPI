using AutoMapper;
using CountryDropDownAPI.Data;
using CountryDropDownAPI.DTO;
using CountryDropDownAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CountryDropDownAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly CountryDbContext _context;
        private readonly IMapper _mapper;

        public StateController(CountryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost, Route("AddState")]
        public async Task<IActionResult> AddState([FromBody] AddStateDto stateDto)
        {
            try
            {
                var obj = new AddStateDto()
                {
                    StateName = stateDto.StateName,
                    CountryId = stateDto.CountryId
                };
                var stateObj = _mapper.Map<State>(obj);

                _context.Add(stateObj);
                await _context.SaveChangesAsync();


                return Ok(stateDto);

            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetAllStates")]
        public ActionResult<IEnumerable<StateDto>> GetAllStates()
        {
            try
            {
                var stateObj = _context.States.ToList();
                var stateList = stateObj.Select(x => _mapper.Map<StateDto>(x)).ToList();
                return stateList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet, Route("GetStateById")]
        public async Task<StateDto> GetStateById(int? id)
        {
            try
            {
                var obj = await _context.States.FirstOrDefaultAsync(x => x.StateId == id);
                if(obj != null)
                {
                    var res = _mapper.Map<StateDto>(obj);
                    return res;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

       
        [HttpGet, Route("GetStateListByCountry")]
        public async Task<ActionResult<List<CountryStateDto>>> GetStateListByCountry(int Id)
        {
            try
            {
                var country = await _context.Countries
                    .Include(s => s.States)
                    .FirstOrDefaultAsync(x => x.CountryId == Id);

                var countryDto = new CountryStateDto
                {
                    CountryName = country.CountryName,
                    States = country.States.Select(s => new StateDto { StateName = s.StateName, StateId = s.StateId }).ToList()
                };

                return Ok(countryDto);


            }
            catch (Exception)
            {
                throw;
            }
        } 

    }
}
