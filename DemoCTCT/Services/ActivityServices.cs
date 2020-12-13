using PuppeteerSharp;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DemoCTCT.Services
{
    public class ActivityServices : IActivityServices
    {
        public async Task GetActivity(string mssv)
        {
            //await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.GoToAsync("http://ctct.ueh.edu.vn/modules.php?name=xemdiemmacle", WaitUntilNavigation.DOMContentLoaded);
            await page.TypeAsync("input[id='madoi']", mssv);
            await page.Keyboard.PressAsync("Enter");
            await page.WaitForNavigationAsync();
            string res = await page.GetContentAsync();

            Debug.WriteLine(res);

            System.IO.File.WriteAllText(@"D:\demo.txt", res);

            await page.CloseAsync();
            await browser.CloseAsync();
        }
    }
}