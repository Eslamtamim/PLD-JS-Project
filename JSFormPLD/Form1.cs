using com.calitha.goldparser;
using System;
using System.Windows.Forms;
namespace JSFormPLD
{
    public partial class Form1 : Form
    {
        MyParser MyParser;
        public Form1()
        {

            InitializeComponent();
            MyParser = new MyParser("js.cgt", listBox1, listBox2);

        }


        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            MyParser.Parse(richTextBox3.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
