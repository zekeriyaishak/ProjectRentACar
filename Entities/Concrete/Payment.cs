﻿using CorePackagesGeneral.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;
public class Payment:IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string CreditCardNumber { get; set; }
    public int Price { get; set; }
    public string ExpirationDate { get; set; }
    public string SecurityCode { get; set; }
}
