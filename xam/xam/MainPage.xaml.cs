using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xam
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();









            //Title = "Main Page";
            //Button toCommonPageBtn = new Button
            //{
            //    Text = "На обычную страницу",
            //    HorizontalOptions = LayoutOptions.Center,
            //    VerticalOptions = LayoutOptions.EndAndExpand,
            //    WidthRequest = 200
            //};
            //toCommonPageBtn.Clicked += ToCommonPage;
            //Content = new StackLayout { Children = { toCommonPageBtn } };
        }

        protected override void OnAppearing()
        {
            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                bookList.ItemsSource = db.Book.ToList();
            }
            base.OnAppearing();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Books selectedFriend = (Books)e.SelectedItem;
            BookPage bookPage = new BookPage();
            bookPage.BindingContext = selectedFriend;
            await Navigation.PushAsync(bookPage);
        }

        private async void CreateBook(object sender, EventArgs e)
        {
            Books book = new Books();
            BookPage bookPage = new BookPage();
            bookPage.BindingContext = book;
            await Navigation.PushAsync(bookPage);
        }


        //private async void ToCommonPage(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new CommonPage());
        //}


    }
}
