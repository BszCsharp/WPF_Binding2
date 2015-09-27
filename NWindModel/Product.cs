using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace NWindModel 
{
    public class Product:INotifyPropertyChanged
    {
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set
            {
                productId = value;
                onPropertyChanged("ProductId");
            }
        }
        private String productName;

        public String ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                onPropertyChanged("ProductName");
            }
        }
        private Decimal unitPrice;

        public Decimal UnitPrice
        {
            get { return unitPrice; }
            set
            {
                unitPrice = value;
                onPropertyChanged("UnitPrice");
            }
        }
        public Product()
        {

        }
        public Product(int prid, string prname, decimal uprice)
        {
            this.ProductId = prid;
            this.ProductName = prname;
            this.UnitPrice = uprice;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
