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

        private List<SelectedSection> selectedSections = new List<SelectedSection>();
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
            labelInfo.Text = $"{fullName}\n{loginID}\n{curriculumName}";
            GetCurriculum();
            CheckCourseSelectionStatus();
            LoadCourses();
            LoadSelectedSectionsFromDB();
            PopulateScheduleGridView();
        }

        // -------------------------------------------------- Ana Sayfa --------------------------------------------------

        //
        // Sol paneldeki sayfa değiştirme butonları
        //
        private void btnGoToHome_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0; // Ana Sayfa
        }
        private void btnGoToCourseSelection_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1; // Ders Kayıt
        }
        private void btnGoToSchedule_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2; // Ders Programı
        }

        //
        // Öğrencinin hangi müfredatta olduğunu bulan metot (Bilgisayar Mühendisliği 1. sınıf gibi)
        //
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

        //
        // Ana sayfada öğrencinin ders seçim durumunu gösteren metot
        //
        private void CheckCourseSelectionStatus()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";
            int curriculumCourseCount = 0;
            string curriculumQuery = @"
        SELECT COUNT(*) 
        FROM Courses 
        WHERE CurriculumID = (
            SELECT CurriculumID 
            FROM Curricula 
            WHERE DepartmentID = @DepartmentID AND ClassYear = @ClassYear
        )";

            // Öğrencinin müfredatındaki ders sayısını bul
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

            // Öğrencinin seçtiği ders sayısını bul
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

            // Sonuca göre uyarıyı göster
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

        //
        // Profil görseline tıklandığında görünmez olan label'i görünür yaparak çıkış yap butonunu gözükür hale getirir
        //
        private void pictureBoxProfile_Click(object sender, EventArgs e)
        {
            panelProfile.Visible = !panelProfile.Visible;
        }

        //
        // LoginForm'a dönmeyi sağlar
        //
        private void Logout()
        {
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        //
        // Çıkış Yap butonuna tıklandığında Logout metotunu çağırır
        //
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        // -------------------------------------------------- Ders Kayıt --------------------------------------------------
        
        //
        // Öğrencinin müfredatındaki derslerin listesini ve şube seçme butonunu getirir 
        //
        private void LoadCourses()
        {
            flowLayoutPanelCourses.Controls.Clear();

            // Başlık paneli
            Panel headerPanel = new Panel();
            headerPanel.Width = 350;
            headerPanel.Height = 30;
            headerPanel.BackColor = Color.LightGray;

            Font headerFont = new Font("Segoe UI", 8, FontStyle.Bold); // Başlık fontu

            // Ekle başlığı
            Label headerAdd = new Label();
            headerAdd.Text = "Ekle";
            headerAdd.Width = 40;
            headerAdd.Location = new Point(5, 6);
            headerAdd.Font = headerFont;

            // Ders Kodu başlığı
            Label headerCode = new Label();
            headerCode.Text = "Ders Kodu";
            headerCode.Width = 80;
            headerCode.Location = new Point(50, 6);
            headerCode.Font = headerFont;

            // Ders Adı başlığı
            Label headerName = new Label();
            headerName.Text = "Ders Adı";
            headerName.Width = 200;
            headerName.Location = new Point(140, 6);
            headerName.Font = headerFont;

            // Ekle
            headerPanel.Controls.Add(headerAdd);
            headerPanel.Controls.Add(headerCode);
            headerPanel.Controls.Add(headerName);
            flowLayoutPanelCourses.Controls.Add(headerPanel);

            Font itemFont = new Font("Segoe UI", 9, FontStyle.Regular); // Normal Font

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

                    // Panel
                    Panel coursePanel = new Panel();
                    coursePanel.Width = 350;
                    coursePanel.Height = 30;
                    coursePanel.Margin = new Padding(2);
                    coursePanel.BackColor = Color.WhiteSmoke;

                    // '+' butonu
                    Button addButton = new Button();
                    addButton.Text = "+";
                    addButton.Tag = new Tuple<int, string>(courseID, courseCode);
                    addButton.Width = 24;
                    addButton.Height = 24;
                    addButton.Location = new Point(5, 3);
                    addButton.Click += CourseButton_Click;

                    // Ders kodu
                    Label codeLabel = new Label();
                    codeLabel.Text = courseCode;
                    codeLabel.AutoSize = true;
                    codeLabel.Location = new Point(addButton.Right + 10, 6);
                    codeLabel.Font = itemFont;

                    // Ders adı
                    Label nameLabel = new Label();
                    nameLabel.Text = courseName;
                    nameLabel.AutoSize = true;
                    nameLabel.Location = new Point(codeLabel.Right + 20, 6);
                    nameLabel.Font = itemFont;

                    // Ekle
                    coursePanel.Controls.Add(addButton);
                    coursePanel.Controls.Add(codeLabel);
                    coursePanel.Controls.Add(nameLabel);

                    flowLayoutPanelCourses.Controls.Add(coursePanel);
                }
            }
        }

        //
        // Ders ekleme butonuna tıklandığında şubelerin seçilmesi için SectionSelectionForm'u ekrana getirir
        //
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

            SectionSelectionForm form = new SectionSelectionForm(sections, studentID, courseID);

            if (form.ShowDialog() == DialogResult.OK)
            {
                int selectedSectionID = form.SelectedSectionID;
                var selectedSectionInfo = sections.FirstOrDefault(s => s.Item2 == selectedSectionID);

                if (selectedSectionInfo != default)
                {
                    // Aynı dersten şube seçildi mi kontrol et
                    var existingSectionForCourse = selectedSections.FirstOrDefault(ss => ss.CourseCode == courseCode);

                    // Eğer aynı dersten şube seçildiyse sıfırla
                    if (existingSectionForCourse != null)
                    {
                        selectedSections.Remove(existingSectionForCourse);
                    }

                    selectedSections.Add(new SelectedSection
                    {
                        CourseCode = selectedSectionInfo.Item1,
                        CourseID = courseID,
                        SectionID = selectedSectionInfo.Item2,
                        InstructorName = selectedSectionInfo.Item3,
                        Day = selectedSectionInfo.Item8,
                        StartTime = selectedSectionInfo.Item6,
                        EndTime = selectedSectionInfo.Item7,
                        Classroom = selectedSectionInfo.Item5
                    });

                    RefreshSelectedSectionsPanel();
                }
                else
                {
                    MessageBox.Show("Seçilen şube bilgisi bulunamadı.");
                }
            }
        }

        //
        // Öğrencinin daha önceden seçtiği şubeler varsa onların seçili şubeler listesinde gözükmesini sağlar
        //
        private void LoadSelectedSectionsFromDB()
        {
            selectedSections.Clear();

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";
            string query = @"
    SELECT c.CourseID, c.CourseCode, s.SectionID, s.InstructorName, s.Day, s.StartTime, s.EndTime, s.Classroom
    FROM StudentCourseSelections scs
    INNER JOIN CourseSections s ON scs.SectionID = s.SectionID
    INNER JOIN Courses c ON s.CourseID = c.CourseID
    WHERE scs.StudentID = @StudentID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentID", studentID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    selectedSections.Add(new SelectedSection
                    {
                        CourseID = reader.GetInt32(0),
                        CourseCode = reader.GetString(1),
                        SectionID = reader.GetInt32(2),
                        InstructorName = reader.GetString(3),
                        Day = reader.GetString(4),
                        StartTime = reader.GetTimeSpan(5),
                        EndTime = reader.GetTimeSpan(6),
                        Classroom = reader.GetString(7)
                    });
                }
            }
            RefreshSelectedSectionsPanel();
        }

        private void RefreshSelectedSectionsPanel()
        {
            flowLayoutPanelSelectedSections.Controls.Clear();

            // --- Başlık Paneli ---
            Panel headerPanel = new Panel();
            headerPanel.Width = flowLayoutPanelSelectedSections.Width - 25;
            headerPanel.Height = 30;
            headerPanel.BackColor = Color.LightGray;
            headerPanel.Margin = new Padding(0, 0, 0, 5);

            Font headerFont = new Font("Segoe UI", 8, FontStyle.Bold); // Başlık Fontu

            // Sil Butonu
            Label headerDelete = new Label();
            headerDelete.Text = "Sil";
            headerDelete.Width = 40;
            headerDelete.Location = new Point(5, 7);
            headerDelete.Font = headerFont;
            headerDelete.TextAlign = ContentAlignment.MiddleCenter;
            headerPanel.Controls.Add(headerDelete);

            // Ders Kodu
            Label headerCourseCode = new Label();
            headerCourseCode.Text = "Ders Kodu";
            headerCourseCode.Width = 80;
            headerCourseCode.Location = new Point(headerDelete.Right + 10, 7);
            headerCourseCode.Font = headerFont;
            headerPanel.Controls.Add(headerCourseCode);

            // Öğretim Görevlisi
            Label headerInstructor = new Label();
            headerInstructor.Text = "Öğr. Görevlisi";
            headerInstructor.Width = 150;
            headerInstructor.Location = new Point(headerCourseCode.Right + 10, 7);
            headerInstructor.Font = headerFont;
            headerPanel.Controls.Add(headerInstructor);

            // Gün / Saat
            Label headerTime = new Label();
            headerTime.Text = "Gün / Saat";
            headerTime.Width = 120;
            headerTime.Location = new Point(headerInstructor.Right + 10, 7);
            headerTime.Font = headerFont;
            headerPanel.Controls.Add(headerTime);

            // Sınıf
            Label headerClassroom = new Label();
            headerClassroom.Text = "Sınıf";
            headerClassroom.Width = 80;
            headerClassroom.Location = new Point(headerTime.Right + 10, 7);
            headerClassroom.Font = headerFont;
            headerPanel.Controls.Add(headerClassroom);

            flowLayoutPanelSelectedSections.Controls.Add(headerPanel);

            Font itemFont = new Font("Segoe UI", 9, FontStyle.Regular); // Normal Font

            foreach (var section in selectedSections) // Her şube için bir panel oluştur
            {
                // --- Şube Paneli ---
                Panel panel = new Panel();
                panel.Width = flowLayoutPanelSelectedSections.Width - 25;
                panel.Height = 30;
                panel.Margin = new Padding(0, 0, 0, 2);
                panel.BackColor = Color.WhiteSmoke;

                // Sil butonu
                Button btnDelete = new Button();
                btnDelete.Text = "Sil";
                btnDelete.Size = new Size(40, 24);
                btnDelete.Location = new Point(5, 3);
                btnDelete.Tag = section.SectionID;
                btnDelete.Click += BtnDelete_Click;
                panel.Controls.Add(btnDelete);

                // Ders kodu
                Label lblCourseCode = new Label();
                lblCourseCode.Text = section.CourseCode;
                lblCourseCode.Location = new Point(btnDelete.Right + 10, 7);
                lblCourseCode.AutoSize = true;
                lblCourseCode.Font = itemFont;
                panel.Controls.Add(lblCourseCode);

                // Öğretim Görevlisi
                Label lblInstructor = new Label();
                lblInstructor.Text = section.InstructorName;
                lblInstructor.Location = new Point(headerCourseCode.Right + 10, 7);
                lblInstructor.AutoSize = true;
                lblInstructor.Font = itemFont;
                panel.Controls.Add(lblInstructor);

                // Gün ve saat
                Label lblTime = new Label();
                lblTime.Text = $"{section.Day} {section.StartTime:hh\\:mm} - {section.EndTime:hh\\:mm}";
                lblTime.Location = new Point(headerInstructor.Right + 10, 7);
                lblTime.AutoSize = true;
                lblTime.Font = itemFont;
                panel.Controls.Add(lblTime);

                // Sınıf
                Label lblClassroom = new Label();
                lblClassroom.Text = section.Classroom;
                lblClassroom.Location = new Point(headerTime.Right + 10, 7);
                lblClassroom.AutoSize = true;
                lblClassroom.Font = itemFont;
                panel.Controls.Add(lblClassroom);

                flowLayoutPanelSelectedSections.Controls.Add(panel);
            }
        }

        //
        // Sil butonuna tıklandığında seçilen şube listeden çıkarılır
        //
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int sectionIDToRemove = (int)btn.Tag;

            var sectionToRemove = selectedSections.FirstOrDefault(s => s.SectionID == sectionIDToRemove);
            if (sectionToRemove != null)
            {
                selectedSections.Remove(sectionToRemove);

                RefreshSelectedSectionsPanel();

                MessageBox.Show("Şube listeden çıkarıldı. Değişiklikleri kaydetmek için 'Seçimleri Kaydet'e basın.");
            }
        }


        //
        // Seçilen şubenin değerlerini tutan değişken
        //
        public class SelectedSection
        {
            public string CourseCode { get; set; }
            public string CourseName { get; set; }
            public int CourseID { get; set; }
            public int SectionID { get; set; }
            public string InstructorName { get; set; }
            public string Day { get; set; }
            public TimeSpan StartTime { get; set; }
            public TimeSpan EndTime { get; set; }
            public string Classroom { get; set; }
        }

        //
        // Seçilen şubenin bulunduğu dersin id'sini getiren metot
        //
        private int GetCourseIdBySectionId(int sectionID)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";
            string query = "SELECT CourseID FROM CourseSections WHERE SectionID = @SectionID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SectionID", sectionID);
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32(result);
                }
            }
            throw new Exception($"SectionID {sectionID} için CourseID bulunamadı.");
        }

        //
        // Seçilen şubenin gerekli verilerini veri tabanından çeken metot
        //
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

        //
        // Seçimleri kaydet butonuna tıklandığında eğer çakışma yoksa gerekli metotları çağırır
        //
        private void btnSaveSelections_Click(object sender, EventArgs e)
        {
            if (CheckForTimeConflicts()) // Çakışma var mı kontrol et
            {
                SaveAllSelectionsToDB();
                LoadSelectedSectionsFromDB();
                PopulateScheduleGridView();
            }
        }

        //
        // Seçilen şubeleri veri tabanına kaydeden metot
        //
        private void SaveAllSelectionsToDB()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Öğrencinin mevcut tüm ders seçimlerini veritabanından sil
                    string deleteAllQuery = "DELETE FROM StudentCourseSelections WHERE StudentID = @StudentID";
                    using (SqlCommand deleteAllCommand = new SqlCommand(deleteAllQuery, connection, transaction))
                    {
                        deleteAllCommand.Parameters.AddWithValue("@StudentID", studentID);
                        deleteAllCommand.ExecuteNonQuery();
                    }

                    // selectedSections listesindeki her şubeyi veritabanına ekle
                    string insertQuery = "INSERT INTO StudentCourseSelections (StudentID, CourseID, SectionID) VALUES (@StudentID, @CourseID, @SectionID)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection, transaction))
                    {
                        insertCommand.Parameters.AddWithValue("@StudentID", studentID);

                        foreach (var section in selectedSections)
                        {
                            insertCommand.Parameters.Clear();
                            insertCommand.Parameters.AddWithValue("@StudentID", studentID);
                            insertCommand.Parameters.AddWithValue("@CourseID", GetCourseIdBySectionId(section.SectionID));
                            insertCommand.Parameters.AddWithValue("@SectionID", section.SectionID);
                            insertCommand.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();
                    MessageBox.Show("Ders seçimleriniz başarıyla kaydedildi.");

                    // Kayıt işlemi tamamlandıktan sonra uyarı bilgisini güncelle
                    CheckCourseSelectionStatus();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Ders seçimleri kaydedilirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        //
        // Seçilen derslerin çakışıp çakışmadığını kontrol eden metot
        //
        private bool CheckForTimeConflicts()
        {
            for (int i = 0; i < selectedSections.Count; i++)
            {
                for (int j = i + 1; j < selectedSections.Count; j++)
                {
                    SelectedSection sectionA = selectedSections[i];
                    SelectedSection sectionB = selectedSections[j];

                    if (sectionA.Day == sectionB.Day)
                    {
                        if (sectionA.StartTime < sectionB.EndTime && sectionB.StartTime < sectionA.EndTime)
                        {
                            MessageBox.Show($"Saat çakışması bulundu:\n\n" +
                                            $"{sectionA.CourseCode} ({sectionA.Day} {sectionA.StartTime:hh\\:mm} - {sectionA.EndTime:hh\\:mm})\n" +
                                            $"ile\n" +
                                            $"{sectionB.CourseCode} ({sectionB.Day} {sectionB.StartTime:hh\\:mm} - {sectionB.EndTime:hh\\:mm})\n\n" +
                                            $"Lütfen seçiminizi düzenleyiniz.",
                                            "Saat Çakışması Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false; // Çakışma var
                        }
                    }
                }
            }

            return true; // Çakışma yok
        }

        // -------------------------------------------------- Ders Programı --------------------------------------------------

        //
        // Ders Programı sayfasındaki datagridview metotu
        //
        private void PopulateScheduleGridView()
        {
            dataGridViewSchedule.Columns.Clear();
            dataGridViewSchedule.Rows.Clear();
            dataGridViewSchedule.DataSource = null;

            dataGridViewSchedule.Columns.Add("SaatColumn", "Saat");
            dataGridViewSchedule.Columns.Add("PazartesiColumn", "Pazartesi");
            dataGridViewSchedule.Columns.Add("SaliColumn", "Salı");
            dataGridViewSchedule.Columns.Add("CarsambaColumn", "Çarşamba");
            dataGridViewSchedule.Columns.Add("PersembeColumn", "Perşembe");
            dataGridViewSchedule.Columns.Add("CumaColumn", "Cuma");

            foreach (DataGridViewColumn column in dataGridViewSchedule.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridViewSchedule.Columns["SaatColumn"].Width = 120;
            for (int i = 1; i <= 5; i++)
            {
                dataGridViewSchedule.Columns[i].Width = 150;
                dataGridViewSchedule.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            dataGridViewSchedule.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            List<(TimeSpan Start, TimeSpan End)> fixedIntervals = new List<(TimeSpan, TimeSpan)>
            {
                (TimeSpan.Parse("08:30"), TimeSpan.Parse("09:20")),
                (TimeSpan.Parse("09:30"), TimeSpan.Parse("10:20")),
                (TimeSpan.Parse("10:30"), TimeSpan.Parse("11:20")),
                (TimeSpan.Parse("11:30"), TimeSpan.Parse("12:20")),
                (TimeSpan.Parse("13:30"), TimeSpan.Parse("14:20")),
                (TimeSpan.Parse("14:30"), TimeSpan.Parse("15:20")),
                (TimeSpan.Parse("15:30"), TimeSpan.Parse("16:20")),
                (TimeSpan.Parse("16:30"), TimeSpan.Parse("17:20")),
                (TimeSpan.Parse("17:30"), TimeSpan.Parse("18:20")),
                (TimeSpan.Parse("18:30"), TimeSpan.Parse("19:20")),
                (TimeSpan.Parse("19:30"), TimeSpan.Parse("20:20")),
                (TimeSpan.Parse("20:30"), TimeSpan.Parse("21:20"))
            };

            foreach (var interval in fixedIntervals)
            {
                int rowIndex = dataGridViewSchedule.Rows.Add();
                dataGridViewSchedule.Rows[rowIndex].Cells[0].Value = $"{interval.Start:hh\\:mm} - {interval.End:hh\\:mm}";
            }

            // Hücrelere dersleri yerleştirme
            foreach (var section in selectedSections)
            {
                int colIndex = GetDayColumnIndex(section.Day);

                if (colIndex == -1)
                {
                    continue;
                }

                for (int i = 0; i < fixedIntervals.Count; i++)
                {
                    var currentInterval = fixedIntervals[i];
                    int rowIndex = i;

                    if (section.StartTime < currentInterval.End && section.EndTime > currentInterval.Start)
                    {
                        DataGridViewCell cell = dataGridViewSchedule.Rows[rowIndex].Cells[colIndex];
                        string cellContent = $"{section.CourseCode}\n{section.CourseName}\n{section.Classroom}\n{section.InstructorName}";
                        cell.Value = cellContent;
                    }
                }
            }

            dataGridViewSchedule.Refresh();
        }

        //
        // Ders Programı için dersin gününü bulan metot
        //
        private int GetDayColumnIndex(string day)
        {
            string normalizedDay = day?.Trim();

            switch (normalizedDay)
            {
                case "Pazartesi": return 1;
                case "Salı":
                case "Sali":
                    return 2;
                case "Çarşamba":
                case "Carsamba":
                case "Çarsamba":
                case "Carşamba":
                    return 3;
                case "Perşembe":
                case "Persembe":
                    return 4;
                case "Cuma":
                    return 5;
                default:
                    return -1;
            }
        }
    }
}