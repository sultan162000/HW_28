using System;
using System.ComponentModel.DataAnnotations;

namespace ASP_Quotes.Models
{
    public class Quotes
    {
        public int QuotesId { get; set; }
        [Required(ErrorMessage ="Обязателное поля")]
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime InsertDate { get; set; }

    }
}
