using System.Xml;
using HomeAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace HomeAssignment.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        // POST api/user/login
        [HttpPost]
        [Route("login")]
        public IActionResult Post([FromBody] UserLoginRequest value)
        {
            return postFunc("UserLoginRequest", value);            
        }

        // POST api/user/information
        [HttpPost]
        [Route("information")]
        public IActionResult Post([FromBody] UserInformationRequest value)
        {
            return postFunc("UserInformationRequest", value);
        }

        private IActionResult postFunc(string rootName, IRequest value)
        {
            if (value == null)
            {
                return NotFound();

            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string jsonValue = JsonConvert.SerializeObject(value);
            XmlDocument? doc = JsonConvert.DeserializeXmlNode(jsonValue, rootName);    
            string xmlResponse = sendToOldApi(doc);

            // Convert and send the response (bonus)
            XmlDocument xmlResponseDoc = new XmlDocument();
            xmlResponseDoc.LoadXml(xmlResponse);
            string jsonResponse = JsonConvert.SerializeXmlNode(xmlResponseDoc);
            return Ok(jsonResponse);
        }

        // The old API was not given, so I've mocked it- returned the exact XML string response from the instructions (the example) 
        public string sendToOldApi(XmlDocument? doc)
        {
            return "<UserLoginResponse><UserId>A78b54gx0 - uhj8</UserId><SessionKey>_sdjh765riuyh</SessionKey></UserLoginResponse>";

        }




    }
}

