﻿using CorePackagesGeneral.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailsDto:IDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserLastname { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string ModelName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime CreatedDate { get; set;}
    }
}
