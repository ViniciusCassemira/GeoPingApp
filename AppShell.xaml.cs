namespace GeoPingApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("userLogin", typeof(Views.UserLogin));
            Routing.RegisterRoute("userRegister", typeof(Views.UserRegister));
            Routing.RegisterRoute("userRecoverPassword", typeof(Views.UserRecoverPassword));
        }
    }
}
