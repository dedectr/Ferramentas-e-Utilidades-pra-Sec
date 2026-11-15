namespace src.Interfaces
{

    public interface IRedes
    {
        Task<bool> Excute();
        Task Logic(string? msg);
    }
}
