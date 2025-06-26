using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHost.Domain.Entities
{
    public class Hotel
    {
        public Guid Id { get; private set; }
        public string NomeHotel { get; private set; }
        public Hotel() { }
    }
}
