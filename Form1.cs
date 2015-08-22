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
using System.Collections.Generic;
using System.Linq;

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
            control = false;
            control2 = false;
            button2.Text = "Sortuj po ilości plusów";
            button3.Text = "Sortuj rosnąco";
            button2.Visible = false;
            button3.Visible = false;
            debugBoxasdf.Text = "";
            text = "";
            atencjadzis = 0;
            atencjatydzien = 0;
            wpisydzis = 0;
            wpisytydzien = 0;
            waitLabel.Text = "Poczekaj chwilkę...";
            backgroundWorker1.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker1.RunWorkerAsync();
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
        int[] vote_count_array = new int[0];
        DateTime[] date_array = new DateTime[0];
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                
                int loopamount = 2;
                List<int> vote_count_list = new List<int>();
                List<DateTime> date_list = new List<DateTime>();

                for (int i = 1; i < loopamount; i++)
                {
                    locationsRequest = CreateRequest("profile", "entries", nickBox.Text, i);
                    locationsResponse = MakeRequest(locationsRequest);

                    xDoc = XDocument.Load(new XmlNodeReader(locationsResponse));
                    xDoc.Descendants("embed").Descendants("type").Remove();
                    xDoc.Descendants("comments").Remove();
                    xDoc.Descendants("voters").Remove();

                    locationsResponse.Load(xDoc.CreateReader());

                    vote_count = locationsResponse.GetElementsByTagName("vote_count");
                    date = locationsResponse.GetElementsByTagName("date");

                    for (int j = 0; j < vote_count.Count; j++)
                    {
                        vote_count_list.Add(Int32.Parse(vote_count[j].InnerText));
                        date_list.Add(DateTime.Parse(date[j].InnerText));
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

                    if (DateTime.Compare(DateTime.Parse(date[vote_count.Count - 1].InnerText), DateTime.Now.Date.AddDays(-7)) > 0)
                    {
                        loopamount++;
                    }
                }
                vote_count_array = vote_count_list.ToArray();
                date_array = date_list.ToArray();
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
                button2.Visible = true;
                button3.Visible = true;
            }));
        }

        public void print()
        {
            text = "";
            debugBoxasdf.Text="";
            for (int j = 0; j < vote_count_array.Count(); j++)
            {
                text += "Ilość plusów: " + vote_count_array[j].ToString();
                if (date_array[j] > DateTime.Today)
                {
                    text += ", wrzucono dzisiaj o " + date_array[j].ToString("hh:mm:ss") + "\n";
                }
                else
                {
                    text += ", wrzucono: " + (date_array[j]).ToString() + "\n";
                }
            }
            debugBoxasdf.Text = text;
            atencjaDzisTextBox.Text = atencjadzis.ToString();
            atencja7dniTextBox.Text = atencjatydzien.ToString();
            inWpisyToday.Text = "w " + wpisydzis + " wpisach";
            inWpisy7Days.Text = "w " + wpisytydzien + " wpisach";
            waitLabel.Text = "";
        }
        bool control = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (control == false)
            {
                control = true;
                Array.Sort(vote_count_array, date_array);
                button2.Text = "Sortuj chronologicznie";
            }
            else
            {
                control = false;
                Array.Sort(date_array, vote_count_array);
                button2.Text = "Sortuj po ilości plusów";
            }
            control2 = true;
            button3.Text = "Sortuj malejąco";
            print();
        }
        bool control2 = false;
        private void button3_Click(object sender, EventArgs e)
        {
            if (control2 == false)
            {
                control2 = true;
                button3.Text = "Sortuj malejąco";
            }
            else
            {
                control2 = false;
                button3.Text = "Sortuj rosnąco";
            }
            Array.Reverse(vote_count_array);
            Array.Reverse(date_array);
            print();
        }
    }
}
