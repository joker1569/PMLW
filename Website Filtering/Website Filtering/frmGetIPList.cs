using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;
using DevExpress.XtraEditors.Controls;

namespace Website_Filtering
{
    public partial class frmGetIPList : DevExpress.XtraEditors.XtraForm
    {
        public frmGetIPList()
        {
            InitializeComponent();
        }

        private void btnGetIP_Click(object sender, EventArgs e)
        {
            String URL = txtURL.Text;
            URL = URL.Replace("http://", "");
            URL = URL.Replace("https://", "");
            URL = URL.Substring(0, URL.IndexOf("/"));
            IPHostEntry hostname = Dns.GetHostEntry(URL);
            IPAddress[] ip = hostname.AddressList;
            foreach(IPAddress i in ip)
            {
                Console.WriteLine(i.ToString());
            }
            MessageBox.Show("OK", "OK", MessageBoxButtons.OK);
        }
    }
}