using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Requests.Findeks
{
    public class UpdateFindeksRequest
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Score { get; set; }
    }
}
