namespace Contact_Management.Services
{
    public interface IFileService
    {
        string? GetContentFromFile(string filePath);
        bool SaveToFile(string filePath, string content);
    }
}