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
            labelInfo.Text = $"{fullName}\n{loginID}\n{curriculumName}";
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
        private void LoadCourses()
        {
            flowLayoutPanelCourses.Controls.Clear(); // Önceki kontrolleri temizle

            // 1. Header Paneli oluştur
            Panel headerPanel = new Panel();
            headerPanel.Width = 350;
            headerPanel.Height = 30;
            headerPanel.BackColor = Color.LightGray;

            // Ekle başlığı
            Label headerAdd = new Label();
            headerAdd.Text = "Ekle";
            headerAdd.Width = 40;
            headerAdd.Location = new Point(5, 6);
            headerAdd.Font = new Font("Segoe UI", 8, FontStyle.Bold);

            // Ders Kodu başlığı
            Label headerCode = new Label();
            headerCode.Text = "Ders Kodu";
            headerCode.Width = 80;
            headerCode.Location = new Point(50, 6);
            headerCode.Font = new Font("Segoe UI", 8, FontStyle.Bold);

            // Ders Adı başlığı
            Label headerName = new Label();
            headerName.Text = "Ders Adı";
            headerName.Width = 200;
            headerName.Location = new Point(140, 6);
            headerName.Font = new Font("Segoe UI", 8, FontStyle.Bold);

            // Header ekle
            headerPanel.Controls.Add(headerAdd);
            headerPanel.Controls.Add(headerCode);
            headerPanel.Controls.Add(headerName);
            flowLayoutPanelCourses.Controls.Add(headerPanel);

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";
            string query = @"
SELECT CourseID, CourseName, CourseCode
FROM Courses
WHERE CurriculumID = @CurriculumID";

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
                    string courseCode = reader.GetString(2);

                    // Panel satırı
                    Panel coursePanel = new Panel();
                    coursePanel.Width = 350;
                    coursePanel.Height = 30;
                    coursePanel.Margin = new Padding(2);
                    coursePanel.BackColor = Color.Transparent;

                    // '+' butonu
                    Button addButton = new Button();
                    addButton.Text = "+";
                    addButton.Tag = courseID;
                    addButton.Width = 24;
                    addButton.Height = 24;
                    addButton.Location = new Point(5, 3); // Hafif içe kaydırılmış, ortalanmış
                    addButton.Click += CourseButton_Click;
                    addButton.Tag = new Tuple<int, string>(courseID, courseCode);

                    // Ders kodu etiketi
                    Label codeLabel = new Label();
                    codeLabel.Text = courseCode;
                    codeLabel.AutoSize = true;
                    codeLabel.Location = new Point(addButton.Right + 10, 6); // butonun sağına hizalanmış
                    codeLabel.Font = new Font("Segoe UI", 8, FontStyle.Regular);

                    // Ders adı etiketi
                    Label nameLabel = new Label();
                    nameLabel.Text = courseName;
                    nameLabel.AutoSize = true;
                    nameLabel.Location = new Point(codeLabel.Right + 20, 6); // koddan sonra boşluklu
                    nameLabel.Font = new Font("Segoe UI", 8, FontStyle.Regular);

                    // Ekle
                    coursePanel.Controls.Add(addButton);
                    coursePanel.Controls.Add(codeLabel);
                    coursePanel.Controls.Add(nameLabel);

                    flowLayoutPanelCourses.Controls.Add(coursePanel);
                }
            }
        }


        // Güncellenmiş CourseButton_Click metodu — artık SectionSelectionForm'a yeni formatta veri gönderiyor
        private void CourseButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            var tag = (Tuple<int, string>)clickedButton.Tag;
            int courseID = tag.Item1;
            string courseCode = tag.Item2;

            var sections = GetSectionsForCourse(courseID, courseCode);

            if (sections.Count == 0)
            {
                MessageBox.Show("Bu derse ait şube bulunamadı.");
                return;
            }

            SectionSelectionForm form = new SectionSelectionForm(sections);
            if (form.ShowDialog() == DialogResult.OK)
            {
                int selectedSectionID = form.SelectedSectionID;
                SaveCourseSelection(studentID, courseID, selectedSectionID);
                MessageBox.Show("Ders seçimi başarıyla kaydedildi.");
            }
        }


        private List<(string CourseCode, int SectionID, string InstructorName,int Quota, string Classroom, TimeSpan StartTime, TimeSpan EndTime, string Day)>
    GetSectionsForCourse(int courseID, string courseCode)
        {
            var sections = new List<(string, int, string, int, string, TimeSpan, TimeSpan, string)>();

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";
            string query = @"SELECT SectionID, InstructorName, Quota, Classroom, StartTime, EndTime, Day 
                     FROM CourseSections 
                     WHERE CourseID = @CourseID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CourseID", courseID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int sectionID = reader.GetInt32(0);
                    string instructor = reader.GetString(1);
                    int quota = reader.GetInt32(2);
                    string classroom = reader.GetString(3);
                    TimeSpan startTime = reader.GetTimeSpan(4);
                    TimeSpan endTime = reader.GetTimeSpan(5);
                    string day = reader.GetString(6);

                    sections.Add((courseCode, sectionID, instructor, quota, classroom, startTime, endTime, day));
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