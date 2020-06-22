using System;
using System.Collections.Generic;
using Domain.Identity;
using PublicApi.DTO.v1.Identity;

namespace PublicApi.DTO.v1
{
    public class NewBillDTO
    {
        public List<TrainingDTO> Trainings { get; set; }
        public short Total { get; set; }
        public DateTime Deadline { get; set; }
        public UserDTO UserBill { get; set; }
    }
}