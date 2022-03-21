using System.Windows.Forms;
using System.Text;

namespace password_gen
    //TODO: doubble klicking a line should select all the text
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGen_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            buttonPrint.Enabled = false;
            int items = Convert.ToInt32(numericUpDownItems.Value);
            string result = "";
            for (int i = 0; i < items; i++)
            {
                result += string.Format("{0}\r\n", GeneratePassword());
                progressBar1.Maximum = items;
                progressBar1.Value++;
                Task.Delay(1);
            }
            textBoxGen.Text = result;
            buttonPrint.Enabled = true;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text File|*.txt";
            saveFileDialog1.Title = "Save a text File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                fs.Close();
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    for (int i = 1; i < textBoxGen.Lines.Length; i++)
                    {
                        int j = i;
                        sw.WriteLine(String.Format("{0}: {1}", i, textBoxGen.Lines[j - 1]));
                    }
                }
                
            }
            buttonPrint.Enabled = false;
        }

        private string GeneratePassword()
        {
            string result = "";
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string charWithNum = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string advnaced = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ~!@#$%^&*()_+{}:\"<>?|/*-,.;'[]=\\`";
            string charWithSymb = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ~!@#$%^&*()_+{}:\"<>?|/*-,.;'[]=\\`";
            Random random = new Random();
            if((checkBox2.Checked == true) && (checkBox1.Checked == true) && (checkBox3.Checked == true))
            {
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    result += advnaced[random.Next(advnaced.Length)];
                }
            }
            else if((checkBox2.Checked == true) && (checkBox1.Checked == true) && (checkBox3.Checked == false))
            {
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    result += charWithNum[random.Next(charWithNum.Length)];
                }
            }else if((checkBox2.Checked == true) && (checkBox1.Checked == false) && (checkBox3.Checked == false))
            {
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    result += characters[random.Next(characters.Length)];
                }
            }else if((checkBox2.Checked == true) && (checkBox1.Checked == false) && (checkBox3.Checked == true))
            {
                for(int i = 0; i < numericUpDown1.Value; i++)
                {
                    result += charWithSymb[random.Next(charWithSymb.Length)];
                }
            }
            return result;
        }
    }
}