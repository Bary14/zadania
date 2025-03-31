using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCsharpG
{
    
    class Product
    {
        
        public string BarCode; 
        public string Name;    
        public double Price;   
        public float Amount;   

        
        public Product(string barCode, string name, double price, float amount)
        {
            
            BarCode = barCode; 
            Name = name;       
            Price = price;     
            Amount = amount;  
        }
    }
}
