namespace Horder.Repository;

public abstract class RepositoryBase
{
    public RepositoryBase()
    {
        
    }

    protected string _connectionString = "Host=localhost;Username=postgres;Password=password;Database=horder";
}