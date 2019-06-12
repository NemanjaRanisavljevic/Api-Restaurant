using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helpers
{
    public class FileUpload
    {
        public static IEnumerable<string> AllowExtensions => new List<string> { ".jpeg",".jpg",".gif",".png"};
    }
}
