using Emailer;
using InfoRetrieval;
namespace HostStats {
    public partial class Form1 : Form {
        private HostRetrieveInfo hostRetriever;
        private EmailSender emailSender;
        private string emailProvider;
        public Form1() {
            InitializeComponent();
            this.hostRetriever = new HostRetrieveInfo();
            this.emailSender = new EmailSender();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) {

        }

        private void button2_Click(object sender, EventArgs e) {
            /* It it not succient to split the arugments by comma, we also have to remove any whitespace,
             since the whitespace included in the hostnames means we cannot resolve the hostname when making requests*/
            this.textBox1.Text = String.Concat(this.textBox1.Text.Where(c => !Char.IsWhiteSpace(c)));
            string fpath = this.hostRetriever.retrieveAllAdressInfo(this.textBox1.Text.Split(',').ToList());

            List<string> emailRecipients = String.Concat(this.textBox3.Text.Where(c => !Char.IsWhiteSpace(c))).Split(',').ToList();
            Console.WriteLine(this.textBox5.Text);
            this.emailSender.emailRecipients(emailRecipients, this.textBox5.Text,this.textBox6.Text,fpath,this.emailProvider);

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
            this.emailProvider = "smtp.outlook.com";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) {
            this.emailProvider = "smtp.gmail.com";
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void textBox3_TextChanged(object sender, EventArgs e) {

        }

        private void label7_Click(object sender, EventArgs e) {

        }

        private void textBox5_TextChanged(object sender, EventArgs e) {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            this.emailProvider = "smpt.yahoo.com";
        }

        private void textBox6_TextChanged(object sender, EventArgs e) {

        }
    }
}