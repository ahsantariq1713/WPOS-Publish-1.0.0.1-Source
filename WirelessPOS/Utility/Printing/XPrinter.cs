
using BarcodeLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WirelessPOS
{
    public class XFString
    {

        public IEnumerable<string> StringLines { get; private set; }
        public XFString(int width, object obj)
        {
            List<string> strs = new List<string>();
            var value = Convert.ToString(obj);
            var lines = value.Length / width;
            var remains = value.Length % width;

            var i = 0;
            for (i = 0; i < lines; i++)
            {
                strs.Add(value.Substring(i * width, width).Trim());
            }

            if (remains > 0)
            {
                strs.Add(value.Substring(i * width, remains).Trim());
            }

            StringLines = strs;
        }
    }

    public class XStringFormatter
    {
        public IEnumerable<string> Strings { get; private set; }
        public XStringFormatter(string format, params XFString[] xSLFormats)
        {
            List<string> vs = new List<string>();
            var max = xSLFormats.Max(x => x.StringLines.Count());
            var sb = new StringBuilder();
            for (int i = 0; i < max; i++)
            {
                var objects = new List<object>();
                foreach (var str in xSLFormats)
                {
                    if (str.StringLines.Count() > 0 && str.StringLines.Count() <= i)
                    {
                        objects.Add((object)str.StringLines.ToList()[i]);
                    }
                    else
                    {
                        objects.Add("");
                    }
                }
                vs.Add(string.Format(format, objects));
            }
            Strings = vs as IEnumerable<string>;
        }
    }

    public class XPrinterString
    {
        public string String { get; set; }
        public XFont XFont { get; set; }
        public bool IsImage { get; set; }

        public XFontColor XFontColor { get; set; }

        public XPrinterString(string str, XFont xFont, XFontColor xFontColor = XFontColor.Black, bool isImage = false)
        {
            String = str;
            XFont = xFont;
            XFontColor = xFontColor;
            IsImage = isImage;
        }
    }

    public enum XFont
    {
        B12,
        R12,
        B9,
        R9,
        B8,
        R8,
        BC
    }

    public enum XFontColor
    {
        White,
        Black,
        Gray
    }

    public class XPrinter
    {
        public List<XPrinterString> Strings { get; private set; } = new List<XPrinterString>();

        private readonly PrintDocument printDocument;
        PrinterSettings printerSettings;
        private readonly PrintDialog printDialog;
        private readonly PrintPreviewDialog printPreview;

        private readonly PaperSize paperSize;
        private readonly bool autoSize;
        private readonly Font font12b;
        private readonly Font font12;
        private readonly Font font9b;
        private readonly Font font9;
        private readonly Font font8b;
        private readonly Font font8;

        private readonly Brush blackBrush = new SolidBrush(Color.Black);
        private readonly Brush whiteBrush = new SolidBrush(Color.White);
        private readonly Brush grayBrush = new SolidBrush(Color.FromArgb(90, 90, 90));

        private PaperSize autoPaperSize;

        public int LeftMargin { get; set; }
        public int TopMargin { get; set; }
        public int LineHeight { get; set; }

        public XPrinter(string printerName = null, PaperSize paperSize = null,
            string fontFamily = null, int lineHeight = 0,
            int leftMargin = 0, int topMargin = 0)
        {
            LeftMargin = topMargin;
            TopMargin = leftMargin;
            LineHeight = lineHeight;

            fontFamily = fontFamily ?? "Courier New";
            this.paperSize = paperSize;
            autoSize = paperSize == null ? true : false;

            font12b = new Font(fontFamily, 12, FontStyle.Bold);
            font12 = new Font(fontFamily, 12);
            font9b = new Font(fontFamily, 9, FontStyle.Bold);
            font9 = new Font(fontFamily, 9);
            font8b = new Font(fontFamily, 8, FontStyle.Bold);
            font8 = new Font(fontFamily, 8);

            printerSettings = new PrinterSettings();
            printerSettings.DefaultPageSettings.PaperSize = this.paperSize;
            printerSettings.PrinterName = printerName;
            printerSettings.PrintRange = PrintRange.AllPages;

            printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.PrinterSettings = printerSettings;

            printDialog = new PrintDialog { Document = printDocument, PrinterSettings = printerSettings };
            printPreview = new PrintPreviewDialog { Document = printDocument };

            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_Print);

        }


        public void Preview(Form owner)
        {
            new PrintPreview(printDocument).Show(owner);
        }

        public void AddVerticalSpace(Graphics g, int rows = 1)
        {
            for (int i = 0; i < rows; i++)
            {
                AddString(".     ", XFont.R8, XFontColor.White, g);
            }
        }

        public void AddString(string str, XFont xFont = XFont.R8, XFontColor xFontColor = XFontColor.Black, Graphics g = null, bool isImage = false)
        {
            Strings.Add(new XPrinterString(str, xFont, xFontColor, isImage));

            if (autoSize && g != null)
            {
                if (autoPaperSize == null) autoPaperSize = new PaperSize();
                var size = g.MeasureString(str, GetFont(xFont));
                if (size.Width > autoPaperSize.Width) { autoPaperSize.Width = (int)size.Width; }

                autoPaperSize.Height += (int)size.Height;

                var pSize = new PaperSize("Custom", autoPaperSize.Width + LeftMargin * 4, autoPaperSize.Height + TopMargin * 2);
                printDocument.DefaultPageSettings.PaperSize = pSize;

            }

        }

        public void Print(Form owner, bool showDialog = false, bool autoSize = true)
        {

            printDocument.Print();
        }
        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        void PrintDocument_Print(object sender, PrintPageEventArgs e)
        {
            if (Strings.Count <= 0) return;
            Graphics graphics = e.Graphics;

            int vOffset = TopMargin;

            Strings.ForEach(x =>
            {

                var size = graphics.MeasureString(x.String, GetFont(x.XFont));

                if (x.IsImage)
                {
                    Barcode b = new Barcode();

                    int W = Properties.Settings.Default.BCWidth;
                    int H = Properties.Settings.Default.BCHeight;
                    b.Alignment = AlignmentPositions.CENTER;

                    //barcode alignment
                    b.Alignment = AlignmentPositions.CENTER;
                  
                    b.IncludeLabel = true;

                    b.AlternateLabel = x.String.Trim();

                    b.LabelPosition = LabelPositions.BOTTOMCENTER;      //label alignment and position
                    b.LabelFont = new Font("Courier New", 9);
                    //===== Encoding performed here =====
                    var img = b.Encode(TYPE.UPCA, x.String.Trim(), Color.Black, Color.White, W, H);
                    //===================================
                    var width = printDocument.DefaultPageSettings.PaperSize.Width;
                    var margin = ((width - img.Width)/2);
                    graphics.DrawImage(img, new Point(margin, vOffset));
                }
                else
                {
                    graphics.DrawString(x.String, GetFont(x.XFont), GetBrush(x.XFontColor), LeftMargin, vOffset);

                }
                vOffset += LineHeight <= 0 ? (int)size.Height : LineHeight;
            });
        }


        private Brush GetBrush(XFontColor xFontColor)
        {
            switch (xFontColor)
            {
                case XFontColor.White:
                    return whiteBrush;
                case XFontColor.Black:
                    return blackBrush;
                case XFontColor.Gray:
                    return grayBrush;
                default:
                    return blackBrush;
            }
        }

        private Font GetFont(XFont xFont)
        {
            switch (xFont)
            {
                case XFont.B12:
                    return font12b;
                case XFont.R12:
                    return font12;
                case XFont.B9:
                    return font9b;
                case XFont.R9:
                    return font9;
                case XFont.B8:
                    return font8b;
                case XFont.R8:
                    return font8;
                default:
                    return font8;
            }
        }
    }
}
