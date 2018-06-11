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
using FilterContent.ExtractClass;
using FilterContent.Support;
using Website_Filtering.Support;

namespace Website_Filtering
{
    public partial class frmQuetFileLog : DevExpress.XtraEditors.XtraForm
    {
        public frmQuetFileLog()
        {
            InitializeComponent();
            ResizeColumn(listviewURL);
        }

        private void ResizeColumn(ListView lv)
        {
            int x = lv.Width / 9 == 0 ? 1 : lv.Width / 9;
            lv.Columns[0].Width = x;
            lv.Columns[1].Width = x * 3;
            lv.Columns[2].Width = x * 3;
            lv.Columns[3].Width = x * 2;
        }

        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadingInForm loading = new LoadingInForm(splashScreenManager1);
            loading.ShowWaitForm();
            String path = txtPath.Text;
            String[] lines = System.IO.File.ReadAllLines(path);
            listviewURL.SmallImageList = imageList1;
            foreach(string URL in lines)
            {
                HistoryItem item = new HistoryItem();
                item.URL = URL;
                GetContentFromURL get = new GetContentFromURL(item);
                string content = get.ExtractContentFromUrl();
                ListViewItem lvi;
                if(content == "")
                {
                    lvi = new ListViewItem("", 1);
                }
                else
                {
                    lvi = new ListViewItem("", 0);
                }
                string mainContent = Scan(content);
                lvi.SubItems.Add(URL);
                lvi.SubItems.Add(content);
                lvi.SubItems.Add(mainContent);
                listviewURL.Items.Add(lvi);
            }
            loading.CloseWaitForm();
        }

        private string Scan(string content)
        {
            String mainContent = "";
            CheckListString check = new CheckListString(content);
            List<KeywordResult> list = check.CheckingContent();
            list.Sort(delegate(KeywordResult x, KeywordResult y)
                {
                    if (x.matchCount < y.matchCount) return 1;
                    else if (x.matchCount > y.matchCount) return -1;
                    else return x.Name.CompareTo(y.Name);
                });
            if(list.Count >= 1) mainContent = list[0].Name;
            if(list.Count > 1)
            {
                if ((double)list[1].matchCount / (double)list[0].matchCount > 0.7)
                    mainContent = mainContent + ", " + list[1].Name; 
            }
            return mainContent;
        }

        private void listviewURL_Resize(object sender, EventArgs e)
        {
            ResizeColumn(listviewURL);
        }

        private void listviewURL_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point pt = listviewURL.PointToScreen(e.Location);
                contextMenuStrip1.Show(pt);
            }
        }

        private void WebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listviewURL.SelectedItems.Count > 0)
            {
                ListViewItem item = listviewURL.SelectedItems[0];
                String Content = item.SubItems[2].Text.Replace("\n", "\r\n");
                frmChiTiet frm = new frmChiTiet(item.SubItems[1].Text, Content);
                frm.Show();
            }
            else
                MessageBox.Show("Lỗi khi xử lý yêu cầu", "Thong bao", MessageBoxButtons.OK);
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listviewURL.SelectedItems.Count > 0)
            {
                ListViewItem item = listviewURL.SelectedItems[0];
                frmDanhGiaURL frm = new frmDanhGiaURL(item.SubItems[1].Text);
                frm.Show();
                frm.PerformAction();
            }
            else
                MessageBox.Show("Lỗi khi xử lý yêu cầu", "Thong bao", MessageBoxButtons.OK);
        }
    }
}