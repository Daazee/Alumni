using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumni.Model
{
    public class AlumnusRegistration
    {
        [Key]
        public string AlumnusRegistration_Id { get; set; }
        public string Surname { get; set; }
        public string Othername { get; set; }
        public string Sex { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Dob { get; set; }
        public string Marital_Status { get; set; }
        public string State { get; set; }
        public string Town { get; set; }
        public string Phone_Number { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public int Graduation_Year { get; set; }

        public string Email_Id { get; set; }
        public string Username { get; set; }
        public string Password { get;  set; }
        public string Reg_Status { get; set; }
        public string Alumnus_Role { get; set; }
        public string Flag { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Key_Date { get; set; }

    }
}
