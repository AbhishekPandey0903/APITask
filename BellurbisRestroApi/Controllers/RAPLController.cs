using Microsoft.AspNetCore.Mvc;
using BellurbisRestroApi.Models;
using BellurbisRestroApi.Repository;

namespace BellurbisRestroApi.Controllers
{
    [ApiController]
    [Route("Api/[Controller]/[action]")]
    public class RAPLController : Controller
    {
        private readonly RAPRepository repo = null;
        public RAPLController(RAPRepository _repo)
        {
            repo = _repo;
        }
        public IActionResult RestroIndex()
        {
            var a = repo.RestroIndex();
            return Ok(a);
        }
        public IActionResult PlayerIndex()
        {
            var b = repo.PlayerIndex();
            return Ok(b);
        }
        [HttpPost]
        public IActionResult RestroCreate(RestroMod R)
        {
            var a = repo.RestroCreate(R);
            return Ok(a);
        }
        [HttpPost]
        public IActionResult PlayerCreate(PlayersMod P)
        {
            var b = repo.PlayerCreate(P);
            return Ok(b);
        }
        [HttpGet("{id}")]
        public IActionResult RestroEdit(int id)
        {
            return Ok(repo.RestroEdit(id));
        }
        [HttpGet("{id}")]
        public IActionResult PlayerEdit(int id)
        {
            return Ok(repo.PlayerEdit(id));
        }
        [HttpGet("{id}")]
        public IActionResult RestroDelete(int id)
        {
            return Ok(repo.RestroDelete(id));
        }
        [HttpGet("{id}")]
        public IActionResult PlayerDelete(int id)
        {
            return Ok(repo.PlayerDelete(id));
        }
        public IActionResult Getall()
        {
            return Ok(repo.getall());
        }

        [HttpGet("{Name}")]
        public List<RestroMod> RetrieveRestro(string name)
        {
            return (repo.RetrieveRestro(name));
        }
        [HttpGet("{Name}")]
        public List<PlayersMod> RetrievePlayer(string name)
        {
            return (repo.RetrievePlayer(name));
        }
        [HttpGet("{Name}")]
        public List<FavRestroPlayer> fvrtRes(string name,bool status = true)
        {
            return (repo.FvrtRes(name));
        }
        [HttpPost]
        public IActionResult RestroPlayerMapping(LinkMod mod)
        {
            var successStatus = repo.RestroPlayerMapping(mod);
            return Ok(successStatus);
        }
        [HttpGet("{RestroName}")]
        public IActionResult GetbyAge(string RestroName)
        {
            var result = repo.GetbyAge(RestroName);
            return Ok(result);
        }
    }
}
