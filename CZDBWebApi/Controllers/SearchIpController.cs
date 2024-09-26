using CZDBHelper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Sockets;

namespace CZDBWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchIpController : ControllerBase
    {
        private readonly DbIpv4Searcher dbIpv4;
        private readonly DbIpv6Searcher dbIpv6;

        public SearchIpController(DbIpv4Searcher dbIpv4Searcher, DbIpv6Searcher dbIpv6Searcher)
        {
            dbIpv4 = dbIpv4Searcher;
            dbIpv6 = dbIpv6Searcher;
        }

        [HttpGet()]
        public string Get([FromQuery] string? ip = null)
        {
            try
            {
                if (string.IsNullOrEmpty(ip)) return "";

                if (!IPAddress.TryParse(ip, out var addr)) return "";

                if (addr.AddressFamily == AddressFamily.InterNetwork) // IPv4
                {
                    return dbIpv4.search(ip);
                }
                else if (addr.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    return dbIpv6.search(ip);
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}