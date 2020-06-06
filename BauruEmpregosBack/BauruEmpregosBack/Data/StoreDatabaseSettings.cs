
namespace BauruEmpregosBack.Data
{
   
    public class StoreDatabaseSettings : IStoreDatabaseSettings
    {
        public string VacancyCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IStoreDatabaseSettings
    {
        string VacancyCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
