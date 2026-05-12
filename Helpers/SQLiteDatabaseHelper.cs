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
            conexao.CreateTableAsync<UserLocation>().Wait();
        }

        //------------------------------------------------------
        // Métodos para User
        //------------------------------------------------------

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

        public Task<User> GetUserByEmail(string email)
        {
            return conexao.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public Task<int> UpdateUser(User u)
        {
            return conexao.UpdateAsync(u);
        }

        public Task<List<User>> SearchUserByName(string name)
        {
            return conexao.Table<User>().Where(u => u.Name.Contains(name)).ToListAsync();
        }

        //------------------------------------------------------
        // Métodos para UserLocation
        //------------------------------------------------------

        public Task<int> InsertUserLocation(UserLocation ul)
        {
            return conexao.InsertAsync(ul);
        }

        public Task<List<UserLocation>> GetUserLocationByUserId(int user_id)
        {
            return conexao.Table<UserLocation>().Where(u => u.UserId == user_id).ToListAsync();
        }

        public Task<UserLocation> GetUserLocation(int id)
        {
            return conexao.Table<UserLocation>().Where(u => u.UserId == id).FirstOrDefaultAsync();
        }

        public Task<int> UpdateUserLocation(UserLocation u)
        {
            return conexao.UpdateAsync(u);
        }

        public Task<int> DeleteUserLocation(UserLocation ul)
        {
            return conexao.DeleteAsync(ul);
        }
    }
}
