using System;
using System.Xml;
using System.Xml.XPath;
using System.Net;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Linq;

namespace WykopStatTracker
{
    public partial class Form1 : Form
    {
        static string WykopAPIKey = "uwxrtN984S";
        static string WykopSecretKey = "yf4pWJibuG";

        private void Welcome()
        {
            try
            {

                //Create the REST Services 'Find by Query' request
                string locationsRequest = CreateRequest("profile", "entries", "joookub");
                Console.Write(locationsRequest);
                debugBoxasdf.AppendText(hash);
                //Console.Write(md5);
                XmlDocument locationsResponse = MakeRequest(locationsRequest);
                //XmlNode childNode = locationsResponse.SelectSingleNode("comments"); // apply your xpath here
                //childNode.ParentNode.RemoveChild(childNode);
                //ProcessResponse(locationsResponse);
                //XmlNode root = locationsResponse.DocumentElement;

                //Remove all attribute and child nodes.
                //root.RemoveAll();
                //XmlNode root = locationsResponse.DocumentElement;

                //Remove the title element.
                //root.RemoveChild(root.FirstChild);
                /*XmlNodeList nodes = locationsResponse.SelectNodes("//voters");
                for (int i = 0; i < nodes.Count; i++)
                {
                    locationsResponse.RemoveChild(nodes[i]);
                }*/
                /*XElement root = XElement.Load(locationsResponse);
                root.Descendants("embed").Descendants().Remove();*/
                /*XmlNodeList prices = locationsResponse.GetElementsByTagName("embed");
                foreach (XmlNode price in prices)
                {
                    prices.RemoveChild(prices.FirstChild);
                }*/
                XDocument xDoc = XDocument.Load(new XmlNodeReader(locationsResponse));
                //XElement root = xDoc.Element("embed");
                xDoc.Descendants("embed").Descendants("type").Remove();
                debugBoxasdf.Text = "";
                locationsResponse.Load(xDoc.CreateReader());
                XmlNodeList vote_count = locationsResponse.GetElementsByTagName("vote_count");
                XmlNodeList type = locationsResponse.GetElementsByTagName("type");
                //XmlNodeList daye = 

                    //debugBoxasdf.Text = "";
                    //debugBoxasdf.Text = locationsResponse.OuterXml;
                
                for (int i = 0; i < vote_count.Count; i++)
                {
                    if (type[i].InnerText == "entry")
                    {
                        debugBoxasdf.Text += "1 " + vote_count[i].InnerText + "\n";
                    }
                    else
                    {
                        debugBoxasdf.Text += "2 " + vote_count[i].InnerText + "\n";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }
        }
        public static string hash;
        public string CreateRequest(string type, string method, string parameters)
        {
            string UrlRequest = "http://a.wykop.pl/" +
                                 type + "/" + method + "/" + parameters +
                                 "/appkey," + WykopAPIKey + ",format,xml";
            string asdf;
            asdf = WykopSecretKey + UrlRequest;
            debugBoxasdf.Text = asdf;
            hash = GetMD5Hash(MD5.Create(), asdf);
            debugBoxasdf.Text += hash;
            return (UrlRequest);
            
        }
        public string GetMD5Hash (MD5 md5Hash, string asdf) {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(asdf);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
            
        }
        public static XmlDocument MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                request.Headers["apisign"] = hash;
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return (xmlDoc);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.Read();
                return null;
            }
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void debugBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Welcome();
        }
    }
}
