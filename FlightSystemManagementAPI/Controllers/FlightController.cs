using AutoMapper;
using FlightSystemManagementAPI.Models.Data;
using FlightSystemManagementAPI.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;

namespace FlightSystemManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public FlightController(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> GetFlights()
        {
            try
            {
                return Ok(await _dataContext.FlightBookings.ToListAsync());
            }
            catch (Exception ex) { return BadRequest(ex); }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(FlightBooking flights)
        {
            var findFlights = _dataContext.FlightBookings.Where(c => c.BookingId == flights.BookingId).FirstOrDefault();
            if (findFlights != null)
            {
                return Ok("Chuyến bay đã tồn tại!");
            }
            else
            {
                var planeInfo = _dataContext.PlaneInfo.FirstOrDefault(pl => pl.PlaneID == flights.PlaneId);
                if (planeInfo != null)
                {
                    FlightBooking flight = new FlightBooking()
                    {
                        BookingId = flights.BookingId,
                        FlightNo= flights.FlightNo,
                        FromCity = flights.FromCity,
                        ToCity = flights.ToCity,
                        DDay = flights.DDay,
                        DTime = flights.DTime,
                        SeatType = flights.SeatType,
                        PlaneId = flights.PlaneId,
                    };
                    var flightDTO = _mapper.Map<FlightBookingDTO>(flight);
                    _dataContext.FlightBookings.Add(flightDTO);
                    _dataContext.SaveChanges();
                    return Ok(flight);
                }
                else
                {
                    return BadRequest("Mã máy bay không tồn tại");
                }         
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlights(int id)
        {
            var flight = await _dataContext.FlightBookings.FindAsync(id);
            if (flight == null)
            {
                return NotFound("Không tìm thấy chuyến bay cần xoá");
            }

            _dataContext.FlightBookings.Remove(flight);
            await _dataContext.SaveChangesAsync();

            return Ok("Xoá thành công chuyến bay!");
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateFlights(int id, FlightBooking flight)
        {
            if (id != flight.BookingId)
            {
                return BadRequest("Sai thông tin chuyến bay cần cập nhật");
            }

            var planeInfo = _dataContext.PlaneInfo.FirstOrDefault(pl => pl.PlaneID == flight.PlaneId);
            var flightexists = await _dataContext.FlightBookings.FindAsync(id);
            if (flight == null)
            {
                return NotFound("Không tìm thấy chuyến bay cấn cập nhật!");
            }
            if (planeInfo != null)
            {
                flightexists.SeatType = flight.SeatType;
                flightexists.ToCity = flight.ToCity;
                flightexists.FromCity = flight.FromCity;
                flightexists.DTime = flight.DTime;
                flightexists.DDay = flight.DDay;
                flightexists.PlaneId = flight.PlaneId;

                _dataContext.FlightBookings.Update(flightexists);
                await _dataContext.SaveChangesAsync();

                return Ok("Cập nhật thông tin chuyến bay thành công");
            }
            else
            {
                return BadRequest("Mã máy bay không tồn tại");
            }
        }

        [HttpGet("Search")]
        public async Task<IActionResult> SearchFlights(string? departureDate, string? departureTime, int? planeid)
        {
            var flights = _dataContext.Set<FlightBookingDTO>().ToList();
            // Lọc danh sách chuyến bay dựa trên các thông tin tìm kiếm
            var filteredFlights = flights;
            if (!string.IsNullOrEmpty(departureDate))
            {
                filteredFlights = filteredFlights.Where(f => string.Equals(f.DDay, departureDate, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(departureTime))
            {
                // Cắt bỏ phần phút trong departureTime (ví dụ: 9:00 am -> 9:00)
                var searchTime = departureTime.Substring(0, 4); // Giả sử departureTime đã có định dạng "hh:mm" (ví dụ: 9:00)

                filteredFlights = filteredFlights.Where(f => f.DTime.StartsWith(searchTime)).ToList();
            }
            else if (planeid != null)
            {
                filteredFlights = filteredFlights.Where(f => f.PlaneId == planeid).ToList();
            }

            return Ok(filteredFlights);
        }
    }
}
