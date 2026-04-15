using Microsoft.Extensions.DependencyInjection;
using GeoPingApp.Helpers;

namespace GeoPingApp
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper? _db;

        public static SQLiteDatabaseHelper Db
        {
            get
            {
                if (_db == null)
                {
                    string caminho_pro_arquivo = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                            "banco_sqlite.db3"
                    );

                    _db = new SQLiteDatabaseHelper(caminho_pro_arquivo);
                }
                return _db;
            }
        }

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}