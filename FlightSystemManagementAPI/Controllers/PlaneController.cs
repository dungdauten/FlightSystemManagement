using AutoMapper;
using FlightSystemManagementAPI.Configurations;
using FlightSystemManagementAPI.Models.Data;
using FlightSystemManagementAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace FlightSystemManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaneController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public PlaneController(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetPlanes()
        {
            try
            {
                return Ok(await _dataContext.PlaneInfo.ToListAsync());
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(PlaneInfo plane)
        {
            

            var findPlane = _dataContext.PlaneInfo.Where(c => c.PlaneID == plane.PlaneID).FirstOrDefault();
            if (findPlane != null)
            {
                return Ok("Already have in database");
            }
            else
            {

                PlaneInfo planes = new PlaneInfo
                {
                    APlaneName=plane.APlaneName,
                    APlaneCapity=plane.APlaneCapity,
                    Price=plane.Price,
                };
                var planeInfoDTO = _mapper.Map<PlaneInfoDTO>(planes);
                _dataContext.PlaneInfo.Add(planeInfoDTO);
                _dataContext.SaveChanges();
                return Ok(plane);
            }
        }
        
    }
}
