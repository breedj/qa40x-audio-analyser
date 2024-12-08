using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QA40x_AUDIO_ANALYSER
{
    public partial class frmMain : Form
    {
        public static Panel MeasurementPanel;

        public frmMain()
        {
            InitializeComponent();
            
        }

        public void Init()
        {
            MeasurementPanel = splitContainer1.Panel2;
            HideProgressBar();
            ClearMessage();
            LoadThdFrequencyForm();
        }

        private void btnMeasurement_ThdFreq_Click(object sender, EventArgs e)
        {
            LoadThdFrequencyForm();
        }

        private void btnMeasurement_ThdAmplitude_Click(object sender, EventArgs e)
        {
            LoadThdAmplitudeForm();
        }

        private void LoadThdFrequencyForm()
        {
            frmThdFreq frm = new frmThdFreq();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            MeasurementPanel.Controls.Clear();
            MeasurementPanel.Controls.Add(frm);
            frm.Show();
        }

        private void LoadThdAmplitudeForm()
        {
            frmThdAmplitude frm = new frmThdAmplitude();
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            MeasurementPanel.Controls.Clear();
            MeasurementPanel.Controls.Add(frm);
            frm.Show();
        }

        public void SetupProgressBar(int min, int max)
        {
            progressBar1.Minimum = min;
            progressBar1.Maximum = max;
            progressBar1.Value = min;
            progressBar1.Visible = false;
        }

        public void UpdateProgressBar(int value)
        {   
            progressBar1.Value = value;
            progressBar1.Visible = true;
        }

        public void HideProgressBar()
        {
            progressBar1.Visible = false;
        }

        public void ShowMessage(string message)
        {
            lbl_Message.Text = message;
        }

        public void ClearMessage()
        {
            lbl_Message.Text = "";
        }

       
    }
}
