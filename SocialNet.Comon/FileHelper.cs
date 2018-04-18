using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNet.Comon
{
    public class FileHelper
    {
        private static string _baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static void DeleteImage(string name)
        {
            var templatePath = _baseDirectory + "/Images/" + name;
            System.IO.File.Delete(templatePath);
        }
    }
}
