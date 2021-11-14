using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using System;

namespace WebApiServer.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        [HttpGet]
        public String Get()
        {

            var json = new WebClient().DownloadString(@"https://hs-resume-data.herokuapp.com/v3/candidates/all_data_b1f6-acde48001122");
            StringBuilder sb = new StringBuilder();
    

            var candidates = JArray.Parse(json);
            foreach (var candidate in candidates)
            {
                sb.Append("Hello " + candidate["contact_info"]["name"]["formatted_name"].ToString());
                sb.Append(Environment.NewLine);
                var experiences = candidate["experience"].ToArray();

                foreach (var experience in experiences)
                {
                    sb.Append("Worked as: " + experience["title"].ToString() + ", From " + experience["start_date"].ToString() + " To " + experience["end_date"].ToString());
                    sb.Append(Environment.NewLine);
                }
            }
             
            return sb.ToString();
        }

    }
   
}
