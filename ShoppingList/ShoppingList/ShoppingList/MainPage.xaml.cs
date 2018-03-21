using ShoppingList.iOS.Controller;
using ShoppingList.iOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ShoppingList
{
    public partial class MainPage : ContentPage 
    {
        public MainPage() 
        {
            InitializeComponent();
            this.button.Clicked += NextPage;
        }

        private void NextPage(object sender, EventArgs e) {
            App.Current.MainPage = new SecondPage(ProcessText(this.editor.Text));
        }

        private List<DataModel> ProcessText(String text) {
             return EditorTextController.CreateList(text);
        }
    }
}
