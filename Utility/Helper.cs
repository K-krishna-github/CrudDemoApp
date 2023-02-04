namespace CrudDemoApp.Utility
{
    public class Helper
    {
        public static string Connectionstring { get; set; }
        public static string SymmetricSeccurityKey { get; set; }
        private static IConfiguration _configuration;

        public static void Loadconfigurations(IConfiguration configuration)
        {
            _configuration = configuration;
            Connectionstring = _configuration.GetConnectionString("EmployeeContext");
            SymmetricSeccurityKey = _configuration["SecurityConfig:symmetricseccurityKey"];
        }
    }
}
