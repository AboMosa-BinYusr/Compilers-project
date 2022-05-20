using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
namespace compiler_project
{
    class Excel2D
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb;
        Worksheet ws;
        public Excel2D(string path, int sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }
        public string ReadCell(int row, int col)
        {
            row ++;
            col++;
            if (ws.Cells[row, col].Value2 != null)
            {
                return ws.Cells[row, col].Value2.ToString();
            }
            else
            {
                return "";
            }
        }
        public String[,] getArray()
        {
            Microsoft.Office.Interop.Excel.Range usedRange = ws.UsedRange;
            object[,] arrObjectValues = usedRange.Value2;
            int nRows = arrObjectValues.GetLength(0);
            int nColumns = arrObjectValues.GetLength(1);
            string[,] arrStringValues = new string[nRows, nColumns];

            //</ create 2D Array >
            //--< convert array object to string >--
            for (int iRow = 0; iRow < nRows; iRow++)

            {
                for (int iCol = 0; iCol < nColumns; iCol++)

                {
                    //< Convert object to string >

                    arrStringValues[iRow, iCol] = Convert.ToString(arrObjectValues[iRow + 1, iCol + 1]);
                    //</ Convert object to string >
                }
            }

            //--</ convert array object to string >--
            return arrStringValues;
            
        }
       

    }
}

