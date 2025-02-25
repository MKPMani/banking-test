using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;


namespace banking.domain.Models
{
    public class Interest
    {
        [Range(typeof(DateOnly), "01-01-1900", "31-12-2099", ErrorMessage = "Invalid date. Date format should be yyyyMMdd")]
        [DisplayFormat(DataFormatString = "{0:yyyyMMdd}", ApplyFormatInEditMode = true)]
        public DateOnly Date { get; set; }
        public string RuleId { get; set; }

        [Range(1, 100, ErrorMessage = "Interest rate should be greater than 0 and less than 100")]
        public double Rate { get; set; }
        public DateTime CreationDate { get; set; }
    }
}