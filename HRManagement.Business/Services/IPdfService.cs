using DinkToPdf;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRManagement.Business.Services
{
    public interface IPdfService
    {
        byte[] Convert(string htmlContent, PechkinPaperSize paperSize);
    }
}
