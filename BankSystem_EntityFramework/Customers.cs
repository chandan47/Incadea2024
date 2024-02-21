using System.ComponentModel.DataAnnotations;

public class Customers
{
    [Key]
    public int accno { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public string mobile { get; set; }
    public DateTime dob { get; set; }
    public decimal balance { get; set; }
}
