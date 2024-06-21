using CorePackagesGeneral.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;
public class CreditCard:IEntity
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public int UserId { get; set; }
    public string OwnerName { get; set; }
    public string CreditCardNumber { get; set; }
    public string ExpirationDate { get; set; }
    public string SecurityCode { get; set; }
    public int?  Debts { get; set; }
}
