using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using ItextSharpHelper;
using static iTextSharp.text.pdf.parser.ITextExtractionStrategy;

namespace DesktopS1_Helper
{
    public class GeneratePdf:ITextLetterBase
    {
        public void CreatePdf(StringBuilder header,StringBuilder table1,StringBuilder table2,StringBuilder table3)
        {
            string[] headers = header.ToString().Split(',');
            string[] informationStrings = table1.ToString().Split(',');
            string[] checkAmountStrings = table2.ToString().Split(',');
            string[] partStrings = table3.ToString().Split(',');

            GenerateLetterBase();

            l1.Add(NewBoldParagraph(header[0].ToString()));//标题

            Paragraph informationP = NewParagraph();//第一段落
            informationP.Add(ParaLine(headers[1]));
            l1.Add(informationP);

            PdfPTable informationTable = new PdfPTable(4);//第一段落表格
            for (int i = 0; i < informationStrings.Length; i++)
            {
                if (i % 2 == 0)
                    informationTable.AddCell(CellHeader(informationStrings[i]));
                else
                    informationTable.AddCell(CellData(informationStrings[i]));
            }
            l1.Add(informationTable);

            Paragraph checkAmountP = NewParagraph();//第二段落
            checkAmountP.Add(ParaLine(headers[2]));
            l1.Add(checkAmountP);

            PdfPTable checkAmountTable = new PdfPTable(4);//第二段落表格
            foreach (var checkAmountString in checkAmountStrings)
            {
                checkAmountTable.AddCell(CellData(checkAmountString));
            }
            l1.Add(checkAmountTable);

            Paragraph partP= NewParagraph();//第三段落
            partP.Add(ParaLine(headers[3]));
            l1.Add(partP);

            PdfPTable partTable = new PdfPTable(4);
            foreach (var partString in partStrings)
            {
                partTable.AddCell(CellData(partString));
            }
            l1.Add(partTable);

            Closing();
            l1.Close();
            DocumentBytes = PDFStream.GetBuffer();
        }
    }
}