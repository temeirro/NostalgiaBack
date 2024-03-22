using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Webp;
using Size = SixLabors.ImageSharp.Size;


namespace Core.Services
{
    public class FilesService : IFilesService
    {
        private const string imageFolder = "uploads";
        private readonly IWebHostEnvironment _environment;
        int[] sizes = { 320, 600, 1200 };

        public FilesService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SavePostImage(IFormFile file)
        {
            try
            {
                string root = _environment.WebRootPath;
                string newNameFile = Guid.NewGuid().ToString();
                string fileName = $"{newNameFile}.webp";

                foreach (int size in sizes)
                {
                    string fullFileName = $"{size}_{newNameFile}.webp";
                    string imagePath = Path.Combine(imageFolder, fullFileName);
                    string imageFullPath = Path.Combine(root, imagePath);
                    {
                        using (var image = Image.Load(file.OpenReadStream()))
                        {
                            image.Mutate(x => x.Resize(new ResizeOptions
                            {
                                Size = new Size(size, size),
                                Mode = ResizeMode.Max
                            }));
                            await image.SaveAsync(imageFullPath, new WebpEncoder());
                        }
                    }
                }
                return fileName;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні файлу {ex.Message}");
                return ex.Message;
            }
        }
    }
}
