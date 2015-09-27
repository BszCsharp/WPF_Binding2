using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NWindModel;
using System.Data.SqlClient;

namespace NWindViewModel
{
    public class MainViewModel
    {
        Product product = new Product(0, "xx", 0.0m);
        private ICommand buttonCommand;
        private SqlConnection con;

        public ICommand ButtonCommand
        {
            get { return buttonCommand; }
            set { buttonCommand = value; }
        }
        public Product Product
        {
            get { return product; }
            set { product = value; }
        }
        public MainViewModel()
        {
            this.ButtonCommand = new UserCommand(new Action<object>(searchProduct));
            con = new SqlConnection();
            SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder();
            cb.DataSource = ".";
            cb.IntegratedSecurity = true;
            cb.InitialCatalog = "NwindSQL";
            con.ConnectionString = cb.ConnectionString;



            
        }

        private void searchProduct(object obj)
        {
            int prodId = Convert.ToInt32(obj);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select ProductID, ProductName, UnitPrice from Products where ProductID =" + prodId.ToString();
            con.Open();
            SqlDataReader r =  cmd.ExecuteReader();
            if (r.Read() == true)
            {
                product.ProductId = r.GetInt32(0);
                product.ProductName = r.GetString(1);
                product.UnitPrice = r.GetDecimal(2);

            }
            else
            {
                product.ProductId = prodId;
                product.ProductName = "Unbekannte ID";
                product.UnitPrice = -1.0m;
            }
            r.Close();
            con.Close();
        }
        
    }
}
