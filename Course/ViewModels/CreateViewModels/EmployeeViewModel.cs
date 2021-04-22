using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModels.CreateViewModels
{
    public class EmployeeViewModel
    {
        public int? EmployeeId { get; set; }
        public int PositionId { get; set; }
        public int FactoryId { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
