using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alumni.Model
{
 public   class AlumnusPicture
    {
        [Key]
        public string AlumnusPictureId { get; set; }

        public string Username { get; set; }
        public byte[] Picture { get; set; }
        public string Flag { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Key_Date { get; set; }
    }
}