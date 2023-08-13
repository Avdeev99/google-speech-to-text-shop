using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TRM_STT.Api.DTO;
using TRM_STT.Core.Domain.Models;
using TRM_STT.Core.Services.Interfaces;

namespace TRM_STT.Api.Controllers
{
    [ApiController]
    [Route("api/goods")]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodService _goodService;
        private readonly IMapper _mapper;
        
        public GoodsController(IGoodService goodService, IMapper mapper)
        {
            _goodService = goodService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var goods = await _goodService.GetAllAsync();
            var result = _mapper.Map<List<GoodDto>>(goods);
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateGoodDto goodDto)
        {
            var good = _mapper.Map<Good>(goodDto);
            await _goodService.CreateAsync(good);
            
            return Ok();
        }
        
        [HttpPost("audio")]
        public async Task<IActionResult> GetAllByAudioAsync([FromBody] GetGoodsByAudioDto dto)
        {
            var goods = await _goodService.GetAllByAudioAsync(dto.FileName);
            var result = _mapper.Map<List<GoodDto>>(goods);

            return Ok(result);
        }
    }
}