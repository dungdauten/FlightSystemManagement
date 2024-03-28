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
        [HttpGet("Search/{id}")]
        public async Task<IActionResult> SearchPlane(int id)
        {
            var plane = await _dataContext.PlaneInfo.FirstOrDefaultAsync(p=>p.PlaneID==id);
            if (plane == null)
                return NotFound("Không tìm thấy máy bay");
            return Ok(plane);
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
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdatePlanes(int id, PlaneInfo plane)
        {
            if (id != plane.PlaneID)
            {
                return BadRequest("Sai thông tin chuyến bay cần cập nhật");
            }

            var planeInfo = _dataContext.PlaneInfo.FirstOrDefault(pl => pl.PlaneID == plane.PlaneID);
            var planeCheck = await _dataContext.PlaneInfo.FindAsync(id);
            if (planeInfo == null)
            {
                return NotFound("Mã máy bay không tồn tại");
            }
            else
            {
                planeCheck.APlaneName=plane.APlaneName;
                planeCheck.APlaneCapity = plane.APlaneCapity;
                planeCheck.Price=plane.Price;


                _dataContext.PlaneInfo.Update(planeCheck);
                await _dataContext.SaveChangesAsync();

                return Ok("Cập nhật thông tin máy bay thành công");
            }
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanes(int id)
        {
            var plane = await _dataContext.PlaneInfo.FindAsync(id);
            if (plane == null)
            {
                return NotFound("Không tìm thấy mã máy bay cần xoá");
            }

            _dataContext.PlaneInfo.Remove(plane);
            await _dataContext.SaveChangesAsync();

            return Ok("Xoá thành công máy bay!");
        }
    }
}
