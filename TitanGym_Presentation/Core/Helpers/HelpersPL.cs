using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitanGym_Presentation.Core.Helpers
{
    public class HelpersPL
    {
        public static string DirectoryPath
        {

            get
            {
                return @"C:\ImagesTitanGym\";
            }
        }

        private static bool _CreateDirectory()
        {
            try
            {
                if (!System.IO.Directory.Exists(DirectoryPath))
                    System.IO.Directory.CreateDirectory(DirectoryPath);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private static string GenarateGUID()
        {
            Guid guid = Guid.NewGuid();

            return guid.ToString();
        }

        private static string GetTheExtentionFile(string FileName)
        {
            return System.IO.Path.GetExtension(FileName);
        }

        private static string GenarateNewFileName(string ImagePath)
        {
            return GenarateGUID() + GetTheExtentionFile(ImagePath);
        }

        public static string SaveTheImage(string PathImage)
        {
            if (!_CreateDirectory()) return "";

            string SoruseFile = PathImage;
            string NewImagePath = GenarateNewFileName(PathImage);
            string DestanationFile = DirectoryPath + NewImagePath;

            try
            {

                System.IO.File.Copy(SoruseFile, DestanationFile);
                return NewImagePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");

                return "";
            }
        }
    }
}
