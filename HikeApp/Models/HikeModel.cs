using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikeApp.Models
{
    public class HikeModel
    {
        [PrimaryKey, AutoIncrement]
        public int HikeID { get; set; }
        public string NameOfHike { get; set; }
        public string Location { get; set; }
        public bool ParkingAvailable { get; set; }
        
        public string Length { get; set; }
        public string Level {  get; set; }
        public string Description { get; set; }
    }
}
