using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareMD.FileHandler
{
    internal class ReportPDF
    {
        private Document document;
        public void CreateReport(string info, List<string> reportLines, List<string> prescLines,string fileName)
        {
            MemoryStream baos = new MemoryStream();
            PdfWriter writer = new PdfWriter(baos);
            PdfDocument pdfDocument = new PdfDocument(writer.SetSmartMode(true));

            string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

            document = new Document(pdfDocument, iText.Kernel.Geom.PageSize.LETTER);
            WriteDocument(info, reportLines, prescLines);
            document.Close();

            byte[] byte1 = baos.ToArray();
            using (FileStream fs = File.Create(projectPath+"\\Reports\\"+fileName)) { fs.Write(byte1, 0, (int)byte1.Length); }
        }

        private void WriteDocument(string info, List<string> reportLines, List<string> prescriptionLines)
        {

            document.Add(new Paragraph(info));
            document.Add(new Paragraph("\n"));
            
            document.Add(new Paragraph("\t\tIZVEŠTAJI"));
            document.Add(new Paragraph("-----------------------------------------------------------"));
            if (reportLines.Count==0) document.Add(new Paragraph("Nema izveštaja za dati period."));
            else
            {
                foreach (string reportLine in reportLines)
                {
                    document.Add(new Paragraph(reportLine));
                }
            }
            document.Add(new AreaBreak());
            document.Add(new Paragraph("\t\tRECEPTI"));
            document.Add(new Paragraph("-----------------------------------------------------------"));
            if (prescriptionLines.Count==0) document.Add(new Paragraph("Nema recepata za dati period."));
            else
            {
                foreach (string prescriptionLine in prescriptionLines)
                {
                    document.Add(new Paragraph(prescriptionLine));
                }
            }

        }
    }
}
