using Models;
using Business;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObrasController : ControllerBase
    {
        private readonly ObrasService _obrasService;

        public ObrasController(ObrasService obrasService)
        {
            _obrasService = obrasService;
        }

        [HttpGet]
        public ActionResult<List<Obras>> GetAll()
        {
            return _obrasService.GetAll();
        }

    }

}