using storeBl.Bl;
using storeBl.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace storeWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //void FillItemData()
        //{
        //    clsItems oClsItems = new clsItems();
        //    List<itemModel> lisItems = oClsItems.GetAll();
           
        //    GVitems.ItemsSource = lisItems;
        //    GVitems.Items.Clear(); // clear existing items
        //}



        public MainWindow()
        {
            InitializeComponent();
            //FillItemData();


        }
        private void Button_Click(object sender, RoutedEventArgs e) // get data from user and stor it in clsItem
        {
            clsItems oClsItems = new clsItems();
            itemModel oItemModel = new itemModel();
            oItemModel.itemId = Convert.ToInt32(itemID.Text);
            oItemModel.itemName = itemeName.Text;
            oItemModel.itemPrice = Convert.ToDecimal(itemPrice.Text);
            oClsItems.Add(oItemModel);
            //FillItemData();




        }
    }
}
