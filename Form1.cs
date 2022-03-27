using Emailer;
using InfoRetrieval;
namespace HostStats {
    public partial class Form1 : Form {
        private HostRetrieveInfo hostRetriever;
        public Form1() {
            InitializeComponent();
            this.hostRetriever = new HostRetrieveInfo();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            /* It it not succient to split the arugments by comma, we also have to remove any whitespace,
             since the whitespace included in the hostnames means we cannot resolve the hostname when making requests*/
            this.textBox1.Text = String.Concat(this.textBox1.Text.Where(c => !Char.IsWhiteSpace(c)));
            this.hostRetriever.retrieveAllAdressInfo(this.textBox1.Text.Split(',').ToList());
            Console.WriteLine(this.textBox1.Text.Split(',').ToList());
        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void textBox4_TextChanged(object sender, EventArgs e) {

        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e) {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

  
            
    }
}