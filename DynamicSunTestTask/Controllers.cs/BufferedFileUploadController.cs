﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index() => View();

        [HttpPost]
        public async Task<ActionResult> Index(IFormFile file)
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
            }
            catch (Exception exception)
            {
                ViewBag.Message = "File Upload Failed";
            }
            _readDocument.WriteExcelDocument(file.FileName);
            return View();
        }
    }
}