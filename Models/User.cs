using SQLite;

namespace GeoPingApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        string _name { get; set; }
        string _email { get; set; }
        string _password { get; set; }

        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public string Name
        {
            get => _name;
            set
            {
                if (value == null) throw new Exception("Informe o nome do usuário");

                _name = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (value == null) throw new Exception("Informe o e-mail do usuário");

                _email = value;
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (value == null) throw new Exception("Informe a senha do usuário");

                _password = value;
            }
        }
    }
}
