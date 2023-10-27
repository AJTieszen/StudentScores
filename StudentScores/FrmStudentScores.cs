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
    public partial class FrmStudentScores : Form
    {
        public FrmStudentScores()
        {
            InitializeComponent();
        }

        public List<string> studentScores = new List<string>();
        private void FrmStudentScores_Load(object sender, EventArgs e)
        {
            studentScores.Add("Bill Chipman|92|95|85");
            studentScores.Add("Andrew Tieszen|85|99|90");
            studentScores.Add("Edison Lin|80|80|80");

            LoadStudentListBox();
        }

        private void LoadStudentListBox(int selectedIndex = 0)
        {
            lstStudents.Items.Clear();

            foreach(string s in studentScores)
            {
                lstStudents.Items.Add(s);
            }

            if(lstStudents.Items.Count > 0)
            {
                lstStudents.SelectedIndex = selectedIndex;
            }
            else
            {
                clearLabels();
            }

            lstStudents.Focus();
        }
        private void clearLabels()
        {
            lblScoreCount.Text = string.Empty;
            lblAverage.Text = string.Empty;
            lblScoreTotal.Text = string.Empty;
        }
        private void lstStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstStudents.SelectedIndex != -1)
            {
                string student = studentScores[lstStudents.SelectedIndex].ToString();
                string[] scores = student.Split('|');

                int total = 0;
                for ( int i = 1; i < scores.Length; i++ )
                {
                    total += Convert.ToInt32(scores[i]);
                }
                int count = scores.Length - 1;

                int average = 0;
                if (count > 0)
                {
                    average = total / count;
                }

                lblScoreTotal.Text = total.ToString();
                lblScoreCount.Text = count.ToString();
                lblAverage.Text = average.ToString();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(studentScores.Count > 0)
            {
                studentScores.RemoveAt(lstStudents.SelectedIndex);
                LoadStudentListBox();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form addForm = new frmAddNewStudent();
            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                studentScores.Add(addForm.Tag?.ToString());
                int lastIndex = studentScores.Count - 1;
                LoadStudentListBox(lastIndex);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (studentScores.Count > 0)
            {
                int selectedIndex = lstStudents.SelectedIndex;
                string student = studentScores[selectedIndex].ToString();

                Form updateForm = new frmUpdateStudents();
                updateForm.Tag = student;

                DialogResult result = updateForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    studentScores.RemoveAt(selectedIndex);
                    studentScores.Insert(selectedIndex, updateForm.Tag?.ToString());

                    LoadStudentListBox(selectedIndex);
                }
            }
        }
    }
}
