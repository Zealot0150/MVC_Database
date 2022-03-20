using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MVC_Database.Models.Services;
using System.IO;
using System.Text;
using System.Text.Json;

namespace MVC_Database.Controllers
{

    // https://localhost:44307/api/React 
    [Route("api/[controller]")]
    public class ReactController : Controller
    {

        private readonly IReactService service;

        public ReactController(IReactService _Service)
        {
            this.service = _Service;
        }

        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        // Denna nås genom https://localhost:44307/api/React eller nu vilken port  man har...
        [HttpGet]
        // GET: ReactController
        public string Get()
        {
            string st = JsonSerializer.Serialize(service.GetPeople());
            return st;
        }

        [HttpGet("GetAllCities")]
        // GET: ReactController
        public string GetAllCities()
        {
            string st = JsonSerializer.Serialize(service.GetCities());
            return st;
        }


        private async  void GetDocumentContents()
        {
            string documentContents;
            using (Stream receiveStream = Request.Body)
            {
                using (StreamReader readStream =  new StreamReader(receiveStream, Encoding.UTF8))
                {
                    documentContents = await readStream.ReadToEndAsync();
                }
            }
            System.Console.WriteLine(documentContents);
        }

        [HttpPost("CreatePerson")]
        public  ActionResult CreatePerson(string name, string tele, string city)
        {
            GetDocumentContents();
            if(service.AddPerson(name, city, tele))
                return StatusCode(200);
            else
                return StatusCode(500);
        }


        [HttpPost("DeletePerson")]

        //// GET: ReactController/Delete/5
        public ActionResult DeletePerson(int id)
        {
            if (service.DeleteUser(id))
                return StatusCode(200);
            else
                return StatusCode(500);
            
        }
    }
}
