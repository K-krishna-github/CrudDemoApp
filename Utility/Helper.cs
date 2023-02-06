namespace CrudDemoApp.Utility
{
    public class Helper
    {
        public static string Connectionstring { get; set; }
        public static string SymmetricSeccurityKey { get;private set; }
        private static IConfiguration _configuration;

        public static void Loadconfigurations(IConfiguration configuration)
        {
            _configuration = configuration;
            Connectionstring = configuration.GetConnectionString("EmployeeContext");
            SymmetricSeccurityKey = configuration["SecurityConfig:symmetricSecurityKey"];
        }
    }
}
