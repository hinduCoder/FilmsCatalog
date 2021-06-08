using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FilmsCatalog.Extensions
{
    public static class IFormFieldExtensions
    {
        public static async Task<byte[]> GetBytesAsync(this IFormFile formFile)
        {
            using var stream = formFile.OpenReadStream();
            var buffer = new byte[formFile.Length];
            await stream.ReadAsync(buffer);
            return buffer;
        }
    }
}
