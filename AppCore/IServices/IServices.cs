namespace AppCore.IServices
{
    public interface IServices<T>
    {
        T GetWather(string city);
        string GetIcon();
       
    }
}
