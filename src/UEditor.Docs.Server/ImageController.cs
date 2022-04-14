using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace UEditor.Docs.Server {
    [Route("api"), ApiController]
    public class ImageController : ApiController {
        [HttpPost("upload")]
        public async Task<JsonResult> PostUrl() {
            var result = new UEditorResult();
            if (Request.Content.IsMimeMultipartContent()) {
                var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "image_path");
                var provider = new MultipartFormDataStreamProvider(root);
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (var file in provider.FileData) {
                    var rawFile = file.Headers.ContentDisposition.FileName.Trim('"');
                    var extension = Path.GetExtension(rawFile);
                    var info = new FileInfo(file.LocalFileName);
                    var filename = Path.Combine(info.DirectoryName, $"{Guid.NewGuid()}{extension}");
                    info.MoveTo(filename);
                    string path = Path.GetFileName(filename);
                    result.url = $"/I/{path}";
                    result.original =
                    result.title = Path.GetFileName(rawFile);
                    result.error = null;
                    result.state = "SUCCESS";
                }
            } else {
                result.state = "FAIL";
                result.error = "Only MultipartContent Supported.";
            }

            return Json(result);
        }

    }

    public class UEditorResult {
        public string state { get; set; }

        public IEnumerable<UEditorFileList> List { get; set; }

        public int? start { get; set; }

        public int? size { get; set; }

        public string source { get; set; }

        public int? total { get; set; }

        public string url { get; set; }

        public string title { get; set; }

        public string original { get; set; }

        public string error { get; set; }

        public int code { get; set; } = 200;
    }

    public class UEditorFileList {
        public string State { get; set; }

        public string Source { get; set; }

        public string Url { get; set; }
    }
}
