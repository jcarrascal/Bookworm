using DotNetBytes.Bookworm.Core;
using NUnit.Framework;
using System;
using System.IO;

namespace DotNetBytes.Bookworm.Tests
{
    [TestFixture]
    public class WorkbookTests
    {
        [Test]
        public void WhenGivenAnEmptyFile_ThenReturnsOneSheetAndNoData()
        {
            using (Stream stream = TestHelper.GetResourceStream("Samples/XlsxEmpty.xlsx"))
            {
                Workbook workbook = Workbook.Load(stream);
                Assert.That(workbook.Sheets, Is.EquivalentTo(new string[] { "Sheet1" }));
            }
        }

        [Test]
        public void WhenGivenANullStream_ThenThrowsAnArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Workbook.Load((Stream)null));
        }
    }
}