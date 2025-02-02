using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace CarMarketplace.Services
{
    public class ImageService
    {
        private readonly Cloudinary _cloudinary;
        public ImageService(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, stream),
                        Transformation = new Transformation().Crop("fill").Width(500).Height(500)
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                    // Return the URL of the uploaded image
                    return uploadResult.SecureUrl.ToString(); 
                }
            }
            return null;
        }
        public async Task<List<string>> UploadImagesAsync(IEnumerable<IFormFile> files)
        {
            var uploadedUrls = new List<string>();

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file.FileName, stream),
                            Transformation = new Transformation().Crop("limit").Width(500).Height(500)
                        };

                        var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                        if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            // Add the URL to the list
                            uploadedUrls.Add(uploadResult.SecureUrl.ToString()); 
                        }
                    }
                }
            }

            // Return the list of URLs for the uploaded images
            return uploadedUrls; 
        }
    }
}
