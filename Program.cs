using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace KalkulatorGUI
{
    public class MainForm : Form
    {
        private Label outputLabel;
        private string input = "";

        public MainForm()
        {
            this.Text = "JMMODUL3_KALKULATOR";
            this.Size = new System.Drawing.Size(300, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            outputLabel = new Label();
            outputLabel.Text = "Kosong";
            outputLabel.TextAlign = ContentAlignment.MiddleCenter;
            outputLabel.Dock = DockStyle.Bottom;
            outputLabel.Height = 50;
            outputLabel.Font = new Font("Arial", 14, FontStyle.Bold);
            outputLabel.BackColor = Color.WhiteSmoke;
            this.Controls.Add(outputLabel);

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.RowCount = 4;
            panel.ColumnCount = 3;
            panel.Dock = DockStyle.Fill;
            panel.AutoSize = true;
            panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single; 
            this.Controls.Add(panel);

            string[,] buttons = {
                { "+", "=", "0" },
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button btn = new Button();
                    btn.Text = buttons[i, j];
                    btn.Font = new Font("Arial", 12, FontStyle.Bold);
                    btn.Size = new Size(60, 50);
                    btn.Click += Button_Click;
                    panel.Controls.Add(btn, j, i);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "=")
            {
                try
                {
                    outputLabel.Text = new DataTable().Compute(input, null).ToString();
                }
                catch
                {
                    outputLabel.Text = "Error";
                }
                input = "";
            }
            else
            {
                input += btn.Text;
                outputLabel.Text = input;
            }
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
