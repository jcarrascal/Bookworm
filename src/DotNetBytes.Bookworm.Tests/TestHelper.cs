using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DotNetBytes.Bookworm.Tests
{
    public static class TestHelper
    {
        public static Stream GetResourceStream(this object obj, string path)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            Type type = obj.GetType();
            string name = type.Namespace + "." + path.Replace("\\", ".");
            Stream stream = type.GetTypeInfo().Assembly.GetManifestResourceStream(name);
            return stream;
        }
    }
}
