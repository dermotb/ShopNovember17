using System.ComponentModel;

namespace Shop.Models
{
    public class Item
    {
        public string Code {get;set;}
        public string Description {get;set;}

        [DisplayName("Price (€):")]
        public double Price{get;set;}
    }
}