using ASPNETCORE_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamingController : ControllerBase
    {
        private IVideoStreamService _streamService;

        public StreamingController (IVideoStreamService streamService)
        {
            _streamService = streamService;
        }

        [HttpGet("{name}")]
        public async Task<FileStreamResult> Get (string name)
        {
            var stream = await _streamService.GetVideoByName(name);

            return new FileStreamResult(stream, "video/mp4");
        }
    }
}
