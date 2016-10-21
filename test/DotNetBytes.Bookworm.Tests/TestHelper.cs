using System;
using System.IO;
using System.Reflection;

namespace DotNetBytes.Bookworm.Tests
{
    public static class TestHelper
    {
        public static Stream GetResourceStream(string absolutePath)
        {
            if (string.IsNullOrEmpty(absolutePath))
            {
                throw new ArgumentNullException(nameof(absolutePath));
            }

            TypeInfo typeInfo = typeof(TestHelper).GetTypeInfo();
            string resourceName = typeInfo.Namespace + "." + absolutePath.Replace('\\', '.').Replace('/', '.');
            Stream stream = typeInfo.Assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new FileNotFoundException(string.Format("The file {0} was not found.", resourceName));
            }

            return stream;
        }
    }
}