namespace BauruEmpregosBack.Data
{
    public interface IStoreDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
