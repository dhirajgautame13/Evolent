using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Evolent.ContactManager.Web.Models
{
    public class Contact
    {
        public int ContactID { get; set; }
        [StringLength(25, ErrorMessage = "First Name cannot be longer than 10 characters.")]
        [Required(ErrorMessage = "First Name is required field.")]
        public string FirstName { get; set; }
        [StringLength(25, ErrorMessage = "Last Name cannot be longer than 10 characters.")]
        [Required(ErrorMessage = "Last Name is required field.")]
        public string LastName { get; set; }
        [StringLength(25, ErrorMessage = "First Name cannot be longer than 10 characters.")]
        public string Email { get; set; }
        [StringLength(10, ErrorMessage = "First Name cannot be longer than 10 characters.")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Phone Number")]       
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}