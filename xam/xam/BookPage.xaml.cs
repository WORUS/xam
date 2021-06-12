using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage
    {

        string dbPath;

        public BookPage()
        {
            InitializeComponent();
            dbPath = DependencyService.Get<IPath>().GetDatabasePath(App.DBFILENAME);
        }


        private void SaveBook(object sender, EventArgs e)
        {
            var book = (Books)BindingContext;
            if (!String.IsNullOrEmpty(book.Name))
            {
                using (ApplicationContext db = new ApplicationContext(dbPath))
                {
                    if (book.Id == 0)
                        db.Book.Add(book);
                    else
                    {
                        db.Book.Update(book);
                    }
                    db.SaveChanges();
                }
            }
            this.Navigation.PopAsync();
        }

        private void DeleteBook(object sender, EventArgs e)
        {
            var book = (Books)BindingContext;
            using (ApplicationContext db = new ApplicationContext(dbPath))
            {
                db.Book.Remove(book);
                db.SaveChanges();
            }
            this.Navigation.PopAsync();
        }
    }
}