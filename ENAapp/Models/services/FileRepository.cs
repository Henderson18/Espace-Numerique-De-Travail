using ENAapp.Models;
using ENAapp.utils;
using ENT_Background.enumeration;
using GrapeCity.Documents.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace ENAapp
{
    public class FileRepository : IFileService
    {

        public void SaveFile(IHostingEnvironment _hostingEnvironment,IFormFile file)
        {
            string newPath = Path.Combine(_hostingEnvironment.WebRootPath, "upload");

            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            string fullPath = Path.Combine(newPath, file.FileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

           
        }

        public bool IsExcell(IFormFile file)
        {
            if (!file.FileName.EndsWith("xlsx"))
            {
                return false;
            }

            return true;
        }

        public bool Lenght(IFormFile file)
        {
            if(file.Length == 0)
            {
                return false;
            }

            return true;
        }

        public string GetContentType(string fullPath)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(fullPath).ToLowerInvariant();
            return types[ext];
        }


        public Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        public string[] Head(string path)
        {
            List<string> head = new List<string>();

            Workbook workbook = new Workbook();
            workbook.Open(path, OpenFileFormat.Xlsx);
            IWorksheet worksheet = workbook.Worksheets[0];

            for (int i = 0; i < worksheet.Columns.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(worksheet.Range[0, i].Text)) continue;

                string range = worksheet.Range[0, i].Text.ToLower();

                head.Add(range);
            }

            return head.ToArray();
        }

        public List<Compte> GetCompteInFile(string path)
        {
            List<Compte> comptes = new List<Compte>();

            Workbook workbook = new Workbook();
            workbook.Open(path, OpenFileFormat.Xlsx);
            IWorksheet worksheet = workbook.Worksheets[0];

            for (int i = 1; i < worksheet.Rows.Count; i++)
            {
                if (
                    string.IsNullOrWhiteSpace(worksheet.Range[i, 0].Text) ||
                    string.IsNullOrWhiteSpace(worksheet.Range[i, 1].Text)
                   ) continue;

                Compte compte = new Compte();

                if (worksheet.Range[0 , 0].Text == "matricule")
                {

                    compte.Matricule = worksheet.Range[i, 0].Text;

                    compte.Email = worksheet.Range[i, 1].Text;

                    compte.Profil = (int) Profil.ETUDIANT;

                    compte.Passhash = Hash.generate();

                    compte.ConfirmationToken = Hash.str_random(60);
                }
                else
                {

                    compte.Matricule = worksheet.Range[i, 1].Text;

                    compte.Email = worksheet.Range[i, 0].Text;

                    compte.Profil = (int)Profil.ETUDIANT;

                    compte.Passhash = Hash.generate();

                    compte.ConfirmationToken = Hash.str_random(60);

                }

                comptes.Add(compte);
            }

            return comptes;
        }
    }
}
