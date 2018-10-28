using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotC.LanguageServer.Models;
using NotC.LexicalAnalysis;
using System.IO;

namespace NotC.LanguageServer.Controllers
{
    public class TextData {
            public string text;
    }

    public class TokenResponse {
        public string kind;
        public int position;
        public int length;

        public TokenResponse(string k, int p, int l) {
            kind = k;
            position = p;
            length = l;
        }
    }
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("api/parse")]
        public IActionResult Parse([FromBody] TextData data) {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(data.text);
            Console.ResetColor();
            var scanner = new Scanner(data.text);
            var tokens = scanner.Scan();
            var res = new List<TokenResponse>();
            foreach (var token in tokens) {
                res.Add(new TokenResponse(token.Kind.ToString(), token.Position, token.Length));
            }
            JsonResult result = new JsonResult(res);
            return result;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
