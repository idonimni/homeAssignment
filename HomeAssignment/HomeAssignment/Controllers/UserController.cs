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
        public IActionResult PostLogin([FromBody] UserLoginRequest value) =>
            postFunc("UserLoginRequest", value);

        // POST api/user/information
        [HttpPost]
        [Route("information")]
        public IActionResult PostInformation([FromBody] UserInformationRequest value) =>
            postFunc("UserInformationRequest", value);

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
            XmlDocument xmlResponseDoc = new();
            xmlResponseDoc.LoadXml(xmlResponse);
            string jsonResponse = JsonConvert.SerializeXmlNode(xmlResponseDoc);
            return Ok(jsonResponse);
        }

        // The old API was not given, so I've mocked it- returned the exact XML string response from the instructions (the example)
        private string sendToOldApi(XmlDocument? doc)
        {
            return "<UserLoginResponse><UserId>A78b54gx0 - uhj8</UserId><SessionKey>_sdjh765riuyh</SessionKey></UserLoginResponse>";
        }
    }
}
