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
            this.list = _list;
            listview.ItemsSource = new ObservableCollection<DataModel>(_list);
            listview.ItemTapped += DisableSelection;
            listview.ItemSelected += ItemIsChecked;
        }

        List<DataModel> list = null;

        private void ItemIsChecked(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            DataModel pdm = list.Where(dm => dm.Equals((DataModel)e.SelectedItem)).FirstOrDefault();
            if (pdm != null){
                if (pdm.Flag){
                    pdm.Flag = false;
                }else{
                    pdm.Flag = true;
                }
            }
            list[list.IndexOf(pdm)] = pdm;
            List<DataModel> SortedList = list.OrderBy(o => o.Flag).ToList();
            listview.ItemsSource = new ObservableCollection<DataModel>(SortedList);
        }

        private void DisableSelection(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            ((ListView)sender).SelectedItem = null;
            Int32 counter = 0;
            foreach (DataModel dm in list){
                if (dm.Flag)
                    counter++;
            }
            if (counter == list.Count){
                App.Current.MainPage = new ThirdPage();

            }
        }

    }
}