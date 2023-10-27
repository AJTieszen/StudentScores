using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentScores
{
    public partial class frmAddNewStudent : Form
    {
        public frmAddNewStudent()
        {
            InitializeComponent();
        }
        List<int> scoreList = new List<int>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidScore())
            {
                int score = Convert.ToInt32(txtScore.Text);
                scoreList.Add(score);
                DisplayScores();
                txtScore.Focus();
            }
        }

        private void DisplayScores()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int score in scoreList)
            {
                sb.Append($"{score} ");
            }
            lblScores.Text = sb.ToString();
        }
    }
}
