using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Cars
{
    public class UpdateCarRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int CarImageId { get; set; }
        public string Description { get; set; }
        public int DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public int MinFindeksScore { get; set; }
        public string Plate { get; set; }
        public string Kilometer { get; set; }
    }
}
