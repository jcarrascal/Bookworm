using DotNetBytes.Bookworm.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DotNetBytes.Bookworm.Tests
{
    [TestFixture]
    public class WorkbookTests
    {
        [Test]
        public void WhenGivenANullStreamOrBinaryReader_ThenThrowsAnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Workbook.Load((Stream)null));
            Assert.Throws<ArgumentNullException>(() => Workbook.Load((BinaryReader)null));
        }

        [Test]
        public void WhenGivenAnEmptyFile_ThenReturnsOneSheetAndNoData()
        {
            using (Stream stream = TestHelper.GetResourceStream("Samples/XlsxEmpty.xlsx"))
            {
                Workbook workbook = Workbook.Load(stream);
                Assert.That(workbook.SheetNames, Is.EquivalentTo(new string[] { "Sheet1" }));
            }
        }
    }
}
