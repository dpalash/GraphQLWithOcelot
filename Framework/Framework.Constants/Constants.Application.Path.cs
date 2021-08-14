using System;
using System.IO;

namespace Framework.Constants
{
    public static partial class Constants
    {
        public struct Application
        {
            public struct Paths
            {
                private static string BasePath => AppDomain.CurrentDomain.BaseDirectory;
                private static string AppDataPath => Path.Combine(BasePath, "AppData");
                public static string TicketFilesPath => Path.Combine(AppDataPath, "TicketFiles");
                public static string CompanyProfileImagePath => Path.Combine(AppDataPath, "CompanyProfileImages");
                public static string CustomerProfileImagePath => Path.Combine(AppDataPath, "CustomerProfileImages");
                public static string EmployeeProfileImagePath => Path.Combine(AppDataPath, "EmployeeProfileImages");
                public static string SupplierProfileImagePath => Path.Combine(AppDataPath, "SupplierProfileImages");
                public static string AirlinesDataPath => Path.Combine(AppDataPath, "AirlinesData");
            }
        }
    }
}
