
using ENAapp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace ENAapp
{
    public interface IFileService
    {
        bool Lenght(IFormFile file);
        bool IsExcell(IFormFile file);
        string[] Head(string path);
        string GetContentType(string fullPath);
        Dictionary<string, string> GetMimeTypes();
        void SaveFile(IHostingEnvironment hostingEnvironment,IFormFile file);
        List<Compte> GetCompteInFile(string path);
    }
}
