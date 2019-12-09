using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Yad2Project.Models
{
    public class ImageInfo
    {
        public IFormFile PhotoAvatar { get; set; }
        public string ImageName { get; set; }
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }

        public void SetFileInfo(IFormFile photoAvatar)
        {
            if(photoAvatar != null && photoAvatar.Length>0)
            {
                PhotoAvatar = photoAvatar;
                ImageMimeType = photoAvatar.ContentType;
                ImageName = Path.GetFileName(PhotoAvatar.FileName);

                using (var memoryStream = new MemoryStream())
                {
                    PhotoAvatar.CopyTo(memoryStream);
                    PhotoFile = memoryStream.ToArray();
                }
            }
    
        }


    }

  
}
