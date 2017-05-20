using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeBook_CSharp
{
    public partial class Form1 : Form
    {
        GeneralGradeBook gradeBook;
        Exam exam;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxId.ReadOnly = true;
            gradeBook = new GeneralGradeBook();
            exam = new Exam();
            exam.id = 1;
            gradeBook.examList.Add(exam);
            exam = new Exam();
            exam.id = gradeBook.examList.Count + 1;
            gradeBook.examList.Add(exam);
            exam = new Exam();
            exam.id = gradeBook.examList.Count + 1;
            gradeBook.examList.Add(exam);
            dataGridView1.DataSource = gradeBook.examList;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Rows[0].Selected = true;
            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[6].Width = 75;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[8].Width = 35;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            textBoxGroup.Clear();
            textBoxStudent.Clear();
            textBoxLecturer.Clear();
            textBoxPosition.Clear();
            textBoxSubject.Clear();
            textBoxCountHours.Clear();
            textBoxId.Clear();
            dateTimePickerDate.Value = DateTime.Today.Date;
            textBoxMark.Clear();
            buttonAdd.Enabled = true;
            buttonUpdate.Enabled = false;
            dataGridView1.DataSource = gradeBook.examList;
            dataGridView1.Refresh();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                exam = new Exam();
                exam.id = gradeBook.examList.Count + 1;
                exam.Group = textBoxGroup.Text;
                exam.StudentSurname = textBoxStudent.Text;
                exam.LecturerSurname = textBoxLecturer.Text;
                exam.Position = textBoxPosition.Text;
                exam.Subject = textBoxSubject.Text;
                exam.CountHours = Convert.ToInt32(textBoxCountHours.Text);
                exam.Date = Convert.ToDateTime(dateTimePickerDate.Text);
                exam.Mark = Convert.ToInt32(textBoxMark.Text);
                gradeBook.examList.Add(exam);
                buttonAdd.Enabled = false;
                buttonUpdate.Enabled = true;
                dataGridView1.DataSource = null;
                dataGridView1.Update();
                dataGridView1.Refresh();
                dataGridView1.DataSource = gradeBook.examList;
                dataGridView1.Update();
                dataGridView1.Refresh();
            }
            catch (Exception)
            {
                gradeBook.examList.Add(new Exam());
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int currentId = Convert.ToInt32(textBoxId.Text);
            //Лямбда-вираз для пошуку по екзамену тобто ми шукаємо в списку екзаменів id яке дорівнює тому id, що в нас на даний момент відображається на відповідному текстбоксі для id
            Exam tempExam = gradeBook.examList.Find(exam => exam.id == currentId); 
            //далі знаходимо індекс занйденого екзамену в нашому списку
            int examIndex = gradeBook.examList.IndexOf(tempExam);
            //і оновлєємо його дані
            gradeBook[examIndex].Group = textBoxGroup.Text;
            gradeBook[examIndex].StudentSurname = textBoxStudent.Text;
            gradeBook[examIndex].LecturerSurname = textBoxLecturer.Text;
            gradeBook[examIndex].Position = textBoxPosition.Text;
            gradeBook[examIndex].Subject = textBoxSubject.Text;
            gradeBook[examIndex].CountHours = Convert.ToInt32(textBoxCountHours.Text);
            gradeBook[examIndex].Date = Convert.ToDateTime(dateTimePickerDate.Text);
            gradeBook[examIndex].Mark = Convert.ToInt32(textBoxMark.Text); 
            dataGridView1.DataSource = gradeBook.examList;
            dataGridView1.Refresh();
        }

        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                if (row != null)
                {
                    textBoxId.Text = row.Cells[0].Value.ToString();
                    textBoxGroup.Text = row.Cells[1].Value.ToString();
                    textBoxStudent.Text = row.Cells[2].Value.ToString();
                    textBoxLecturer.Text = row.Cells[3].Value.ToString();
                    textBoxPosition.Text = row.Cells[4].Value.ToString();
                    textBoxSubject.Text = row.Cells[5].Value.ToString();
                    textBoxCountHours.Text = row.Cells[6].Value.ToString();
                    dateTimePickerDate.Text = row.Cells[7].Value.ToString();
                    textBoxMark.Text = row.Cells[8].Value.ToString();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int currentId = Convert.ToInt32(textBoxId.Text); 
            // той самий дямбжа-вираз щой для пошуку
            Exam tempExam = gradeBook.examList.Find(exam => exam.id == currentId); 
            //видалаяємо знайдений екзамен із нашого списку
            gradeBook.examList.Remove(tempExam);
            dataGridView1.DataSource = null;
            dataGridView1.Update();
            dataGridView1.Refresh();
            dataGridView1.DataSource = gradeBook.examList;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }
    }
}
