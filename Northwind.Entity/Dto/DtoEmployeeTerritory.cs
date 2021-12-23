using Northwind.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entity.Dto
{
    public class DtoEmployeeTerritory:DtoBase
    {
        public DtoEmployeeTerritory() { }
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }
    }
}
