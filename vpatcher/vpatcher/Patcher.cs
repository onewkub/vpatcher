using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace vpatcher {
    public partial class Patcher : Form {
        // CONFIGURATION
        const string HOST = "127.0.0.1";
        const int PORT = 7447;
        const string PROGRAM = "client.exe";
        const string MERGER = "rsumerge.exe";

        readonly string HOSTADDRESS = "http://" + HOST + ":" + PORT;
        delegate void SetTextThreadSafe(Label lbl, string text);
        delegate void SetProgressThreadSafe(ProgressBar pbar, int percentage);
        delegate void SetStateThreadSafe(Button btn, bool state);
        readonly ManualResetEvent mre = new ManualResetEvent(false);
        readonly List<string> neededPatches = new List<string>();
        readonly Dictionary<string, string[]> filesToDownload = new Dictionary<string, string[]>();
        float downloadedFiles = 0;
        string destinationFile = string.Empty;
        string patchTarget = string.Empty;
        

        public Patcher() {
            InitializeComponent();
        }

        private void Patcher_Load(object sender, EventArgs e) {
            lblStatus.Text = "Reading Patch List....";
            string[] patches = ReadList(HOSTADDRESS);

            if (File.Exists("vpatchinfo.txt")) {
                using (FileStream fs = new FileStream("vpatchinfo.txt", FileMode.Open, FileAccess.Read)) {
                    StreamReader sr = new StreamReader(fs);
                    string[] prevPatches = sr.ReadToEnd().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int p = 0; p < patches.Length; p++) {
                        if (!prevPatches.Contains(patches[p])) {
                            neededPatches.Add(patches[p]);
                        }
                    }
                    sr.Close();
                }
            } else {
                for (int p = 0; p < patches.Length; p++) {
                    neededPatches.Add(patches[p]);
                }
            }
            if (neededPatches.Count > 0)
                new Thread(new ThreadStart(Patch)).Start();
            else {
                PatchDone();
            }
        }

        private void Patch() {
            SetText(lblStatus, "Reading File List....");
            for (int p = 0; p < neededPatches.Count; p++) {
                string patch = neededPatches[p];
                string[] fileList = ReadList(HOSTADDRESS + "/patches/" + patch + "/list.txt");

                for (int f = 0; f < fileList.Length; f++) {
                    string[] tokens = fileList[f].Split('\t');
                    string fileName = tokens[0];

                    if (tokens.Length < 3) {
                        filesToDownload.Add(patch + '/' + fileName, new string[] { tokens[1] /* File Path */ });
                    } else {
                        filesToDownload.Add(patch + '/' + fileName, new string[] { tokens[1] /* File Path */, tokens[2] /* Patch Target */ });
                    }
                }
            }

            SetText(lblStatus, "Downloaded " + downloadedFiles + " out of " + filesToDownload.Keys.Count + " files.");
            foreach (string fileName in filesToDownload.Keys) {
                mre.Reset();

                string[] fileTokens = fileName.Split('/');
                string filePatch = fileTokens[0];
                string rawFileName = fileTokens[1];
                string[] fileOptions = filesToDownload[fileName];
                destinationFile = fileOptions[0] + rawFileName;
                if (fileOptions.Length > 1) patchTarget = fileOptions[1];

                if (fileOptions[0] != string.Empty && !Directory.Exists(fileOptions[0]))
                    Directory.CreateDirectory(fileOptions[0]);

                var wc = new WebClient();
                wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                wc.DownloadFileAsync(new Uri(HOSTADDRESS + "/patches/" + filePatch + "/" + rawFileName), destinationFile, new string[] { rawFileName, filePatch });
                mre.WaitOne();
            }
        }

        private void MergeCompleted(object sender, EventArgs e) {
            SetText(lblDL, "GRF [" + destinationFile + "] successfully merged to [" + patchTarget + ']');
            if (File.Exists(destinationFile)) File.Delete(destinationFile);
            destinationFile = string.Empty;
            patchTarget = string.Empty;
            mre.Set();
        }

        private void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            if (patchTarget != string.Empty) {
                SetText(lblDL, "Merging GRF [" + destinationFile + "] to [" + patchTarget + ']');
                CreateProcess(MERGER, '"' + patchTarget + "\" \"" + destinationFile + '"', MergeCompleted);
            }

            downloadedFiles++;
            int patchPercentage = (int)(downloadedFiles / filesToDownload.Keys.Count * 100f);
            SetProgress(pbarPatch, patchPercentage);
            SetText(lblStatus, "[" + patchPercentage + "%] Downloaded " + downloadedFiles + " out of " + filesToDownload.Keys.Count + " files.");
            if (patchTarget == string.Empty) mre.Set();

            if (patchPercentage == 100) {
                PatchDone();
            }
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            string[] userToken = (string[])e.UserState;
            SetText(lblDL, "[" + e.ProgressPercentage + "%] Downloading " + userToken[0] + " from patch " + userToken[1] + "....");
            SetProgress(pbarDL, e.ProgressPercentage);
        }

        private string[] ReadList(string uri) {
            HttpWebRequest request = WebRequest.CreateHttp(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string result = sr.ReadToEnd();
            sr.Close();
            return result.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void SetText(Label lbl, string text) {
            if (lbl.InvokeRequired) {
                var d = new SetTextThreadSafe(SetText);
                lbl.Invoke(d, new object[] { lbl, text });
            } else {
                lbl.Text = text;
            }
        }

        private void SetProgress(ProgressBar pbar, int percentage) {
            if (pbar.InvokeRequired) {
                var d = new SetProgressThreadSafe(SetProgress);
                pbar.Invoke(d, new object[] { pbar, percentage });
            } else {
                pbar.Value = percentage;
            }
        }

        private void SetState(Button btn, bool state) {
            if (btn.InvokeRequired) {
                var d = new SetStateThreadSafe(SetState);
                btn.Invoke(d, new object[] { btn, state });
            } else {
                btn.Enabled = state;
                btn.Visible = state;
            }
        }

        private void PatchDone() {
            pbarDL.Value = 100;
            SetText(lblDL, string.Empty);
            pbarPatch.Value = 100;
            SetText(lblStatus, "Your client is up to date");

            if (neededPatches.Count > 0) {
                using (FileStream fs = new FileStream("vpatchinfo.txt", FileMode.Append, FileAccess.Write)) {
                    StreamWriter sr = new StreamWriter(fs);
                    for (int p = 0; p < neededPatches.Count; p++) {
                        sr.WriteLine(neededPatches[p]);
                    }
                    sr.Close();
                    fs.Close();
                }
            }
            SetState(btnPatchAll, true);
            SetState(btnStart, true);
        }

        private void btnStart_Click(object sender, EventArgs e) {
            CreateProcess(PROGRAM);
            Application.Exit();
        }

        private void btnPatchAll_Click(object sender, EventArgs e) {
            if (File.Exists("vpatchinfo.txt"))
                File.Delete("vpatchinfo.txt");

            btnPatchAll.Enabled = false;
            btnPatchAll.Visible = false;
            btnStart.Enabled = false;
            btnStart.Visible = false;
            neededPatches.Clear();
            filesToDownload.Clear();
            mre.Reset();
            pbarDL.Value = 0;
            pbarPatch.Value = 0;
            lblDL.Text = "Status";
            lblStatus.Text = "Status";
            downloadedFiles = 0;
            destinationFile = string.Empty;
            patchTarget = string.Empty;
            Patcher_Load(sender, e);
        }

        private void CreateProcess(string program) {
            Process proc = new Process();
            proc.StartInfo.FileName = program;
            proc.Start();
        }

        private void CreateProcess(string program, string args, EventHandler exited = null) {
            Process proc = new Process();
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.EnableRaisingEvents = true;
            proc.StartInfo.FileName = program;
            if (args != string.Empty) proc.StartInfo.Arguments = args;
            if (exited != null) proc.Exited += exited;
            proc.Start();
        }
    }
}
