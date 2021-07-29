using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Doctor
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string HospitalName { get; set; }
        public string DoctorName { get; set; }
        public string Designation { get; set; }
        public string RoomNo { get; set; }
        public string ContactNo { get; set; }
        public string FloorNo { get; set; }
        public string IsActive { get; set; }
        public bool TntNumber { get; set; }
    }
}
