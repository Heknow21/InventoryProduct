using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmAddProduct : Form
    {

            public string Product_Name(string name)
            {
            try {
                if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                {
                    //Exception here
                    throw new StringFormatException(name);
                }
            } 
            catch (StringFormatException sfe) { 
                MessageBox.Show("The String Format Exception in Product Name is " + sfe.Message);
            }
            finally 
            {
                Console.WriteLine("string is only available in Product Name");
            }
            return name;
            }
            public int Quantity(string qty)
            {
            try
            {
                if (!Regex.IsMatch(qty, @"^[0-9]"))
                {
                    //Exception here
                    throw new NumberFormatException(qty);
                }
            } 
            catch (NumberFormatException nfe)
            {
                MessageBox.Show("The Number Format Exception in Quantity is " + nfe.Message);
            }
            return Convert.ToInt32(qty);
            }
        public double SellingPrice(string price)
        {
            try
            {
                if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                    //Exception here
                    throw new CurrencyFormatException(price);

            }
            catch (CurrencyFormatException cfe)
            {
                MessageBox.Show("The Currency Format Exception in Price is " + cfe.Message);
            }
            return Convert.ToDouble(price);
        
        }

        class StringFormatException : Exception
        {
            public StringFormatException(string SFE) : base(SFE) { }
        }
        class NumberFormatException : Exception
        {
            public NumberFormatException(string NFE) : base(NFE) { }
        }
        class CurrencyFormatException : Exception
        {
            public CurrencyFormatException(string CFE) : base(CFE) { }
        }

        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;
        private int _Quantity;
        private double _SellPrice;

        BindingSource showProductList;


        public frmAddProduct() {
            
            InitializeComponent();

            showProductList = new BindingSource();

        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[8];
            ListOfProductCategory[0] = "Beverages";
            ListOfProductCategory[1] = "Bread/Bakery";
            ListOfProductCategory[2] = "Canned/Jarred Goods";
            ListOfProductCategory[3] = "Dairy";
            ListOfProductCategory[4] = "Frozen Goods";
            ListOfProductCategory[5] = "Meat";
            ListOfProductCategory[6] = "Personal Care";
            ListOfProductCategory[7] = "Other";

            foreach(string product in ListOfProductCategory)
            {
                cbCategory.Items.Add(product);

            }

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            _ProductName = Product_Name(txtProductName.Text);
            _Category = cbCategory.Text;
            _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
            _ExpDate = dtPickerExDate.Value.ToString("yyyy-MM-dd");
            _Description = richTxtDescription.Text;
            _Quantity = Quantity(txtQuantity.Text);
            _SellPrice = SellingPrice(txtSellPrice.Text);
            showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate, _ExpDate, _SellPrice, _Quantity, _Description));
            gridViewProductList.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            gridViewProductList.DataSource = showProductList;
        }
    }
}
