using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class BloodDonator
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string ContactNo { get; set; }
        public string BloodGroupName { get; set; }
        public string Address { get; set; }
        public DateTime LastDateBloodGiven { get; set; }
        public DateTime NextTimeCan { get; set; }
        public bool IsActive { get; set; }
    }
}
