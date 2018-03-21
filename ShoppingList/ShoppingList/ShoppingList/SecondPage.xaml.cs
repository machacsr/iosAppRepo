using ShoppingList.iOS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShoppingList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SecondPage : ContentPage
	{
		public SecondPage(List<DataModel> _list)
		{
			InitializeComponent ();
            foreach (DataModel dm in _list) {
                Console.WriteLine(dm.Data);
            }
            listview.ItemsSource = new ObservableCollection<DataModel>(_list);

            

        }
    }
}