using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using HomeAssignment.Models;
using Newtonsoft.Json.Linq;


namespace HomeAssignment.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {


        // POST api/values/login
        [HttpPost]
        [Route("login")]
        public IActionResult Post([FromBody] UserLoginRequest value)
        {
            return postFunc("UserLoginRequest", value);            
        }



        // POST api/values/information
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
            XmlDocument doc = JsonConvert.DeserializeXmlNode(jsonValue, rootName);
            string xmlResponse = mockSendToOldApi(doc);


            XmlDocument xmlResponseDoc = new XmlDocument();
            xmlResponseDoc.LoadXml(xmlResponse);
            string jsonResponse = JsonConvert.SerializeXmlNode(xmlResponseDoc);
            return Ok(jsonResponse);
        }

        private string mockSendToOldApi(XmlDocument doc)
        {
            return "<UserLoginResponse><UserId>A78b54gx0 - uhj8</UserId><SessionKey>_sdjh765riuyh</SessionKey></UserLoginResponse>";

        }




    }
}

