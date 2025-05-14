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
        private int curriculumID;

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
            LoadCourses();
            labelInfo.Text = $"{fullName}\n{loginID}\n{GetDepartmentName(departmentID)}/{classYear}\n{curriculumName}";
        }

        private void GetCurriculum()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";
            string query = @"
    SELECT CurriculumID, CurriculumName
    FROM Curricula 
    WHERE DepartmentID = @DepartmentID AND ClassYear = @ClassYear";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DepartmentID", departmentID);
                    command.Parameters.AddWithValue("@ClassYear", classYear);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        curriculumID = Convert.ToInt32(reader["CurriculumID"]);
                        curriculumName = reader["CurriculumName"].ToString();
                    }
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
                panelWarning.BackColor = ColorTranslator.FromHtml("#28A745");
            }
            else if (selectionCount < curriculumCourseCount)
            {
                int difference = curriculumCourseCount - selectionCount;
                labelWarning.Text = $"Seçilmesi gereken {difference} dersiniz bulunmaktadır.";
                panelWarning.BackColor = ColorTranslator.FromHtml("#F8D7DA");
                labelWarning.ForeColor = Color.Black;
            }
            else
            {
                labelWarning.Text = "Fazla dersiniz bulunmaktadır.";
                panelWarning.BackColor = ColorTranslator.FromHtml("#F8D7DA");
                labelWarning.ForeColor = Color.Black;
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
        private void LoadCourses()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";
            string query = @"
        SELECT CourseID, CourseName 
        FROM Courses
        WHERE CurriculumID = @CurriculumID"; // öğrencinin müfredatına göre

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CurriculumID", curriculumID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int courseID = reader.GetInt32(0);
                    string courseName = reader.GetString(1);

                    Button courseButton = new Button();
                    courseButton.Text = courseName;
                    courseButton.Tag = courseID; // butona courseID'yi sakla
                    courseButton.Width = 200;
                    courseButton.Height = 40;
                    courseButton.Margin = new Padding(5);
                    courseButton.Click += CourseButton_Click;

                    flowLayoutPanelCourses.Controls.Add(courseButton);
                }
            }
        }
        private void CourseButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            int courseID = (int)clickedButton.Tag;

            // Şubeleri çek ve seçtir

            List<(int sectionID, string name)> sections = GetSectionsForCourse(courseID);

            if (sections.Count == 0)
            {
                MessageBox.Show("Bu derse ait şube bulunamadı.");
                return;
            }

            // Basit seçim için ComboBox olan ufak bir form gösterebilirsin
            SectionSelectionForm form = new SectionSelectionForm(sections); // custom form
            if (form.ShowDialog() == DialogResult.OK)
            {
                int selectedSectionID = form.SelectedSectionID;
                SaveCourseSelection(studentID, courseID, selectedSectionID);
                MessageBox.Show("Ders seçimi başarıyla kaydedildi.");
            }
        }
        private List<(int sectionID, string name)> GetSectionsForCourse(int courseID)
        {
            List<(int sectionID, string name)> sections = new List<(int sectionID, string name)>();

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";
            string query = "SELECT SectionID, InstructorName FROM CourseSections WHERE CourseID = @CourseID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseID", courseID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int sectionID = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    sections.Add((sectionID, name));
                }
            }

            return sections;
        }


        private void SaveCourseSelection(int studentID, int courseID, int sectionID)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";
            string query = @"
        INSERT INTO StudentCourseSelections (StudentID, CourseID, SectionID)
        VALUES (@StudentID, @CourseID, @SectionID)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentID", studentID);
                command.Parameters.AddWithValue("@CourseID", courseID);
                command.Parameters.AddWithValue("@SectionID", sectionID);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }



    }
}