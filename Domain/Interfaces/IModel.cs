namespace Domain.Interfaces
{
    public interface IModel<T>
    {
        T GetWather(string city);
        string GetIcon();
       

    }
}
