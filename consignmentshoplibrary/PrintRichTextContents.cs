using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;


namespace ConsignmentShopLibrary
{
    public class PrintRichTextContents
    {

        // variable to trace text to print for pagination
        private int m_nFirstCharOnPage;
        // Anzahl der Druckseiten 
        private int anzahlSeiten = 1;
        // aktuelle Seitenzahl 
        private int seitenNummer = 1;

        public RichTextBoxEx MyRichTextBoxEx { get; set; }
        public PrintDialog MyPrintDialog { get; set; }
        public bool PageNumberEnabled { get; set; }

        public void PrintRTContents()
        {
            try
            {
                PrintDocument printDoc = new PrintDocument();
                printDoc.BeginPrint += new PrintEventHandler(PrintDoc_BeginPrint);
                printDoc.PrintPage += new PrintPageEventHandler(PrintDoc_PrintPage);
                printDoc.EndPrint += new PrintEventHandler(PrintDoc_EndPrint);
                // Create a new instance of Margins with 1-inch margins.
                Margins margins = new Margins(43, 50, 45, 55);
                printDoc.DefaultPageSettings.Margins = margins;
                // Start printing process
                printDoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Ausdruck der Rechnung  { ex}");
            }
        }

        private void PrintDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            // Start at the beginning of the text
            m_nFirstCharOnPage = 0;
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // To print the boundaries of the current page margins
            // uncomment the next line:
            // e.Graphics.DrawRectangle(System.Drawing.Pens.Blue, e.MarginBounds);
            Font myFootNoteFont = new Font("Arial", 9f, FontStyle.Bold);
            // make the RichTextBoxEx calculate and render as much text as will
            // fit on the page and remember the last character printed for the
            // beginning of the next page
            StringFormat stringFormat = new StringFormat();
            RectangleF rectFPapier, rectFText;

            // Ermitteln des Rectangles, das den gesamten Druckbereich 
            // beschreibt (inklusive Kopf- und Fußzeile) 
            rectFPapier = e.MarginBounds;

            // Ermitteln des Rectangles, das den Bereich für den 
            // Text beschreibt (ausschließlich Kopf- und Fußzeile) 
            rectFText = RectangleF.Inflate(rectFPapier, 0,
                                -2 * MyRichTextBoxEx.Font.GetHeight(e.Graphics));

            m_nFirstCharOnPage = MyRichTextBoxEx.FormatRange(false,
                                                    e,
                                                    m_nFirstCharOnPage,
                                                    MyRichTextBoxEx.TextLength);

            // check if there are more pages to print
            if (m_nFirstCharOnPage < MyRichTextBoxEx.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;

            if (PageNumberEnabled)
            {

                // StringFormat restaurieren 
                stringFormat = new StringFormat()
                {
                    // Dateiname in der Kopfzeile anzeigen 
                    Alignment = StringAlignment.Far
                };

                // Seitennummer in der Fußzeile anzeigen 
                stringFormat.LineAlignment = StringAlignment.Far;

                e.Graphics.DrawString("Seite " + seitenNummer + " von [" + anzahlSeiten + "]", myFootNoteFont,
                                     Brushes.Black, rectFPapier, stringFormat);
            }

            // ermitteln, ob weitere Seiten zu drucken sind 
            seitenNummer++;
            if (!e.HasMorePages)
            {
                seitenNummer = 1;
                anzahlSeiten = MyPrintDialog.PrinterSettings.MaximumPage + 1;
            }
        }

        private void PrintDoc_EndPrint(object sender, PrintEventArgs e)
        {
            // Clean up cached information
            MyRichTextBoxEx.FormatRangeDone();
        }
    }
}
