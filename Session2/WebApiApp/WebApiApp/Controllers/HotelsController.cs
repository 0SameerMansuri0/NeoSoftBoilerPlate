using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiApp.Context;
using WebApiApp.Model;
using WebApiApp.Service;

namespace WebApiApp.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IMapper _mapper;

        public HotelsController(IHotelService hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelVM>>> GetHotels()
        {
            IEnumerable<Hotel> hotels = _hotelService.GetAllserv();
            IEnumerable<HotelVM> result =_mapper.Map<IEnumerable<HotelVM>>(hotels);  
            return Ok(result);
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelVM>> GetHotelById(int id)
        {
            Hotel hotel=_hotelService.GetByIdServ(id);
            var result=_mapper.Map<HotelVM>(hotel);
            return Ok(result);
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutHotel(HotelVM hotel)
        {
            var result = _mapper.Map<Hotel>(hotel);
            _hotelService.UpdateServ(result.Id, result);
            return Ok(true);
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelVM>> PostHotel(HotelVM hotelvm)
        {
            var hotel=_mapper.Map<Hotel>(hotelvm);
            _hotelService.AddServ(hotel);

            return Ok(true);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            _hotelService.DeleteServ(id);
            return Ok(true);
        }

       
    }
}
