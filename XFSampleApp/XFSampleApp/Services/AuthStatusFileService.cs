using System;
using System.Collections.Generic;
using System.Text;

namespace XFSampleApp.Services
{
    public class AuthStatusFileService
    {
        private static string GetFileFullPath()
        {
            var cacheDir = Xamarin.Essentials.FileSystem.CacheDirectory;
            //var mainDir = Xamarin.Essentials.FileSystem.AppDirectory;

            System.Diagnostics.Debug.WriteLine(cacheDir);
            //System.Diagnostics.Debug.WriteLine(mainDir);

            var fullPath = cacheDir + "auth.log";
            //var fullPath = mainDir() + "auth.log";

            return fullPath;
        }
        public static bool CheckIsAuth()
        {
            var fullPath = GetFileFullPath();

            if (System.IO.File.Exists(fullPath))
            {
                var result = System.IO.File.ReadAllText(fullPath);

                return result.StartsWith("Be Authorized,");
            }
            return false;
        }

        public static void SaveAuthData()
        {
            var fullPath = GetFileFullPath();

            System.IO.File.WriteAllText(fullPath, $"Be Authorized,{DateTime.Now.Ticks}");

            ////看看有沒有成功寫入資料
            //var result = File.ReadAllText(fullPath);
            //System.Diagnostics.Debug.WriteLine(result);

        }

        public static void DeleteAuthData()
        {
            var fullPath = GetFileFullPath();

            System.IO.File.Delete(fullPath);
        }
    }
}
