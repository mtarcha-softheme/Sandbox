namespace MvpProject
{
    public interface IController
    {
        void SaveToFile(string text);

        void LoadFromFile();
    }
}