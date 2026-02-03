using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Your Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribeToNewsLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }

        [Display(Name = "Member Ship Type")]
        [Required(ErrorMessage = "Please Choose Member Ship Type")]

        public byte MemberShipTypeId { get; set; }
        [Display(Name ="Date Of Birth")]
        [Min18AMember]
        public DateTime? BirthDay { get; set; }
    }
}