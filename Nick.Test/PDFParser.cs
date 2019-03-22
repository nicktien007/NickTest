using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace Nick.Test
{
    public class PDFParser
    {
        /// <summary>
        /// Extracts a text from a PDF file.
        /// </summary>
        /// <param name="filePath">the full path to the pdf file.</param>
        /// <returns>the extracted text</returns>
        public static string GetText(string filePath)
        {
            var sb = new StringBuilder();
            try
            {
                using (PdfReader reader = new PdfReader(filePath))
                {
                    string prevPage = "";
                    for (int page = 1; page <= reader.NumberOfPages; page++)
                    {
                        ITextExtractionStrategy its = new SimpleTextExtractionStrategy();
                        var s = PdfTextExtractor.GetTextFromPage(reader, page, its);
                        if (prevPage != s) sb.Append(s);
                        prevPage = s;
                    }
                    reader.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return sb.ToString();
        }
    }

}
