using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;


namespace xam
{
    public partial class App : Application
    {
        public const string DBFILENAME = "booksapp.db";
        public App()
        {
            InitializeComponent();

            string dbPath = DependencyService.Get<IPath>().GetDatabasePath(DBFILENAME);
            using (var db = new ApplicationContext(dbPath))
            {
                // Создаем бд, если она отсутствует
                db.Database.EnsureCreated();
                if (db.Book.Count() == 0)
                {
                    db.Book.Add(new Books { Name = "Отцы и дети", Author = "И. Тургенев", Price = 1000 });
                    db.Book.Add(new Books { Name = "Муму", Author = "И. Тургенев", Price = 800 });
                    db.Book.Add(new Books { Name = "1984", Author = "Д. Оруэлл", Price = 900  });
                    db.Book.Add(new Books { Name = "Мастер и Маргарита", Author = "М. Булгаков", Price = 1200 });

                    db.SaveChanges();
                }
            }

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
