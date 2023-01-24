using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace KeyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly IDataProtector _dataProtector;
        public SecurityController(IDataProtectionProvider dataprovider) 
        {
            this._dataProtector = dataprovider.CreateProtector("This is my secret key for encryption and decryption");
        }

        [HttpGet]
        public IActionResult Index()
        {
            string plainText = "This is my information";
            string encryptText = this._dataProtector.Protect(plainText);
            string descryptText = this._dataProtector.Unprotect(encryptText);
            
            return Ok(new { plainText, encryptText, descryptText });
        }

        
    }
}
