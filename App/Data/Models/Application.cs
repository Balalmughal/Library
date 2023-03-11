using System.ComponentModel.DataAnnotations;

namespace App.Data.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Address1 { get; set; }
        [MaxLength(255)]
        public string? Address2 { get; set; }
        [MaxLength(255)]
        public string Address3 { get; set; }
        [MaxLength(10)]
        public string Postcode { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string SecondName { get; set; }

        public Application(int id, string address1, string? address2, string address3, string postcode, DateTime date, string firstName, string secondName)
        {
            Id = id;
            Address1 = address1;
            Address2 = address2;
            Address3 = address3;
            Postcode = postcode;
            Date = date;
            FirstName = firstName;
            SecondName = secondName;
        }

        public Application()
        {

        }
    }
}
