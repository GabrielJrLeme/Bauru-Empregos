﻿
namespace BauruEmpregosBack.Data
{
   
    public class StoreDatabaseSettings : IStoreDatabaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

}
