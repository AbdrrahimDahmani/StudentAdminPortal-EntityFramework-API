namespace StudentAdminPortal.API.Repositories
{
    public class LocalStorageImageRepository:IImageRepository
    {
        public async Task<string> Upload(IFormFile file, string fileName)
        {
            var filePath = Path.Combine(@"Ressources\Images",fileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return filePath;
        }
        /*private string GetServerRelativePath(string fileName)
        {
            return Path.Combine(@"Ressources\Images", fileName);
        }*/
    }
}
