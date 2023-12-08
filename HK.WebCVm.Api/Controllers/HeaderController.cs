using BussinessLayer.Interfaces;
using DtoLayer.SkillDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HK.WebCVm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderController : ControllerBase
    {
        private readonly IHeaderService _headerservice;
        private readonly ISkillService _skillService;

        public HeaderController(IHeaderService headerservice, ISkillService skillService)
        {
            _headerservice = headerservice;
            _skillService = skillService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSkill()
        {
            var data = await _skillService.GetAll();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(SkillUpdateDto dto)
        {
            await _skillService.Update(dto);
            return Ok(dto);
        }

    }
}
