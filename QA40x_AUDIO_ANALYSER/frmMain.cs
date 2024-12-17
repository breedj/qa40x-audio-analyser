using QaControl;
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

        private static ThdFrequencyMeasurementData ThdFrequencyData = new();

        private static ThdAmplitudeMeasurementData ThdAmplitudeData = new();

        frmThdAmplitude frmThdAmplitude;

        frmThdFrequency frmThdFrequency;

        public frmMain()
        {
            InitializeComponent();
            
        }

        public void Init()
        {
            MeasurementPanel = splitContainer1.Panel2;
            HideProgressBar();
            ClearMessage();
            ShowThdFrequencyForm();
        }

        private void btnMeasurement_ThdFreq_Click(object sender, EventArgs e)
        {
            if (MeasurementPanel.Controls.Count > 0)
            {
                Form frm = (Form)MeasurementPanel.Controls[0];
                if (frm != null && frm is frmThdAmplitude)
                {
                    if (((frmThdAmplitude)frm).MeasurementBusy)
                        return;
                }
            }
            ShowThdFrequencyForm();
            btnMeasurement_ThdFreq.Font = new Font(btnMeasurement_ThdFreq.Font, FontStyle.Bold);
            btnMeasurement_ThdAmplitude.Font = new Font(btnMeasurement_ThdAmplitude.Font, FontStyle.Regular);
        }

        private void btnMeasurement_ThdAmplitude_Click(object sender, EventArgs e)
        {
            if (MeasurementPanel.Controls.Count > 0)
            {
                Form frm = (Form)MeasurementPanel.Controls[0];
                if (frm != null && frm is frmThdFrequency)
                {
                    if (((frmThdFrequency)frm).MeasurementBusy)
                        return;
                }
            }
            ShowThdAmplitudeForm();
            btnMeasurement_ThdFreq.Font = new Font(btnMeasurement_ThdFreq.Font, FontStyle.Regular);
            btnMeasurement_ThdAmplitude.Font = new Font(btnMeasurement_ThdAmplitude.Font, FontStyle.Bold);
        }

        private void ShowThdFrequencyForm()
        {
            if (frmThdFrequency == null)
            {
                frmThdFrequency = new frmThdFrequency(ref ThdFrequencyData);
                frmThdFrequency.Dock = DockStyle.Fill;
                frmThdFrequency.TopLevel = false;
            }
            MeasurementPanel.Controls.Clear();
            MeasurementPanel.Controls.Add(frmThdFrequency);
            frmThdFrequency.Show();
        }

        private void ShowThdAmplitudeForm()
        {
            if (frmThdAmplitude == null)
            {
                frmThdAmplitude = new frmThdAmplitude(ref ThdAmplitudeData);
                frmThdAmplitude.Dock = DockStyle.Fill;
                frmThdAmplitude.TopLevel = false;    
            }
            MeasurementPanel.Controls.Clear();
            MeasurementPanel.Controls.Add(frmThdAmplitude);
            frmThdAmplitude.Show();
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

        public async Task ShowMessage(string message, int delay = 0)
        {
            lbl_Message.Text = message;
            if (delay > 0) 
                await Task.Delay(delay);
        }

        public void ClearMessage()
        {
            lbl_Message.Text = "";
        }

       
    }
}
