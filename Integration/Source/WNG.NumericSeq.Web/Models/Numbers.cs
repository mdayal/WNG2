using System.ComponentModel.DataAnnotations;

namespace WNG.NumericSeq.Web.Models
{
    public class Numbers
    {
        public Numbers()
        {
        }

        public Numbers(short number)
        {
            Number = number;
        }

        [Display(Name = "Enter a Number(1-500)")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a postive number with no decimal value.")]
        //[Range(1,32767)]
        [Range(1, 500, ErrorMessage = "Number entered must a postive number between 1 and 500. ")]
        public int Number { get; set; }


    }
}