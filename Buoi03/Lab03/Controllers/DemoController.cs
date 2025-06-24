using Lab03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab03.Controllers
{
    public class DemoController : Controller
    {
        public async Task<IActionResult> AsyncDemo()
        {
            var sw = new Stopwatch();
            sw.Start();
            var a = MyDemo.FuncAAsync();
            var b = MyDemo.FuncBAsync();
            var c = MyDemo.FuncCAsync();
            await a; await b; await c;
            sw.Stop();
            return Content($"Chạy hết {sw.ElapsedMilliseconds} ms");
        }

        public IActionResult SyncDemo()
        {
            var sw = new Stopwatch();
            sw.Start();
            MyDemo.FuncA();
            MyDemo.FuncB();
            MyDemo.FuncC();
            sw.Stop();
            return Content($"Chạy hết {sw.ElapsedMilliseconds} ms");
        }
    }
}
