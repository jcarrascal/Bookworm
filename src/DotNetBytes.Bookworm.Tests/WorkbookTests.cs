using DotNetBytes.Bookworm.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace DotNetBytes.Bookworm.Tests
{
    public class WorkbookTests
    {
        private const string XLSX_EMPTY = "Samples.XlsxEmpty.xlsx";

        [Fact]
        public void WhenGivenAnEmptyFile_ThenReturnsOneSheetAndNoData()
        {
            using (var stream = this.GetResourceStream(@"Samples\XlsxEmpty.xlsx"))
            {
                Console.WriteLine(stream.ReadByte());
                Console.WriteLine(stream.ReadByte());
                Console.WriteLine(stream.ReadByte());
                Console.WriteLine(stream.ReadByte());
            }
        }
    }
}
