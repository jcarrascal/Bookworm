using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace DotNetBytes.Bookworm.Core.Xlsx
{
    internal class XlsxWorkbook : Workbook, IDisposable
    {
        private static readonly XNamespace NS = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
        private ZipArchive _zipArchive;

        public XlsxWorkbook(Stream inputStream)
        {
            this._zipArchive = new ZipArchive(inputStream);
            ZipArchiveEntry workbookEntry = this._zipArchive.GetEntry("xl/workbook.xml");
            using (Stream workbookStream = workbookEntry.Open())
            {
                var document = XDocument.Load(workbookStream);
                this.Sheets = document.Descendants(NS + "sheet").Select(e => e.Attribute("name").Value).ToArray();
            }
        }

        ~XlsxWorkbook()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._zipArchive != null)
                {
                    this._zipArchive.Dispose();
                    this._zipArchive = null;
                }
            }
        }
    }
}