using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace VnSentencesConparator
{
    public partial class FrmMain : MetroFramework.Forms.MetroForm
    {
        #region FIELDS
        /// <summary>
        /// dialog progress
        /// </summary>
        FrmProgressDialog frmProgress;
        /// <summary>
        /// input file path
        /// </summary>
        string inputFile;
        /// <summary>
        /// command line exit code
        /// </summary>
        int cmdExitCode;
        #endregion
        #region CONSTRUCTOR
        public FrmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtFileName.Text = "";
            txtReadInfo.Text = "";
            txtSeparationInfo.Text = "";
            txtImportDBInfo.Text = "";
        }
        #endregion
        #region MENU CLICK
        private void importTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!taskReadTxt.IsBusy && !taskSeparatingWord.IsBusy && !taskImportDB.IsBusy)
            {
                tabControl.SelectedTab = importDbTab;
            }
        }

        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!taskReadTxt.IsBusy && !taskSeparatingWord.IsBusy && !taskImportDB.IsBusy)
            {
                tabControl.SelectedTab = compareTab;
                txtSentence1.Text = "Enter a sentence...";
                txtSentence1.ForeColor = Color.Gray;
                txtSentence2.Text = "Enter a sentence...";
                txtSentence2.ForeColor = Color.Gray;
                lbTxt1Info.Hide();
                lbTxt2Info.Hide();
                lbVec1Info.Hide();
                lbVec2Info.Hide();
                lbSimilarity.Hide();
                btnCalculate.Focus();
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!taskReadTxt.IsBusy && !taskSeparatingWord.IsBusy && !taskImportDB.IsBusy)
            {
                tabControl.SelectedTab = tabAbout;
            }
        }
        #endregion
        #region DICTIONARY PROVIDE BUTTON CLICK
        /// <summary>
        /// Bắt sự kiện button chọn file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            // kiểm tra hiện hệ thống có thực hiện tác vụ ngầm nào không
            if (!taskReadTxt.IsBusy && !taskSeparatingWord.IsBusy && !taskImportDB.IsBusy)
            {
                // trường hợp chưa trong quá trình đọc
                // mở dialog chọn vị trí file đầu vào
                OpenFileDialog file = new OpenFileDialog();
                // cài đặt bộ lọc file 
                file.Filter = "Text|*.txt|All|*.*";
                // nếu người dùng chọn file
                if (file.ShowDialog() == DialogResult.OK)
                {
                    // nếu file chọn là file txt
                    if (Util.isTextFile(file.FileName))
                    {
                        // lưu địa chỉ file
                        inputFile = file.FileName;
                        // tùy biến giao diện
                        txtFileName.Text = inputFile;
                        txtInOut.Text = "Waiting...";
                        txtReadInfo.Text = "";
                        txtSeparationInfo.Text = "";
                        // tạo & show 1 form loading progress
                        frmProgress = new FrmProgressDialog();
                        frmProgress.Text = "Reading text file";
                        frmProgress.Show();
                        // chạy quá trình đọc 
                        taskReadTxt.RunWorkerAsync();
                    }
                    else
                    {
                        // trường hợp người dùng ko chọn file text -> hiển thị thông báo
                        MetroMessageBox.Show(this, "Not text file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // trường hợp hệ thống đang bận -> hiển thị thông báo
                MetroMessageBox.Show(this, "In process, please wait...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Bắt sự kiện button tách từ & gán nhãn từ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreprocess_Click(object sender, EventArgs e)
        {
            // kiểm tra hiện hệ thống có thực hiện tác vụ ngầm nào không
            if (!taskReadTxt.IsBusy && !taskSeparatingWord.IsBusy && !taskImportDB.IsBusy)
            {
                // kiểm tra nếu đã có dữ liệu đầu vào
                if (inputFile != null && Util.isTextFile(inputFile))
                {
                    // thực hiện copy file dầu vào vào thư mục debug
                    string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\vn.hus.nlp.tagger-4.2.0-bin\\";
                    // copy text file ra thư muc debug
                    if (Util.copyFile(inputFile, path + "input.txt"))
                    {
                        // nếu copy thành công
                        txtInOut.Text = "Waiting...";
                        txtSeparationInfo.Text = "";
                        // tạo & show 1 form loading progress
                        frmProgress = new FrmProgressDialog();
                        frmProgress.Text = "Prepare to import";
                        frmProgress.toogleImg();
                        frmProgress.Show();
                        // chạy quá trình tách từ
                        taskSeparatingWord.RunWorkerAsync();
                    }
                    else
                    {
                        // trường hợp copy lỗi
                        MetroMessageBox.Show(this, "An exceptions occurred while copying files", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    // trường hợp chưa có dữ liệu đầu vào
                    MetroMessageBox.Show(this, "No input data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // trường hợp hệ thống đang bận -> hiển thị thông báo
                MetroMessageBox.Show(this, "In process, please wait...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImportDB_Click(object sender, EventArgs e)
        {
            // kiểm tra hiện hệ thống có thực hiện tác vụ ngầm nào không
            if (!taskReadTxt.IsBusy && !taskSeparatingWord.IsBusy && !taskImportDB.IsBusy)
            {
                if (DaoImpl.checkConnection(txtDB.Text.ToString()))
                {
                    // tạo & show 1 form loading progress
                    frmProgress = new FrmProgressDialog();
                    frmProgress.Text = "Import to database";
                    frmProgress.toogleImg();
                    frmProgress.Show();
                    // chạy quá trình tách từ
                    taskImportDB.RunWorkerAsync();
                }
                else
                {
                    // trường hợp ko kết nối đc đến db
                    MetroMessageBox.Show(this, "Cannot connect to data base, please check connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // trường hợp hệ thống đang bận -> hiển thị thông báo
                MetroMessageBox.Show(this, "In process, please wait...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
        #region TASK READ TEXT FILE
        /// <summary>
        /// quá trình đọc file đầu vào
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskReadTxt_DoWork(object sender, DoWorkEventArgs e)
        {
            // lấy tham chiếu BackgroundWorker
            BackgroundWorker worker = sender as BackgroundWorker;
            // khởi động bộ đếm thời gian đọc
            var watch = Stopwatch.StartNew();
            // đọc file đầu vào ra mảng 
            String[] inputData = File.ReadAllLines(inputFile, Encoding.UTF8);
            // kiểm tra dữ liệu đầu vào
            if (inputData.Length == 0)
            {
                // nếu file rỗng -> thoát
                watch.Stop();
                this.Invoke((MethodInvoker)delegate
                {
                    txtInOut.Text = "";
                    txtReadInfo.Text = "File empty!!!";
                    txtFileName.Text = ("File name: " + inputFile);
                });
                return;
            }
            // nếu file có dữ liệu, xử lý hiển thị lên form
            // tạo các biến cần thiết để xử lý dữ liệu
            StringBuilder textDisplay = new StringBuilder(); // string builder
            int displayLine = 0; //số dòng hiển thị
            int percentage = 0; // % đọc
            // duyệt toàn bộ mảng đầu vào, đọc từng dòng một
            for (int i = 0; i < inputData.Length; i++)
            {
                // kiểm tra độ dài tối đa có thể hiển thị lên rich text box
                if ((textDisplay.Length + inputData[i].Length + 3) < 500000)
                {
                    // trường hợp chưa đạt độ dài tối đa
                    // thêm dòng vào số dòng hiển thị
                    textDisplay.Append(inputData[i] + "\n");
                    displayLine++;
                    // tính toán %
                    if (inputData.Length < 3000)
                    {
                        percentage = (int)(((float)i / inputData.Length) * 100);
                    }
                    else
                    {
                        percentage = (int)(((float)textDisplay.Length / 500000) * 100);
                    }
                    // truyền % sang dialog
                    worker.ReportProgress(percentage);
                }
                else
                {
                    // trường hợp đạt độ dài tối đa
                    break;
                }
            }
            // invoke method show dữ liệu lên main form
            this.Invoke((MethodInvoker)delegate
            {
                txtInOut.Text = textDisplay.ToString();
                txtFileName.Text = ("File name: " + inputFile);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                txtReadInfo.Text = "Read time: "
                    + ((double)(elapsedMs / 1000d)) + " ms (Display: " + displayLine
                    + " lines, total:" + inputData.Length + " lines)";
            });
        }
        /// <summary>
        /// hàm được gọi khi quá trình đọc file diễn ra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskReadTxt_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // truyền dữ liệu sang dialog để hiển thị
            frmProgress.Message = "In progress, please wait... " + e.ProgressPercentage.ToString() + "%";
            frmProgress.ProgressValue = e.ProgressPercentage;
        }
        /// <summary>
        /// hàm hoàn thành quá trình đọc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskReadTxt_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // đóng dialog 
            frmProgress.Close();
            frmProgress.Dispose();
            this.Focus();
        }
        #endregion
        #region TASK SEPARATING WORDS
        /// <summary>
        /// quá trình tách từ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskSeparatingWord_DoWork(object sender, DoWorkEventArgs e)
        {
            // khởi động bộ đếm tg
            var watch = Stopwatch.StartNew();
            // lấy đường link thư mục chứa file bat 
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\vn.hus.nlp.tagger-4.2.0-bin\\";
            // lấy tham chiếu BackgroundWorker
            BackgroundWorker worker = sender as BackgroundWorker;
            // khởi tạo biến xử lý
            ProcessStartInfo processInfo;   // ProcessStartInfo
            Process process;    // process
            string command = "vnTagger.bat -i input.txt -o output.txt -u -p";    // command
            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);     // initialize 
            // đặt thư mục chứa file bat làm thư mục thực thi cmd
            processInfo.WorkingDirectory = path;
            // cài đặt 1 vài thuộc tính 
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // chuyển hướng đầu ra thông tin lệnh thực thi
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            // thực thi
            process = Process.Start(processInfo);
            // đón luồng dữ liệu từ cmd về
            process.OutputDataReceived += (object sender1, DataReceivedEventArgs e1) =>
                Console.WriteLine("output>>" + e1.Data);
            process.BeginOutputReadLine();
            process.ErrorDataReceived += (object sender2, DataReceivedEventArgs e2) =>
                Console.WriteLine("error>>" + e2.Data);
            process.BeginErrorReadLine();
            // lấy time out từ setting
            int maxTime = Convert.ToInt16(txtMaxTime.Text.ToString());
            // chờ cho đến khi cmd thực hiện xong hoặc time out
            if (process.WaitForExit(maxTime * 60 * 1000))
            {
                // nếu cmd thực hiện xong trước time out
                cmdExitCode = process.ExitCode;
                process.Close();
                Console.WriteLine("Exit code = " + cmdExitCode);
                // tạo các biến cần thiết để xử lý dữ liệu
                StringBuilder textDisplay = new StringBuilder(); // string builder
                long nouns = 0;
                long verbs = 0;
                long adjs = 0;
                long others = 0;
                long totalWord = 0;
                // kiểm tra nếu cmd thực thi thành công 
                if (cmdExitCode == 0)
                {
                    // bắt đầu quá trình lấy thông tin đã thực thi
                    String[] inputData = File.ReadAllLines(path + "output.txt", Encoding.UTF8);
                    // khởi tạo biến xử lý
                    int wordPerLine, nounPerLine, verbPerLine, adjPerLine, othersPerLine;
                    // duyệt toàn bộ mảng đầu vào, đọc từng dòng một
                    for (int i = 0; i < inputData.Length; i++)
                    {
                        // kiểm tra độ dài tối đa có thể hiển thị lên rich text box
                        if ((textDisplay.Length + inputData[i].Length + 3) < 500000)
                        {
                            // trường hợp chưa đạt độ dài tối đa
                            // thêm dòng vào số dòng hiển thị
                            textDisplay.Append(inputData[i] + "\n");
                            // đếm số từ
                            wordPerLine = (inputData[i].Count(f => f == ' '));
                            // đếm danh, động, tính từ
                            nounPerLine = Regex.Matches(inputData[i], @"/N").Count;
                            verbPerLine = Regex.Matches(inputData[i], @"/V").Count;
                            adjPerLine = Regex.Matches(inputData[i], @"/A").Count;
                            // đếm các từ loại khác
                            othersPerLine = wordPerLine - nounPerLine - verbPerLine - adjPerLine;
                            // lưu vết
                            totalWord += wordPerLine;
                            nouns += nounPerLine;
                            verbs += verbPerLine;
                            adjs += adjPerLine;
                            others += othersPerLine;
                        }

                    }
                }
                // hiển thị thông tin đã thực thi lên form
                this.Invoke((MethodInvoker)delegate
                {
                    if (cmdExitCode == 0)
                    {
                        txtFileName.Text = path + "output.txt";
                        txtInOut.Text = textDisplay.ToString();
                        watch.Stop();
                        var elapsedMs = watch.ElapsedMilliseconds;
                        txtSeparationInfo.Text = @"Separating && tagging words time: "
                            + ((double)(elapsedMs / 1000d)) + " ms\n                    Noun: " + nouns + " (times)"
                            + "\n                    Verb: " + verbs + " (times)"
                            + "\n                    Adjective: " + adjs + " (times)"
                            + "\n                    Other: " + others + " (times)"
                            + "\n                    Total: " + totalWord + " (times)";
                    }
                });
            }
            // nếu đã quá time out mà cmd vẫn chưa xong
            else
            {
                // chờ lâu quá, dừng process
                cmdExitCode = 9999;
                process.Close();
                Console.WriteLine("Separate words time out");
                this.Invoke((MethodInvoker)delegate
                {
                    txtFileName.Text = "";
                    txtInOut.Text = "Failed. Separate words time out. Please try a gain.";
                });
            }
        }

        private void taskSeparatingWord_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // đóng dialog 
            frmProgress.Close();
            frmProgress.Dispose();
            // nếu thực thi lỗi
            if (cmdExitCode != 0)
            {
                // hiển thị thông báo
                MetroMessageBox.Show(this, "An exceptions occurred while separating words: separate words time out ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Focus();
        }
        #endregion
        #region TASK IMPORT TO DB
        /// <summary>
        /// quá trình import từ đã tách vào db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskImportDB_DoWork(object sender, DoWorkEventArgs e)
        {
            // lấy tham chiếu BackgroundWorker
            BackgroundWorker worker = sender as BackgroundWorker;
            // khởi động bộ đếm thời gian đọc
            var watch = Stopwatch.StartNew();
            // lấy đường dẫn file output
            string ouputFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\vn.hus.nlp.tagger-4.2.0-bin\\output.txt";
            if (!File.Exists(ouputFile))
            {
                watch.Stop();
                this.Invoke((MethodInvoker)delegate
                {
                    // đóng dialog 
                    frmProgress.Close();
                    frmProgress.Dispose();
                });
                MetroMessageBox.Show(this, "File ouput.txt is not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // đọc file output ra mảng 
            String[] inputData = File.ReadAllLines(ouputFile, Encoding.UTF8);
            // kiểm tra file output
            if (inputData.Length == 0)
            {
                watch.Stop();
                this.Invoke((MethodInvoker)delegate
                {
                    // đóng dialog 
                    frmProgress.Close();
                    frmProgress.Dispose();
                });
                MetroMessageBox.Show(this, "File ouput.txt is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // khởi tạo biến từ điển để xử lý
            Dictionary<string, Word> newDictionary = new Dictionary<string, Word>();
            // thống kê các từ xuất hiện trong file output
            // duyệt từng câu một
            for (int i = 0; i < inputData.Length; i++)
            {
                // tách từ để xử lý
                string[] words = inputData[i].Split(' ');
                // loại các từ trùng nhau trong 1 câu
                words = words.Distinct().ToArray();
                // duyệt từng từ tách được trong câu
                foreach (string word in words)
                {
                    // nếu từ rỗng hoặc từ thuộc loại số (M) hoặc không rõ (X)
                    if (word.Length == 0 || word.Contains("/M") || word.Contains("/X"))
                    {
                        // bỏ qua
                        continue;
                    }
                    // trường hợp còn lại
                    // kiểm tra các câu trước đó
                    if (newDictionary.ContainsKey(word))
                    {
                        // nếu thấy từ đã xuất hiện, tăng số lần xuất hiện lên 1
                        newDictionary[word].Occ += 1;
                    }
                    else
                    {
                        // trường hợp lần đầu bắt gặp từ, thêm mới 
                        newDictionary.Add(word, new Word(word, 1));
                    }
                }
            }
            // thực hiện import dữ liệu mới vào database
            DaoImpl dao = new DaoImpl();
            // lấy số từ trong db trước khi thực hiện import
            int numOfOldWords = dao.getWordNumber(txtDB.Text);
            // số từ được import vào db
            int updateResult = dao.updateDictionary(txtDB.Text, dao.convertDictToDataTable(newDictionary));
            // lấy số từ trong db sau khi thực hiện import 
            int numOfNewWords = dao.getWordNumber(txtDB.Text);
            // số từ thêm mới
            int numOfInsertedWords = numOfNewWords - numOfOldWords;
            // số từ cập nhật (được update số lần xuất hiện)
            int numOfUpdatedWords = updateResult - numOfInsertedWords;
            // tổng số câu trong db
            int numOfSentences = dao.getSentenceNumber(txtDB.Text);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            // hiển thị thông báo lên màn hình
            this.Invoke((MethodInvoker)delegate
            {
                txtImportDBInfo.Text = @"Import to data base time: "
                            + ((double)(elapsedMs / 1000d))
                            + " ms\n                    New words: " + numOfInsertedWords
                            + "\n                    Words already exist: " + numOfUpdatedWords
                            + "\n                    Total words: " + numOfNewWords
                            + "\n                    Total sentences: " + numOfSentences;
            });
        }

        private void taskImportDB_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // truyền dữ liệu sang dialog để hiển thị
            frmProgress.Message = "In progress, please wait... " + e.ProgressPercentage.ToString() + "%";
            frmProgress.ProgressValue = e.ProgressPercentage;
        }

        private void taskImportDB_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // đóng dialog 
            frmProgress.Close();
            frmProgress.Dispose();
            // nếu thực thi lỗi
            //if (cmdExitCode != 0)
            //{
            //    // hiển thị thông báo
            //    MetroMessageBox.Show(this, "An exceptions occurred while separating words: separate words time out ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            this.Focus();
        }
        #endregion
        #region MIX INPUT RICH TEXT BOX
        private void txtSentence1_Enter(object sender, EventArgs e)
        {
            if (((RichTextBox)sender).ForeColor != Color.Black)
            {
                ((RichTextBox)sender).ForeColor = Color.Black;
                ((RichTextBox)sender).Text = "";
            }
        }

        private void txtSentence1_Leave(object sender, EventArgs e)
        {
            if (((RichTextBox)sender).Text.Length > 0)
            {
                return;
            }
            if (((RichTextBox)sender).ForeColor != Color.Gray)
            {
                ((RichTextBox)sender).ForeColor = Color.Gray;
                ((RichTextBox)sender).Text = "Enter a sentence...";
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSentence1.Text = "Enter a sentence...";
            txtSentence1.ForeColor = Color.Gray;
            txtSentence2.Text = "Enter a sentence...";
            txtSentence2.ForeColor = Color.Gray;
            lbTxt1Info.Hide();
            lbTxt2Info.Hide();
            lbVec1Info.Hide();
            lbVec2Info.Hide();
            lbSimilarity.Hide();
            btnCalculate.Focus();
        }
        #endregion
        #region DISTANCE CALCULATE BUTTON CLICK
        /// <summary>
        /// button calculate click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // check connection
            if (!DaoImpl.checkConnection(txtDB.Text.ToString()))
            {
                MetroMessageBox.Show(this, "Cannot connect to data base.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // check 2 ô text
            if (txtSentence1.ForeColor == Color.Gray || txtSentence2.ForeColor == Color.Gray)
            {
                // trường hợp nhập thiếu
                MetroMessageBox.Show(this, "Please input text into both two textboxes.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // tạo & show 1 form loading progress
            frmProgress = new FrmProgressDialog();
            frmProgress.Text = "Calculating Similarity";
            frmProgress.toogleImg();
            frmProgress.Show();
            // chạy quá trình tính toán
            taskCalculateSimilarity.RunWorkerAsync();
        }
        private void lbVec1Info_MouseHover(object sender, EventArgs e)
        {
            ttVecInfo.SetToolTip((Label)sender, ((Label)sender).Text.ToString());
        }
        #endregion
        #region TASK CALCULATE SIMILARITY
        /// <summary>
        /// quá trình tính toán độ tương tự
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskCalculateSimilarity_DoWork(object sender, DoWorkEventArgs e)
        {
            // lấy tham chiếu BackgroundWorker
            BackgroundWorker worker = sender as BackgroundWorker;
            string str1 = "";
            string str2 = "";
            /// B1: tiền xử lý
            /// loại dấu câu & khoảng trống dư thừa
            this.Invoke((MethodInvoker)delegate
            {
                str1 = txtSentence1.Text.ToString();
                str1 = Util.normalizeString(str1);
                str2 = txtSentence2.Text.ToString();
                str2 = Util.normalizeString(str2);
            });
            // kiểm tra giá trị đầu vào có phù hợp
            if (str1.Length == 0 || str2.Length == 0)
            {
                // trường hợp nhập toàn dấu câu hoặc nhập toàn khoảng trống
                this.Invoke((MethodInvoker)delegate
                {
                    MetroMessageBox.Show(this, "Please input text into both two textboxes.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
                return;
            }
            // khởi tạo biến xử lý
            DaoImpl dao = new DaoImpl();
            string dbName = txtDB.Text;
            // lấy số câu đã đọc trong DB
            int numOfSentences = dao.getSentenceNumber(dbName);
            // tách từ dựa trên DB
            List<Word> listWordStr1 = dao.separateWord(dbName, str1);
            List<Word> listWordStr2 = dao.separateWord(dbName, str2);
            // show từ đã tách ra text box
            this.Invoke((MethodInvoker)delegate
                {
                    txtSentence1.Text = Util.combineListWordToString(listWordStr1, numOfSentences);
                    txtSentence2.Text = Util.combineListWordToString(listWordStr2, numOfSentences);
                });
            /// B2: trích chọn đặc trưng
            /// Tính vector đặc trưng
            // đếm số danh từ, động từ, tính từ và từ loại khác trong 2 textbox
            List<string> arrNoun = new List<string>();
            List<string> arrVerb = new List<string>();
            List<string> arrAdj = new List<string>();
            List<string> arrOther = new List<string>();

            int nounTxt1 = 0;
            int verbTxt1 = 0;
            int adjTxt1 = 0;
            int otherTxt1 = 0;

            int nounTxt2 = 0;
            int verbTxt2 = 0;
            int adjTxt2 = 0;
            int otherTxt2 = 0;

            // duyệt từng từ trong textbox 1
            foreach (Word word in listWordStr1)
            {
                // kiểm tra loại từ & đưa vào mảng từ loại phù hợp
                if (word.Pos.Contains("N"))
                {
                    // danh từ
                    if (!arrNoun.Contains(word.Token))
                    {
                        arrNoun.Add(word.Token);
                    }
                    nounTxt1++;
                }
                else if (word.Pos.Equals("V"))
                {
                    // động từ
                    if (!arrVerb.Contains(word.Token))
                    {
                        arrVerb.Add(word.Token);
                    }
                    verbTxt1++;
                }
                else if (word.Pos.Equals("A"))
                {
                    // tính từ
                    if (!arrAdj.Contains(word.Token))
                    {
                        arrAdj.Add(word.Token);
                    }
                    adjTxt1++;
                }
                else
                {
                    // từ loại khác
                    if (!arrOther.Contains(word.Token))
                    {
                        arrOther.Add(word.Token);
                    }
                    otherTxt1++;
                }
            }
            // duyệt từng từ trong textbox 2
            foreach (Word word in listWordStr2)
            {
                // kiểm tra loại từ & đưa vào mảng từ loại phù hợp
                if (word.Pos.Contains("N"))
                {
                    // danh từ
                    if (!arrNoun.Contains(word.Token))
                    {
                        arrNoun.Add(word.Token);
                    }
                    nounTxt2++;
                }
                else if (word.Pos.Equals("V"))
                {
                    // động từ
                    if (!arrVerb.Contains(word.Token))
                    {
                        arrVerb.Add(word.Token);
                    }
                    verbTxt2++;
                }
                else if (word.Pos.Equals("A"))
                {
                    // tính từ
                    if (!arrAdj.Contains(word.Token))
                    {
                        arrAdj.Add(word.Token);
                    }
                    adjTxt2++;
                }
                else
                {
                    // từ loại khác
                    if (!arrOther.Contains(word.Token))
                    {
                        arrOther.Add(word.Token);
                    }
                    otherTxt2++;
                }
            }
            // show thông tin 
            this.Invoke((MethodInvoker)delegate
            {
                lbTxt1Info.Text = "Word number: " + listWordStr1.Count
                                + "\nNoun: " + nounTxt1
                                + "\nVerb: " + verbTxt1
                                + "\nAdj: " + adjTxt1
                                + "\nOther: " + otherTxt1;
                lbTxt1Info.Show();
                lbTxt2Info.Text = "Word number: " + listWordStr2.Count
                                + "\nNoun: " + nounTxt2
                                + "\nVerb: " + verbTxt2
                                + "\nAdj: " + adjTxt2
                                + "\nOther: " + otherTxt2;
                lbTxt2Info.Show();
            });
            // tính toán vector đặc trưng về danh từ, động từ, tính từ, từ loại khác
            double[] vec1N = new double[arrNoun.Count];
            double[] vec1V = new double[arrVerb.Count];
            double[] vec1A = new double[arrAdj.Count];
            double[] vec1O = new double[arrOther.Count];

            double[] vec2N = new double[arrNoun.Count];
            double[] vec2V = new double[arrVerb.Count];
            double[] vec2A = new double[arrAdj.Count];
            double[] vec2O = new double[arrOther.Count];
            // duyệt từng từ trong textbox 1
            foreach (Word word in listWordStr1)
            {
                // kiểm tra loại từ, đưa tần suất xuất hiện vào vector đặc trưng vào vector đặc trưng
                if (word.Pos.Contains("N"))
                {
                    // tìm chỉ số chiều trong vector đặc trưng
                    int index = arrNoun.FindIndex(a => a.Equals(word.Token));
                    // thêm tần suất xuất hiện vào chỉ số tìm được
                    vec1N[index] += (((double)word.Occ) / numOfSentences);
                }
                else if (word.Pos.Equals("V"))
                {
                    // tìm chỉ số chiều trong vector đặc trưng
                    int index = arrVerb.FindIndex(a => a.Equals(word.Token));
                    // thêm tần suất xuất hiện vào chỉ số tìm được
                    vec1V[index] += (((double)word.Occ) / numOfSentences);
                }
                else if (word.Pos.Equals("A"))
                {
                    // tìm chỉ số chiều trong vector đặc trưng
                    int index = arrAdj.FindIndex(a => a.Equals(word.Token));
                    // thêm tần suất xuất hiện vào chỉ số tìm được
                    vec1A[index] += (((double)word.Occ) / numOfSentences);
                }
                else
                {
                    // tìm chỉ số chiều trong vector đặc trưng
                    int index = arrOther.FindIndex(a => a.Equals(word.Token));
                    // thêm tần suất xuất hiện vào chỉ số tìm được
                    vec1O[index] += (((double)word.Occ) / numOfSentences);
                }
            }
            // duyệt từng từ trong textbox 2
            foreach (Word word in listWordStr2)
            {
                // kiểm tra loại từ, đưa tần suất xuất hiện vào vector đặc trưng vào vector đặc trưng
                if (word.Pos.Contains("N"))
                {
                    int index = arrNoun.FindIndex(a => a.Equals(word.Token));
                    vec2N[index] += (((double)word.Occ) / numOfSentences);
                }
                else if (word.Pos.Equals("V"))
                {
                    int index = arrVerb.FindIndex(a => a.Equals(word.Token));
                    vec2V[index] += (((double)word.Occ) / numOfSentences);
                }
                else if (word.Pos.Equals("A"))
                {
                    int index = arrAdj.FindIndex(a => a.Equals(word.Token));
                    vec2A[index] += (((double)word.Occ) / numOfSentences);
                }
                else
                {
                    int index = arrOther.FindIndex(a => a.Equals(word.Token));
                    vec2O[index] += (((double)word.Occ) / numOfSentences);
                }
            }
            // show thông tin
            this.Invoke((MethodInvoker)delegate
            {
                lbVec1Info.Text = Util.getVectorInfo(vec1N, vec1V, vec1A, vec1O);
                lbVec1Info.Show();
                lbVec2Info.Text = Util.getVectorInfo(vec2N, vec2V, vec2A, vec2O);
                lbVec2Info.Show();
            });
            /// B3: tính độ tương tự cosin dựa trên vector đặc trưng
            // tính cosin simillarity của danh từ, động từ, tính từ, từ loại khác
            double nSim = Util.cosineSimilarity(vec1N, vec2N);
            double vSim = Util.cosineSimilarity(vec1V, vec2V);
            double aSim = Util.cosineSimilarity(vec1A, vec2A);
            double oSim = Util.cosineSimilarity(vec1O, vec2O);
            // show kết quả
            this.Invoke((MethodInvoker)delegate
            {
                lbSimilarity.Text = "Similarity = " + "(" + nSim + " + " + vSim + " + " + aSim + " + " + oSim + " )/4 = "
                    + ((nSim + vSim + aSim + oSim) / 4);
                lbSimilarity.Show();
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskCalculateSimilarity_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        /// <summary>
        /// hoàn thành task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taskCalculateSimilarity_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // đóng dialog 
            frmProgress.Close();
            frmProgress.Dispose();
            this.Focus();
        }
        #endregion

        private void txtInOut_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
