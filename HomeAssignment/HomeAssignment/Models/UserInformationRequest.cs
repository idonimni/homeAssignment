using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace HomeAssignment.Models
{
    public class UserInformationRequest: IRequest
    {
        [Required(ErrorMessage = "UserId required ")]
        [XmlAttribute]
        public string? UserId { get; set; }

        public UserInformationRequest(string userId)
        {
            UserId = userId;
        }
    }
}

