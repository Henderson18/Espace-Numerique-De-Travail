using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;

namespace ENAapp.Models.entity
{
    public class SendMessage
    {
        private string ClientID { get; set; } = "lwA15EH6d3O1xTIy3ihTtJGetzmIPRpn";
        private string SecretId { get; set; } = "lwA15EH6d3O1xTIy3ihTtJGetzmIPRpn";

        public  void Send(string number,string message)
        {
            String apiAccessKey = "a1234b56789";
            String url = "http://sms.alpha.orange-api.net/sms/sendSMS.xml?id=" + apiAccessKey
                + "&amp;from=38100&amp;to=" +number + "&amp;content=" + message;

            // Send GET request
            WebClient client = new WebClient();
            string result = client.DownloadString(url);
            Console.WriteLine("Result : " + result);

            // Parse the returned XML
            XmlDocument document = new XmlDocument();
            document.LoadXml(result);
            Console.WriteLine("Status code : " + document.GetElementsByTagName("status_code")[0].InnerText);
            Console.WriteLine("Status message : " + document.GetElementsByTagName("status_msg")[0].InnerText);
        }
    }
}
