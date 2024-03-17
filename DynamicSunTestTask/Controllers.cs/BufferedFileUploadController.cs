using Microsoft.AspNetCore.Mvc;
using ProCodeGuide.Samples.FileUpload.Interfaces;

namespace ProCodeGuide.Samples.FileUpload.Controllers
{
    public class BufferedFileUploadController : Controller
    {
        readonly IBufferedFileUploadService _bufferedFileUploadService;
        readonly ReadDocument _readDocument;

        public BufferedFileUploadController(IBufferedFileUploadService bufferedFileUploadService, ReadDocument readDocument)
        {
            _bufferedFileUploadService = bufferedFileUploadService;
            _readDocument = readDocument;
        }

        public IActionResult AddArhive() => View();

        [HttpPost]
        public async Task<ActionResult> AddArhive(IFormFile file)
        {
            try
            {
                if (await _bufferedFileUploadService.UploadFile(file))
                {
                    ViewBag.Message = "File Upload Successful";
                }
                else
                {
                    ViewBag.Message = "File Upload Failed";
                }
                _ = _readDocument.WriteExcelDocument(file.FileName);
            }
            catch (Exception)
            {
                ViewBag.Message = "File Upload Failed";
            }
            return View();
        }
    }
}