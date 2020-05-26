using System;
using System.Collections.Generic;
using Domain.Identity;
using PublicApi.DTO.v1.Identity;

namespace PublicApi.DTO.v1
{
    public class BillDTO
    {
        public List<Guid> Trainings { get; set; }
        public string Total { get; set; }
        public DateTime Deadline { get; set; }
        public UserDTO UserBill { get; set; }
    }
}