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

        private void Welcome(string nick)
        {
            try
            {
                debugBoxasdf.Text = "";
                int atencjadzis = 0;
                int atencjatydzien = 0;
                DateTime last;
                int i = 1;
                int wpisydzis = 0;
                int wpisytydzien = 0;
                //Create the REST Services 'Find by Query' request
                do
                {
                    string locationsRequest = CreateRequest("profile", "entries", nick, i);
                    Console.Write(locationsRequest);
                    //debugBoxasdf.AppendText(hash);
                    //Console.Write(md5);
                    XmlDocument locationsResponse = MakeRequest(locationsRequest);
                    XDocument xDoc = XDocument.Load(new XmlNodeReader(locationsResponse));
                    //XElement root = xDoc.Element("embed");
                    xDoc.Descendants("embed").Descendants("type").Remove();
                    xDoc.Descendants("comments").Remove();
                    xDoc.Descendants("voters").Remove();
                    //debugBoxasdf.Text = "";
                    locationsResponse.Load(xDoc.CreateReader());
                    XmlNodeList vote_count = locationsResponse.GetElementsByTagName("vote_count");
                    XmlNodeList type = locationsResponse.GetElementsByTagName("type");
                    XmlNodeList date = locationsResponse.GetElementsByTagName("date");

                    //debugBoxasdf.Text = "";
                    //debugBoxasdf.Text = locationsResponse.OuterXml;

                    for (int j = 0; j < vote_count.Count; j++)
                    {
                        if (type[j].InnerText == "entry")
                        {
                            debugBoxasdf.Text += "Ilość plusów: " + vote_count[j].InnerText + ", wrzucono: " + DateTime.Parse(date[j].InnerText).ToString() + "\n";
                        }
                    }

                    for (int j = 0; j < vote_count.Count; j++)
                    {
                        if (DateTime.Parse(date[j].InnerText) >= DateTime.Today)
                        {
                            atencjadzis += Int32.Parse(vote_count[j].InnerText);
                            wpisydzis += 1;
                        }
                    }


                    for (int j = 0; j < vote_count.Count; j++)
                    {
                        if (DateTime.Parse(date[j].InnerText) >= DateTime.Today.AddDays(-6))
                        {
                            atencjatydzien += Int32.Parse(vote_count[j].InnerText);
                            wpisytydzien += 1;
                        }
                    }
                    i++;
                    last = DateTime.Parse(date[vote_count.Count-1].InnerText);

                } while (last > DateTime.Today.AddDays(-13));
                atencjaDzisTextBox.Text = atencjadzis.ToString();
                atencja7dniTextBox.Text = atencjatydzien.ToString();
                inWpisyToday.Text = "w " + wpisydzis + " wpisach";
                inWpisy7Days.Text = "w " + wpisytydzien + " wpisach";

                
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

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }
        }
        public static string hash;
        public string CreateRequest(string type, string method, string parameters, int page)
        {
            string UrlRequest = "http://a.wykop.pl/" +
                                 type + "/" + method + "/" + parameters +
                                 "/appkey," + WykopAPIKey + ",page," + page + ",format,xml";
            string asdf;
            asdf = WykopSecretKey + UrlRequest;
            //debugBoxasdf.Text = asdf;
            hash = GetMD5Hash(MD5.Create(), asdf);
            //debugBoxasdf.Text += hash;
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
            Welcome(nickBox.Text);
        }

        private void atencjaDzis_Click(object sender, EventArgs e)
        {

        }

        private void atencjaDzisTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
