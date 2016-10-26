using System;
using System.IO;
using DotNetBytes.Bookworm.Core.Xlsx;

namespace DotNetBytes.Bookworm.Core
{
    public class Workbook
    {
        public string[] Sheets { get; protected set; }

        public static Workbook Load(Stream inputStream)
        {
            if (inputStream == null)
            {
                throw new ArgumentNullException(nameof(inputStream));
            }

            return new XlsxWorkbook(inputStream);
        }
    }
}