using MauiAppTempoAgoraSQLite.Helpers;

namespace MauiAppTempoAgora
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db;
        public static SQLiteDatabaseHelper Db
        {

            get
            {
                if (_db == null)
                {
                    // Define o caminho do arquivo do banco de dados SQLite
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_tempo.db3");
                    // Inicializa o helper do banco de dados com o caminho definido
                    _db = new SQLiteDatabaseHelper(path);
                }
                return _db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}