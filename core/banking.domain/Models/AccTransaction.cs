
using System.ComponentModel.DataAnnotations;

namespace banking.domain.Models
{
    public class AccTransaction
    {
        public AccTransaction() { }

        public int Id { get; set; }

        [Range(typeof(DateOnly), "01-01-1900", "31-12-2099", ErrorMessage = "Invalid date. Date format should be yyyyMMdd")]
        [DisplayFormat(DataFormatString = "{0:yyyyMMdd}", ApplyFormatInEditMode = true)]
        public DateOnly Date { get; set; }

        public string AccountNumber { get; set; }
        public string TransactionId { get; set; }

        //[RegularExpression("^((?!^First Name$)[a-zA-Z '])+$", ErrorMessage = "Only allowed D/W")]
        public string Type { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }
    }
}