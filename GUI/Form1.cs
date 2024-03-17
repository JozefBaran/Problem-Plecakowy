using problem_plecakowy;
namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int przedmioty = int.Parse(textBox1.Text);
            int seed = int.Parse(textBox2.Text);
            int pojemnosc = int.Parse(textBox3.Text);

            ProblemPlecakowy problem = new ProblemPlecakowy(przedmioty, seed);

            var result = problem.Solve(pojemnosc);

            textBox5.Text = problem.ToString();
            textBox4.Text = result.ToString();
            textBox4.AppendText(Environment.NewLine);
            textBox5.AppendText(Environment.NewLine);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}