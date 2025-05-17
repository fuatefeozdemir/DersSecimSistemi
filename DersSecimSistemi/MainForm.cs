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
        private List<int> selectedSectionIDs = new List<int>();
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
            GetCurriculum();
            CheckCourseSelectionStatus();
            LoadCourses();
            LoadSelectedSectionsFromDB();
            PopulateScheduleGridView();
            labelInfo.Text = $"{fullName}\n{loginID}\n{curriculumName}";
        }

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

            Font headerFont = new Font("Segoe UI", 8, FontStyle.Bold); // Başlıklar için kalın font

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

            Font itemFont = new Font("Segoe UI", 9, FontStyle.Regular); // Şube detayları için normal font

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

        private void RemoveCourseSelectionFromDB(int studentID, int sectionID)
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";
            string query = "DELETE FROM StudentCourseSelections WHERE StudentID=@StudentID AND SectionID=@SectionID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentID", studentID);
                command.Parameters.AddWithValue("@SectionID", sectionID);
                connection.Open();
                command.ExecuteNonQuery();
            }
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

            // 1) Öğrencinin müfredatının ders sayısını al
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

            // 2) Öğrencinin seçtiği ders sayısını al
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

            // Uyarıyı göster
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
        private void btnGoToSchedule_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2; // Üçüncü sekme (Ders Programı)
        }

        private void btnGoToCourseSelection_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1; // İkinci sekme (Ders Kayıt)
        }

        private void btnGoToHome_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0; // Birinci sekme (Ana Sayfa)
        }

        private void PopulateScheduleGridView()
        {
            // DataGridView'i temizle
            dataGridViewSchedule.Columns.Clear();
            dataGridViewSchedule.Rows.Clear();
            dataGridViewSchedule.DataSource = null; // Bağlı bir DataSource varsa kopar

            // --- Sütunları Tanımlama ---
            // İlk sütun saatler için (index 0), sonra Pazartesi'den Cuma'ya günler eklenir.
            dataGridViewSchedule.Columns.Add("SaatColumn", "Saat");
            dataGridViewSchedule.Columns.Add("PazartesiColumn", "Pazartesi");
            dataGridViewSchedule.Columns.Add("SaliColumn", "Salı");
            dataGridViewSchedule.Columns.Add("CarsambaColumn", "Çarşamba");
            dataGridViewSchedule.Columns.Add("PersembeColumn", "Perşembe");
            dataGridViewSchedule.Columns.Add("CumaColumn", "Cuma");
            // Cumartesi ve Pazar sütunları, gönderdiğiniz metot parçasına göre eklenmedi.

            // Sütun genişliklerini ayarla
            dataGridViewSchedule.Columns["SaatColumn"].Width = 70;
            // Gün sütunları (index 1'den 5'e kadar Pazartesi - Cuma)
            for (int i = 1; i <= 5; i++)
            {
                dataGridViewSchedule.Columns[i].Width = 120;
                dataGridViewSchedule.Columns[i].DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Metin sığmazsa alt satıra geç
            }


            // --- Satırları (Saat Dilimleri) Tanımlama ---

            // selectedSections listesindeki tüm benzersiz başlangıç saatlerini topla
            var uniqueStartTimes = selectedSections.Select(s => s.StartTime)
                                                    .Distinct() // Benzersiz saatleri al
                                                    .OrderBy(time => time) // Saatleri sırala
                                                    .ToList(); // Liste haline getir

            // Eğer hiç ders seçilmemişse sadece başlık kalır.
            if (!uniqueStartTimes.Any())
            {
                return;
            }

            // Her benzersiz başlangıç saati için DataGridView'e bir satır ekle
            foreach (var time in uniqueStartTimes)
            {
                int rowIndex = dataGridViewSchedule.Rows.Add(); // Yeni satır ekle
                                                                // Satırın ilk hücresine saat değerini yaz (hh:mm formatında)
                dataGridViewSchedule.Rows[rowIndex].Cells[0].Value = time.ToString(@"hh\:mm");
                dataGridViewSchedule.Rows[rowIndex].Height = 60; // Satır yüksekliğini ayarla
            }

            // Saat dilimi değerini kullanarak ilgili satır indeksini bulmak için yardımcı Dictionary
            // Bu Dictionary, her bir benzersiz TimeSpani, onun DataGridView'deki satır indeksine eşler.
            var timeRowMap = uniqueStartTimes.Select((time, index) => new { time, index })
                                            .ToDictionary(item => item.time, item => item.index);


            // --- Dersleri Hücrelere Yerleştirme (Basitleştirilmiş) ---

            // Her benzersiz saat dilimi (DataGrivView satırı) için
            for (int i = 0; i < uniqueStartTimes.Count; i++)
            {
                var currentTimeSlot = uniqueStartTimes[i]; // Şu anki satırın temsil ettiği saat

                // Her seçili şube için kontrol yap
                foreach (var section in selectedSections)
                {
                    // Şubenin günü için sütun indeksini al (Pazartesi=1, Salı=2, ...)
                    int colIndex = -1;
                    switch (section.Day)
                    {
                        case "Pazartesi": colIndex = 1; break;
                        case "Salı": colIndex = 2; break;
                        case "Çarşamba": colIndex = 3; break;
                        case "Perşembe": colIndex = 4; break;
                        case "Cuma": colIndex = 5; break;
                            // Eğer Cumartesi/Pazar dersleri de olsaydı ve sütunları ekleseydik buraya eklenecekti.
                            // case "Cumartesi": colIndex = 6; break;
                            // case "Pazar": colIndex = 7; break;
                    }

                    // Eğer geçerli bir gün sütunu bulunduysa (Pazartesi-Cuma arası)
                    if (colIndex != -1)
                    {
                        // Eğer şubenin başlangıç saati şu anki saat dilimine eşit veya ondan küçükse
                        // VE şubenin bitiş saati şu anki saat diliminden büyükse
                        // Bu koşul, dersin bu saat diliminin başladığı an itibarıyla devam ettiğini gösterir.
                        // Görseldeki gibi tekrar görünmesini sağlar.
                        if (section.StartTime <= currentTimeSlot && section.EndTime > currentTimeSlot)
                        {
                            // Hücreyi bul (şu anki satır ve şubenin gününe denk gelen sütun)
                            DataGridViewCell cell = dataGridViewSchedule.Rows[i].Cells[colIndex];

                            // Hücre içeriğini biçimlendir (Ders Kodu, Ders Adı, Derslik, Öğretmen)
                            // selectedSections listesinde CourseName property'si olduğunu varsayıyoruz.
                            string cellContent = $"{section.CourseCode}\n{section.CourseName}\n{section.Classroom}\n{section.InstructorName}";

                            // Çakışma olmadığı varsayıldığı için, hücrede zaten bilgi olup olmadığını kontrol etmeye veya birleştirmeye gerek yok.
                            // Doğrudan hücre değerini ata.
                            cell.Value = cellContent;

                            // Satır yüksekliği zaten her satır için ayarlandı ve WrapMode açık.
                        }
                    }
                }
            }

            // DataGridView'in yenilenmesini sağla
            // DataBinding kullanılmadığı için Refresh veya Update çağrılabilir.
            dataGridViewSchedule.Refresh();
        }

        private int GetDayColumnIndex(string day)
        {
            switch (day)
            {
                case "Pazartesi": return 1;
                case "Salı": return 2;
                case "Çarşamba": return 3;
                case "Perşembe": return 4;
                case "Cuma": return 5;
                default: return 0; // Geçersiz gün
            }
        }
        private void LoadCourses()
        {
            flowLayoutPanelCourses.Controls.Clear();

            // Başlık paneli
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

            // Ekle
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

                    // Panel
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
                    addButton.Location = new Point(5, 3);
                    addButton.Click += CourseButton_Click;
                    addButton.Tag = new Tuple<int, string>(courseID, courseCode);

                    // Ders kodu
                    Label codeLabel = new Label();
                    codeLabel.Text = courseCode;
                    codeLabel.AutoSize = true;
                    codeLabel.Location = new Point(addButton.Right + 10, 6);
                    codeLabel.Font = new Font("Segoe UI", 8, FontStyle.Regular);

                    // Ders adı
                    Label nameLabel = new Label();
                    nameLabel.Text = courseName;
                    nameLabel.AutoSize = true;
                    nameLabel.Location = new Point(codeLabel.Right + 20, 6);
                    nameLabel.Font = new Font("Segoe UI", 8, FontStyle.Regular);

                    // Ekle
                    coursePanel.Controls.Add(addButton);
                    coursePanel.Controls.Add(codeLabel);
                    coursePanel.Controls.Add(nameLabel);

                    flowLayoutPanelCourses.Controls.Add(coursePanel);
                }
            }
        }

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

        private void SaveAllSelectionsToDB()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DersSecimSistemiDB;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // 1) Öğrencinin mevcut tüm ders seçimlerini veritabanından sil
                    string deleteAllQuery = "DELETE FROM StudentCourseSelections WHERE StudentID = @StudentID";
                    using (SqlCommand deleteAllCommand = new SqlCommand(deleteAllQuery, connection, transaction))
                    {
                        deleteAllCommand.Parameters.AddWithValue("@StudentID", studentID);
                        deleteAllCommand.ExecuteNonQuery();
                    }

                    // 2) selectedSections listesindeki her şubeyi veritabanına ekle
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
            // Hata durumu, SectionID bulunamazsa
            throw new Exception($"SectionID {sectionID} için CourseID bulunamadı.");
        }

        private void btnSaveSelections_Click(object sender, EventArgs e)
        {
            if (CheckForTimeConflicts()) // Çakışma var mı kontrol et
            {
                SaveAllSelectionsToDB();
                LoadSelectedSectionsFromDB();
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panelProfile.Visible = !panelProfile.Visible;
        }

        private void Logout()
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logout();
        }
    }
}