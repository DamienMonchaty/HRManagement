using DinkToPdf;
using DinkToPdf.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Business.Services.Impl
{
    public class PdfService : IPdfService
    {
        private readonly IConverter _pdfConverter;

        public PdfService(IConverter converter)
        {
            _pdfConverter = converter;
        }

        public byte[] Convert(string htmlContent, PechkinPaperSize paperSize)
        {
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                        ColorMode = ColorMode.Color,
                        Orientation = Orientation.Portrait,
                        PaperSize = paperSize,
                    },
                Objects = {
                        new ObjectSettings() {
                            HtmlContent = htmlContent,
                            WebSettings = { DefaultEncoding = "utf-8" }
                        }
                    }
            };

            return _pdfConverter.Convert(doc);
        }
    }
}