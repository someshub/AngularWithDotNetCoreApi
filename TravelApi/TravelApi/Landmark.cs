using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelApi
{
    public class Landmark
    {
        [Key]
        public int Landmark_Id { get; set; }
        public string Landmark_Name { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public Int64 Contact_Number { get; set; }
        public int Point_Order { get; set; }
        public int Distance { get; set; }
        public DateTime Created_Date { get; set; }
        

    }

   


}
