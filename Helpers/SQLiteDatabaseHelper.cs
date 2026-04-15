using SQLite;
using GeoPingApp.Models;

namespace GeoPingApp.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection conexao;

        public SQLiteDatabaseHelper(string caminho_pro_db3)
        {
            conexao = new SQLite.SQLiteAsyncConnection(caminho_pro_db3);
            conexao.CreateTableAsync<User>().Wait();
        }

        public Task<int> InsertUser(User p)
        {
            return conexao.InsertAsync(p);
        }

        public Task<List<User>> GetAllUsers()
        {
            return conexao.Table<User>().ToListAsync();
        }

        public Task<User> GetUser(User p)
        {
            return conexao.Table<User>().Where(u => u.Email == p.Email && u.Password == p.Password).FirstOrDefaultAsync();
        }

        public Task<User> GetUserByEmail(User p)
        {
            return conexao.Table<User>().Where(u => u.Email == p.Email).FirstOrDefaultAsync();
        }
    }
}
