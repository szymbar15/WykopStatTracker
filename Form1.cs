using System;
using System.Xml;
using System.Xml.XPath;
using System.Net;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;

namespace WykopStatTracker
{
    public partial class Form1 : Form
    {
        static string WykopAPIKey = "uwxrtN984S";
        static string WykopSecretKey = "yf4pWJibuG";
        int atencjadzis = 0;
        int atencjatydzien = 0;
        DateTime last;
        int i = 1;
        int wpisydzis = 0;
        int wpisytydzien = 0;
        string text = "";

        public void Welcome(string nick)
        {
            
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
            //backgroundWorker1.RunWorkerCompleted += CrossThreadSafe;
            debugBoxasdf.Text = "";
            atencjadzis = 0;
            atencjatydzien = 0;
            i = 1;
            wpisydzis = 0;
            wpisytydzien = 0;
            text = "";
            waitLabel.Text = "Poczekaj chwilkę...";
            backgroundWorker1.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker1.RunWorkerAsync();
            
            
        }

        public void print()
        {
            debugBoxasdf.Text = text;
                        atencjaDzisTextBox.Text = atencjadzis.ToString();
                        atencja7dniTextBox.Text = atencjatydzien.ToString();
                        inWpisyToday.Text = "w " + wpisydzis + " wpisach";
                        inWpisy7Days.Text = "w " + wpisytydzien + " wpisach";
                        waitLabel.Text = "";
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
        XmlDocument locationsResponse;
        XDocument xDoc;
        XmlNodeList vote_count;
        XmlNodeList type;
        XmlNodeList date;
        string locationsRequest;
        int compare;
        DateTime now;
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                
                //Create the REST Services 'Find by Query' request
                    //do
                    //{
                int loopamount = 2;
                for (int i = 1; i < loopamount; i++)
                {
                    locationsRequest = CreateRequest("profile", "entries", nickBox.Text, i);
                    Console.Write(locationsRequest);
                    //debugBoxasdf.AppendText(hash);
                    //Console.Write(md5);
                    locationsResponse = MakeRequest(locationsRequest);
                    xDoc = XDocument.Load(new XmlNodeReader(locationsResponse));
                    //XElement root = xDoc.Element("embed");
                    xDoc.Descendants("embed").Descendants("type").Remove();
                    xDoc.Descendants("comments").Remove();
                    xDoc.Descendants("voters").Remove();
                    //debugBoxasdf.Text = "";
                    locationsResponse.Load(xDoc.CreateReader());
                    vote_count = locationsResponse.GetElementsByTagName("vote_count");
                    type = locationsResponse.GetElementsByTagName("type");
                    date = locationsResponse.GetElementsByTagName("date");

                    //debugBoxasdf.Text = "";
                    //debugBoxasdf.Text = locationsResponse.OuterXml;

                    for (int j = 0; j < vote_count.Count; j++)
                    {
                        if (type[j].InnerText == "entry")
                        {
                            text += "Ilość plusów: " + vote_count[j].InnerText + ", wrzucono: " + DateTime.Parse(date[j].InnerText).ToString() + "\n";
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
                        if (DateTime.Parse(date[j].InnerText) >= DateTime.Now.AddDays(-7))
                        {
                            atencjatydzien += Int32.Parse(vote_count[j].InnerText);
                            wpisytydzien += 1;
                        }
                    }
                    last = DateTime.Parse(date[vote_count.Count - 1].InnerText);
                    now = DateTime.Now.Date.AddDays(-7);
                    Console.WriteLine(" " + last + " " + now);

                    compare = DateTime.Compare(last, now);
                    Console.WriteLine(compare);
                    if (compare > 0)
                    {
                        loopamount++;
                    }
                }
                    //} while (last >= now);
                    
                    //print();*/
                //});
                //mytask.Start();


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
            
            catch (Exception f)
            {
                Console.WriteLine(f.Message);
                Console.Read();
            }
            
        }
        void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Invoke((MethodInvoker)(() => {
                print();
            }));
        }
    }
}
