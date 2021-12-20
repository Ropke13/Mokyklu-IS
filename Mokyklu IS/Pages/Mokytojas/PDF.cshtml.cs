using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Mokyklu_IS.Model;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Syncfusion.Pdf.Grid;

namespace Mokyklu_IS.Pages.Mokytojas
{
    public class mokiniuSarasasModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public mokiniuSarasasModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                return RedirectToPage("/Login");
            }
            else if (HttpContext.Session.GetString("role") != "Mokytojas")
            {
                return RedirectToPage("/Login");
            }

            return Page();
        }

        class Mok
        {
            public string Vardas { get; set; }
            public string Pavarde { get; set; }
            public string Klase { get; set; }
        }

        public async Task<IActionResult> OnPostSubmit()
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfGrid pdfGrid = new PdfGrid();
            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);

            string UserID = HttpContext.Session.GetString("id");
            var Mokytojas = await _db.Mokytojas.FindAsync(UserID);
            var Destymai = await _db.Destymas.Where(m => m.fk_Mokytojas == UserID).ToListAsync();
            var Klases = await _db.Klase.ToListAsync();
            var Mokiniai = await _db.Mokinys.ToListAsync();
            var MKlases = (from kl in Klases where Destymai.Any(d => d.fk_Klase.Equals(kl.Id_Klase) == true) select kl).ToList();
            var Ats = from m in Mokiniai
                      join k in MKlases on m.fk_Klase equals k.Id_Klase
                      select new Mok
                      {
                          Vardas = m.Vardas,
                          Pavarde = m.Pavarde,
                          Klase = k.Pavadinimas
                      };
            StringBuilder build = new StringBuilder();
            string Header = "Mokytojo " + Mokytojas.Vardas + " " + Mokytojas.Pavarde + " mokiniai:\n";
            build.Append(Header);

            pdfGrid.DataSource = Ats;

            graphics.DrawString(build.ToString(), font, PdfBrushes.Black, new PointF(0, 0));
            PdfGridRowStyle rowStyle = new PdfGridRowStyle();
            PdfGridRow header = pdfGrid.Headers[0];
            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            headerStyle.TextBrush = PdfBrushes.White;
            headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12f, PdfFontStyle.Regular);
            for (int i = 0; i < header.Cells.Count; i++)
            {
                header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            }
            header.ApplyStyle(headerStyle);
            rowStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12f);
            for (int i = 0; i < Ats.Count(); i++)
            {
                pdfGrid.Rows[i].Style = rowStyle;
            }
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 17));
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");
            fileStreamResult.FileDownloadName = "Mokiniai.pdf";

            return fileStreamResult;
        }
    }
}
