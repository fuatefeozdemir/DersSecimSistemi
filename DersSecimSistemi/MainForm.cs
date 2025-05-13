using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DersSecimSistemi
{
    public partial class MainForm : Form
    {
        private int studentID;
        private string loginID;
        private string fullName;
        private int departmentID;
        private int classYear;
        private string curriculumName;

        public MainForm(int studentID, string loginID, string fullName, int departmentID, int classYear)
        {
            InitializeComponent();
            this.studentID = studentID;
            this.loginID = loginID;
            this.fullName = fullName;
            this.departmentID = departmentID;
            this.classYear = classYear;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;
            labelStudentInfo.Text = $"{loginID} - {fullName}";
            GetCurriculum();
            CheckCourseSelectionStatus();
            labelInfo.Text = $"{fullName}\n{loginID}\n{GetDepartmentName(departmentID)}/{classYear}\n{curriculumName}";
        }

        private void GetCurriculum()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";
            string query = @"
            SELECT c.CurriculumName
            FROM [dbo].[Curricula] c
            JOIN [dbo].[Departments] d ON c.DepartmentID = d.DepartmentID
            WHERE c.DepartmentID = @DepartmentID AND c.ClassYear = @ClassYear";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DepartmentID", departmentID);
                    command.Parameters.AddWithValue("@ClassYear", classYear);

                    var curriculumNameFirst = command.ExecuteScalar();
                    curriculumName = curriculumNameFirst.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Müfredat bilgisi alınırken hata oluştu: " + ex.Message);
                }
            }
        }

        private void CheckCourseSelectionStatus()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";

            int curriculumCourseCount = 0;

            // 1. Müfredata göre toplam ders sayısını al
            string curriculumQuery = @"
        SELECT COUNT(*) 
        FROM Courses 
        WHERE CurriculumID = (
            SELECT CurriculumID 
            FROM Curricula 
            WHERE DepartmentID = @DepartmentID AND ClassYear = @ClassYear
        )";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(curriculumQuery, connection);
                    command.Parameters.AddWithValue("@DepartmentID", departmentID);
                    command.Parameters.AddWithValue("@ClassYear", classYear);

                    curriculumCourseCount = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Müfredat ders sayısı alınırken hata oluştu: " + ex.Message);
                    return;
                }
            }

            // 2. Öğrencinin seçtiği ders sayısını al
            int selectionCount = 0;
            string selectionQuery = "SELECT COUNT(*) FROM StudentCourseSelections WHERE StudentID = @StudentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(selectionQuery, connection);
                    command.Parameters.AddWithValue("@StudentID", studentID);

                    selectionCount = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ders seçimi kontrolü yapılırken hata oluştu: " + ex.Message);
                    return;
                }
            }

            // 3. Karar ver
            if (curriculumCourseCount == 0)
            {
                labelWarning.Text = "Müfredatın boş gözüküyor.";
                panelWarning.BackColor = Color.Gray;
            }
            else if (selectionCount == curriculumCourseCount)
            {
                labelWarning.Text = "Ders kayıtları tamamlandı.";
                panelWarning.BackColor = Color.Green;
            }
            else if (selectionCount < curriculumCourseCount)
            {
                int difference = curriculumCourseCount - selectionCount;
                labelWarning.Text = $"Seçilmesi gereken {difference} dersiniz bulunmaktadır.";
                panelWarning.BackColor = Color.Red;
            }
            else
            {
                labelWarning.Text = "Fazla dersiniz bulunmaktadır.";
                panelWarning.BackColor = Color.Red;
            }
        }

        private void btnGoToCourseSelection_Click(object sender, EventArgs e)
        {
            // Ders kayıt sayfasına geçiş
            tabControl.SelectedIndex = 1; // İkinci sekme (Ders Kayıt Sayfası)
        }

        private void btnGoToHome_Click(object sender, EventArgs e)
        {
            // Ana sayfaya geçiş
            tabControl.SelectedIndex = 0; // İlk sekme (Ana Sayfa)
        }

        private string GetDepartmentName(int departmentID)
        {
            string departmentName = string.Empty;
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";

            string query = "SELECT DepartmentName FROM Departments WHERE DepartmentID = @DepartmentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DepartmentID", departmentID); // Parametreyi ekliyoruz

                    // Sonuç dönerse
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        departmentName = result.ToString(); // Department adı burada alınır
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

            return departmentName;
        }
    }
}