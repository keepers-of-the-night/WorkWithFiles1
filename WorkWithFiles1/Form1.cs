using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkWithFiles1
{
    public partial class Form1 : Form
    {
        string s, s2, s3, s1;
        bool b = false,  b2 = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            s= textBox1.Text;
            if (Directory.Exists(s))
            {
                string[] f = Directory.GetFileSystemEntries(s);
                int i = f.Length;
                for (int j = 0; j < i; j++)
                    treeView1.Nodes.Add(f[j]);
            }
            else
                MessageBox.Show(" Папка или файл не найдены! ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            s = textBox1.Text;
            s2 = textBox2.Text;
            if ((!Directory.Exists(s + "/" + s2)) && (!File.Exists(s + "/" + s2)))
            {
                Directory.CreateDirectory(s + "/" + s2);
                treeView1.Nodes.Clear();
                string[] f = Directory.GetFileSystemEntries(s);
                int i = f.Length;
                for (int j = 0; j < i; j++)
                    treeView1.Nodes.Add(f[j]);
            }
            else
                MessageBox.Show("Уже существует с таким название папка или файл!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (b)
            {
                s = textBox1.Text;
                Copy(s3, s);
                void Copy(string from, string to)
                {
                    Directory.CreateDirectory(to);
                    foreach (string s4 in Directory.GetFiles(from))
                    {
                        string s5 = to + "//" + Path.GetFileName(s4);
                        if(!File.Exists(s5))
                            File.Copy(s4, s5);
                    }
                    foreach (string s6 in Directory.GetDirectories(from))
                    {
                        if(!Directory.Exists(s6))
                            Copy(s6, to + "//" + Path.GetFileName(s6));
                    }
                }
                treeView1.Nodes.Clear();
                string[] f = Directory.GetFileSystemEntries(s);
                int i = f.Length;
                for (int j = 0; j < i; j++)
                    treeView1.Nodes.Add(f[j]);
            }
            else
                MessageBox.Show("Буфер обмена пуст!");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (b2)
            {
                s= textBox1.Text + "//" + Path.GetFileName(s1);
                if (!File.Exists(s))
                {
                    File.Copy(s1, s);
                    treeView1.Nodes.Clear();
                    s = textBox1.Text;
                    string[] f = Directory.GetFileSystemEntries(s);
                    int i = f.Length;
                    for (int j = 0; j < i; j++)
                        treeView1.Nodes.Add(f[j]);
                }
                else
                    MessageBox.Show("Файл с таким именем уже существует!");
            }
            else
                MessageBox.Show("Буфер обмена пуст!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            s = textBox1.Text;
            s2 = textBox2.Text;
            if ((!Directory.Exists(s + "/" + s2)) && (!File.Exists(s + "/" + s2)))
            {
                File.Create(s + "/" + s2);
                treeView1.Nodes.Clear();
                string[] f = Directory.GetFileSystemEntries(s);
                int i = f.Length;
                for (int j = 0; j < i; j++)
                    treeView1.Nodes.Add(f[j]);
            }
            else
                MessageBox.Show("Уже существует с таким название папка или файл!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            s1 = textBox1.Text;
            b2 = true;
            if (!File.Exists(s1))
            {
                b2 = false;
                s1 = "";
                MessageBox.Show("Файл с таким именем не найдена!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            b = true;
            s3 = textBox1.Text;
            if (!Directory.Exists(s3))
            {
                b = false;
                s3 = "";
                MessageBox.Show(" Папка с таким именем не найдена! ");
            }
                
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            s = textBox1.Text;
            s2 = textBox2.Text;
            if (Directory.Exists(s + "/" + s2))
            {
                Directory.Delete(s + "/" + s2, true);
                treeView1.Nodes.Clear();
                string[] f = Directory.GetFileSystemEntries(s);
                int i = f.Length;
                for (int j = 0; j < i; j++)
                    treeView1.Nodes.Add(f[j]);
            }
            else if(File.Exists(s + "/" + s2)){
                File.Delete(s + "/" + s2);
                treeView1.Nodes.Clear();
                string[] f = Directory.GetFileSystemEntries(s);
                int i = f.Length;
                for (int j = 0; j < i; j++)
                    treeView1.Nodes.Add(f[j]);
            }
            else
                MessageBox.Show("Не существует ни файла, ни папки с таким названием!");
        }
    }
}
