using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Manager
{
    public static class PathManager
    {
        public static string BaseDir => AppDomain.CurrentDomain.BaseDirectory;
        public static string ImageDir => Path.GetFullPath(Path.Combine(BaseDir, @"..\..\..\Resources\Images"));
        public static string DatabaseDir => Path.GetFullPath(Path.Combine(BaseDir, @"..\..\..\Resources\Database"));
        public static string DatabasePath => Path.Combine(DatabaseDir, "PersonalLibraryManagement.db");

        static PathManager()
        {
            // đảm bảo thư mục tồn tại
            Directory.CreateDirectory(ImageDir);
            Directory.CreateDirectory(DatabaseDir);

            // tạo file DB nếu chưa có
            if (!File.Exists(DatabasePath))
            {
                using (File.Create(DatabasePath)) { }
            }
        }

        public static string GetImagePath(string imageName)
        {
            if (imageName == null)
            {
                return Path.Combine(ImageDir, "place-holder.png");
            }
            return Path.Combine(ImageDir, imageName);
        }
    }

}
