using Microsoft.Extensions.Hosting;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.IO;

namespace AlfaTask
{
    public class AddToTable
    {
        Load file = new Load();
        Search text = new Search();
        IHostingEnvironment hosting;
        public void CreateTable()
        {

            var rootFolder = Directory.GetCurrentDirectory();
            rootFolder = rootFolder.Substring(0,
                        rootFolder.IndexOf(@"\AlfaTask-master\", StringComparison.Ordinal) + @"\AlfaTask-master\".Length);
            string path = Path.GetFullPath(Path.Combine(rootFolder, "testDoc.rtf"));

            //string path = Path.Combine(hosting.ContentRootPath , "testDoc.rtf");
            string a = file.LoadFile(path);


            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Сurrency control");
            sheet.SetColumnWidth(0, 8000);

            IRow row = sheet.CreateRow(0);

            ICell cell01 = row.CreateCell(0);
            cell01.SetCellValue("Регистрационный номер сделки");
            ICell cell02 = row.CreateCell(1);
            cell02.SetCellValue(text.SearchInString(a, "Регистрационный номер сделки"));

            IRow row1 = sheet.CreateRow(1);
            ICell cell11 = row1.CreateCell(0);
            cell11.SetCellValue("Номер договора");
            ICell cell12 = row1.CreateCell(1);
            cell12.SetCellValue(text.SearchInString(a, "Номер договора"));

            IRow row2 = sheet.CreateRow(2);
            ICell cell21 = row2.CreateCell(0);
            cell21.SetCellValue("Счет контрагента");
            ICell cell22 = row2.CreateCell(1);
            cell22.SetCellValue(text.SearchInString(a, "Счет контрагента"));

            IRow row3 = sheet.CreateRow(3);
            ICell cell31 = row3.CreateCell(0);
            cell31.SetCellValue("Адрес контрагента");
            ICell cell32 = row3.CreateCell(1);
            cell32.SetCellValue(text.SearchInString(a, "Адрес контрагента"));

            IRow row4 = sheet.CreateRow(4);
            ICell cell41 = row4.CreateCell(0);
            cell41.SetCellValue("Наименование договора");
            ICell cell42 = row4.CreateCell(1);
            cell42.SetCellValue(text.SearchInString(a, "Наименование договора"));


            using (FileStream stream = new FileStream(Path.Combine(rootFolder, @"outfile.xlsx"), FileMode.Create, FileAccess.Write))
            {
                workbook.Write(stream);
            }
        }
    }
}
