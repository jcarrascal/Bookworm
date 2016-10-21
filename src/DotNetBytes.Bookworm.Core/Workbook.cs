using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DotNetBytes.Bookworm.Core
{
    public class Workbook
    {
        public static Workbook Load(Stream inputStream)
        {
            if (inputStream == null)
            {
                throw new ArgumentNullException(nameof(inputStream));
            }

            using (var binaryReader = new BinaryReader(inputStream))
            {
                return Load(binaryReader);
            }
        }

        public static Workbook Load(BinaryReader binaryReader)
        {
            if (binaryReader == null)
            {
                throw new ArgumentNullException(nameof(binaryReader));
            }

            throw new NotImplementedException();
        }

        public string[] SheetNames { get; private set; }
    }
}
