using System;

namespace TitanGym_Presentation.Core.Utility
{
    public class Utility
    {
        public static string DirectoryPath
        {

            get
            {
                return @"C:\ImagesTitanGym\";
            }
        }
        public static string FileRemPath
        {

            get
            {
                return @"F:\RememberMeTitanGYM.txt";
            }
        }

        private static bool IsFileExists(string PathFile)
        {
            if (string.IsNullOrWhiteSpace(PathFile))
                return false;

            if (!System.IO.File.Exists(PathFile))
            {
                System.IO.File.Create(PathFile).Close();
                return false;
            }

            return true;
        }

        private static bool _CreateDirectory()
        {
            try
            {
                if (!System.IO.Directory.Exists(DirectoryPath))
                    System.IO.Directory.CreateDirectory(DirectoryPath);

                return true;
            }
            catch
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


        public static bool DeleteImageFromFile(string ImagePath)
        {

            if (!_CreateDirectory()) return false;

            if (string.IsNullOrWhiteSpace(ImagePath)) return false;

            try
            {
                System.IO.File.Delete(DirectoryPath + ImagePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool RememberMe(string Username, string Passwrod)
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Passwrod))
                return false;

            if (!IsFileExists(FileRemPath)) return false;

            System.IO.StreamWriter SW = new System.IO.StreamWriter(FileRemPath, false);
            string Line = $"{Username}#||#{Passwrod}";

            SW.WriteLine(Line);

            SW.Close();

            return true;
        }

        private static string[] SplitString(string Line, string Separator)
            => Line.Split(new string[] { Separator }, StringSplitOptions.RemoveEmptyEntries);

        public static bool GetUsernameAndPasswordFromFileRememberMe(ref string Username, ref string Passwrod)
        {

            if (!IsFileExists(FileRemPath)) return false;

            System.IO.StreamReader SR = new System.IO.StreamReader(FileRemPath, false);

            string Line = "";
            if (!string.IsNullOrWhiteSpace((Line = SR.ReadLine())))
            {
                var result = SplitString(Line, "#||#");
                Username = result[0];
                Passwrod = result[1];
                SR.Close();
                return true;
            }

            SR.Close();

            return false;
        }

        public static void DeleteFile()
        {
            if (System.IO.File.Exists(FileRemPath))
                System.IO.File.Delete(FileRemPath);
        }

    }
}
