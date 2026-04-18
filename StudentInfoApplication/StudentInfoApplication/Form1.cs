using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Text;

namespace StudentInfoApplication
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;

            panel1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 25, 25));
            textBox1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox1.Width, textBox1.Height, 20, 20));
            textBox2.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox2.Width, textBox2.Height, 20, 20));
            textBox3.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox3.Width, textBox3.Height, 20, 20));
            listBox1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, listBox1.Width, listBox1.Height, 10, 10));
            listBox2.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, listBox2.Width, listBox2.Height, 10, 10));
            listBox3.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, listBox3.Width, listBox3.Height, 10, 10));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentNamespace.StudentInfo student = new StudentNamespace.StudentInfo(textBox1.Text, textBox3.Text, textBox2.Text);

            listBox2.Items.Add(student.StudentID); 
            listBox1.Items.Add(student.FirstName); 
            listBox3.Items.Add(student.LastName);  

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            panel1.Focus();
        }
    }
}

namespace StudentNamespace
{
    public class StudentInfo
    {
        private string studentId;
        private string firstName;
        private string lastName;

        public StudentInfo()
        {
            this.studentId = null;
            this.firstName = null;
            this.lastName = null;
        }

        public StudentInfo(string studentId, string firstName, string lastName)
        {
            this.studentId = studentId;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string StudentID
        {
            get 
            { 
                return this.studentId; 
            }
            set 
            { 
                this.studentId = value; 
            }
        }

        public string FirstName
        {
            get { 
                return this.firstName; 
                }
            set 
            { 
                this.firstName = value; 
            }
        }

        public string LastName
        {
            get 
            { 
                return this.lastName; 
            }
            set 
            { 
                this.lastName = value; 
            }
        }
    }
}