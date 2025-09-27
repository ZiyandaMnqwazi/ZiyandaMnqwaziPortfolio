namespace ZiyandaMnqwaziPortfolio.Repositories
{
    public interface ISqlDataAccess
    {

        Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string connection = "DefaultConnection");
        Task<int> SaveData<T>(string spName, T parameters, string connection = "DefaultConnection");
        Task<int> GetSingleValue<T, P>(string spName, P parameters, string connection = "DefaultConnection");
        Task<IEnumerable<T>> GetData<T>(string query, object parameters, string connection = "DefaultConnection");
    }
}
