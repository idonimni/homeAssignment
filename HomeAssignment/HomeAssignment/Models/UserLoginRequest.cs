using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace HomeAssignment.Models
{
    public class UserLoginRequest: IRequest
    {
        [Required(ErrorMessage = "UserName required ")]
        [XmlAttribute]
        public string? UserName { get; set;}

        [Required(ErrorMessage = "Password required")]
        [XmlAttribute]
        public string? Password { get; set; }

        public UserLoginRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}

