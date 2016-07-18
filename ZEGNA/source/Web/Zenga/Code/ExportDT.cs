using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Zenga.Web
{
    public class ExportDT
    {
        public static MemoryStream RenderDataTableToExcel(DataTable SourceTable)
        {
            XSSFWorkbook workbook = null;
            MemoryStream ms = null;
            ISheet sheet = null;
            XSSFRow headerRow = null;
            try
            {
                workbook = new XSSFWorkbook();
                ms = new MemoryStream();
                sheet = workbook.CreateSheet();
                headerRow = (XSSFRow)sheet.CreateRow(0);
                foreach (DataColumn column in SourceTable.Columns)
                    headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                int rowIndex = 1;
                foreach (DataRow row in SourceTable.Rows)
                {
                    XSSFRow dataRow = (XSSFRow)sheet.CreateRow(rowIndex);
                    foreach (DataColumn column in SourceTable.Columns)
                    {
                        dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                    }
                    ++rowIndex;
                }
                //列宽自适应，只对英文和数字有效
                //for (int i = 0; i <= SourceTable.Columns.Count; ++i)
                //    sheet.AutoSizeColumn(i);
                workbook.Write(ms);
                ms.Flush();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                ms.Close();
                sheet = null;
                headerRow = null;
                workbook = null;
            }
            return ms;
        }

        /// <summary>
        /// DataTable导出到Excel的MemoryStream（2007）
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        public static MemoryStream ExportDTI(DataTable dtSource)
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            XSSFSheet sheet = workbook.CreateSheet() as XSSFSheet;
            MemoryStream ms = new MemoryStream();
            #region 右击文件 属性信息

            //{
            //    DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            //    dsi.Company = "http://www.yongfa365.com/";
            //    workbook.DocumentSummaryInformation = dsi;

            //    SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            //    si.Author = "柳永法"; //填加xls文件作者信息
            //    si.ApplicationName = "NPOI测试程序"; //填加xls文件创建程序信息
            //    si.LastAuthor = "柳永法2"; //填加xls文件最后保存者信息
            //    si.Comments = "说明信息"; //填加xls文件作者信息
            //    si.Title = "NPOI测试"; //填加xls文件标题信息
            //    si.Subject = "NPOI测试Demo"; //填加文件主题信息
            //    si.CreateDateTime = DateTime.Now;
            //    workbook.SummaryInformation = si;
            //}

            #endregion

            XSSFCellStyle dateStyle = workbook.CreateCellStyle() as XSSFCellStyle;
            XSSFDataFormat format = workbook.CreateDataFormat() as XSSFDataFormat;
            dateStyle.DataFormat = format.GetFormat("yyyy-MM-dd hh:mm:ss");

            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            }
            int rowIndex = 0;

            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式

                if (rowIndex == 0)
                {
                    #region 表头及样式
                    //{
                    //    XSSFRow headerRow = sheet.CreateRow(0) as XSSFRow;
                    //    headerRow.HeightInPoints = 25;
                    //    headerRow.CreateCell(0).SetCellValue(strHeaderText);

                    //    XSSFCellStyle headStyle = workbook.CreateCellStyle() as XSSFCellStyle;
                    //    headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    //    XSSFFont font = workbook.CreateFont() as XSSFFont;
                    //    font.FontHeightInPoints = 20;
                    //    font.Boldweight = 700;
                    //    headStyle.SetFont(font);

                    //    headerRow.GetCell(0).CellStyle = headStyle;

                    //    //sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                    //    //headerRow.Dispose();
                    //}

                    #endregion


                    #region 列头及样式

                    {
                        XSSFRow headerRow = sheet.CreateRow(0) as XSSFRow;


                        XSSFCellStyle headStyle = workbook.CreateCellStyle() as XSSFCellStyle;
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                        XSSFFont font = workbook.CreateFont() as XSSFFont;
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);


                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256);

                        }
                        //headerRow.Dispose();
                    }

                    #endregion

                    rowIndex = 1;
                }

                #endregion

                #region 填充内容

                XSSFRow dataRow = sheet.CreateRow(rowIndex) as XSSFRow;
                foreach (DataColumn column in dtSource.Columns)
                {
                    XSSFCell newCell = dataRow.CreateCell(column.Ordinal) as XSSFCell;

                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String": //字符串类型
                            double result;
                            if (isNumeric(drValue, out result))
                            {

                                double.TryParse(drValue, out result);
                                newCell.SetCellValue(result);
                                break;
                            }
                            else
                            {
                                newCell.SetCellValue(drValue);
                                break;
                            }

                        case "System.DateTime": //日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            if (!string.IsNullOrEmpty(drValue))
                            {
                                newCell.SetCellValue(drValue);

                                newCell.CellStyle = dateStyle; //格式化显示
                            }
                            else
                            {
                                newCell.SetCellValue("");
                            }
                            break;
                        case "System.Boolean": //布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16": //整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal": //浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull": //空值处理
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }

                #endregion

                rowIndex++;
            }
            workbook.Write(ms);
            ms.Flush();

            return ms;
        }

        /// <summary>
        /// DataTable导出到Excel文件
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">保存位置</param>
        public static void ExportDTtoExcel(DataTable dtSource, string strHeaderText, string strFileName)
        {
            string[] temp = strFileName.Split('.');

            if (temp[temp.Length - 1] == "xls" && dtSource.Columns.Count < 256 && dtSource.Rows.Count < 65536)
            {
                using (MemoryStream ms = ExportDTI(dtSource))
                {
                    using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                }
            }
            else
            {
                if (temp[temp.Length - 1] == "xls")
                    strFileName = strFileName + "x";

                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    ExportDTI(dtSource);

                }

            }
        }

        public static bool isNumeric(String message, out double result)
        {
            Regex rex = new Regex(@"^[-]?\d+[.]?\d*$");
            result = -1;
            if (rex.IsMatch(message))
            {
                result = double.Parse(message);
                return true;
            }
            else
                return false;

        }
    }
}