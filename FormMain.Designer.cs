namespace VideoPlayerWinForms
{
  partial class FormMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();
      panelVolume = new Panel();
      trackBarVolume = new TrackBar();
      label2 = new Label();
      panelControls = new Panel();
      buttonSkipForward = new Button();
      buttonStop = new Button();
      buttonPlayPause = new Button();
      buttonSkipBack = new Button();
      buttonOpenFiles = new Button();
      panelSeeker = new Panel();
      labelTime = new Label();
      trackBarSeek = new TrackBar();
      panelVideo = new Panel();
      timerPosition = new System.Windows.Forms.Timer(components);
      openFileDialog = new OpenFileDialog();
      toolTip = new ToolTip(components);
      panelNowPlaying = new Panel();
      labelNowPlaying = new Label();
      panelVolume.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)trackBarVolume).BeginInit();
      panelControls.SuspendLayout();
      panelSeeker.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)trackBarSeek).BeginInit();
      panelNowPlaying.SuspendLayout();
      SuspendLayout();
      // 
      // panelVolume
      // 
      panelVolume.BackColor = Color.FromArgb(30, 30, 30);
      panelVolume.Controls.Add(trackBarVolume);
      panelVolume.Controls.Add(label2);
      panelVolume.Dock = DockStyle.Bottom;
      panelVolume.Location = new Point(0, 480);
      panelVolume.Name = "panelVolume";
      panelVolume.Size = new Size(791, 45);
      panelVolume.TabIndex = 2;
      // 
      // trackBarVolume
      // 
      trackBarVolume.Location = new Point(65, 10);
      trackBarVolume.Maximum = 100;
      trackBarVolume.Name = "trackBarVolume";
      trackBarVolume.Size = new Size(723, 45);
      trackBarVolume.TabIndex = 1;
      toolTip.SetToolTip(trackBarVolume, "Audio volume");
      trackBarVolume.Value = 40;
      trackBarVolume.ValueChanged += TrackBarVolume_ValueChanged;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.ForeColor = Color.White;
      label2.Location = new Point(12, 10);
      label2.Name = "label2";
      label2.Size = new Size(47, 15);
      label2.TabIndex = 0;
      label2.Text = "Volume";
      // 
      // panelControls
      // 
      panelControls.BackColor = Color.FromArgb(30, 30, 30);
      panelControls.Controls.Add(buttonSkipForward);
      panelControls.Controls.Add(buttonStop);
      panelControls.Controls.Add(buttonPlayPause);
      panelControls.Controls.Add(buttonSkipBack);
      panelControls.Controls.Add(buttonOpenFiles);
      panelControls.Dock = DockStyle.Bottom;
      panelControls.Location = new Point(0, 434);
      panelControls.Name = "panelControls";
      panelControls.Size = new Size(791, 46);
      panelControls.TabIndex = 3;
      // 
      // buttonSkipForward
      // 
      buttonSkipForward.BackColor = Color.FromArgb(45, 45, 45);
      buttonSkipForward.FlatAppearance.BorderColor = Color.Gray;
      buttonSkipForward.FlatStyle = FlatStyle.Flat;
      buttonSkipForward.Font = new Font("Segoe UI", 14.25F);
      buttonSkipForward.ForeColor = Color.Cyan;
      buttonSkipForward.Location = new Point(344, 4);
      buttonSkipForward.Name = "buttonSkipForward";
      buttonSkipForward.Size = new Size(57, 35);
      buttonSkipForward.TabIndex = 6;
      buttonSkipForward.Text = "⏩";
      toolTip.SetToolTip(buttonSkipForward, "Skip Forward 5 Minutes");
      buttonSkipForward.UseVisualStyleBackColor = false;
      buttonSkipForward.Click += ButtonSkipForward_Click;
      // 
      // buttonStop
      // 
      buttonStop.BackColor = Color.FromArgb(45, 45, 45);
      buttonStop.FlatAppearance.BorderColor = Color.Gray;
      buttonStop.FlatStyle = FlatStyle.Flat;
      buttonStop.Font = new Font("Segoe UI", 14.25F);
      buttonStop.ForeColor = Color.Cyan;
      buttonStop.Location = new Point(283, 4);
      buttonStop.Name = "buttonStop";
      buttonStop.Size = new Size(57, 35);
      buttonStop.TabIndex = 5;
      buttonStop.Text = "⏹";
      toolTip.SetToolTip(buttonStop, "Stop");
      buttonStop.UseVisualStyleBackColor = false;
      buttonStop.Click += ButtonStop_Click;
      // 
      // buttonPlayPause
      // 
      buttonPlayPause.BackColor = Color.FromArgb(45, 45, 45);
      buttonPlayPause.FlatAppearance.BorderColor = Color.Gray;
      buttonPlayPause.FlatStyle = FlatStyle.Flat;
      buttonPlayPause.Font = new Font("Segoe UI", 14.25F);
      buttonPlayPause.ForeColor = Color.Cyan;
      buttonPlayPause.Location = new Point(221, 3);
      buttonPlayPause.Name = "buttonPlayPause";
      buttonPlayPause.Size = new Size(57, 35);
      buttonPlayPause.TabIndex = 4;
      buttonPlayPause.Text = "▶";
      toolTip.SetToolTip(buttonPlayPause, "Play/Pause");
      buttonPlayPause.UseVisualStyleBackColor = false;
      buttonPlayPause.Click += ButtonPlayPause_Click;
      // 
      // buttonSkipBack
      // 
      buttonSkipBack.BackColor = Color.FromArgb(45, 45, 45);
      buttonSkipBack.FlatAppearance.BorderColor = Color.Gray;
      buttonSkipBack.FlatStyle = FlatStyle.Flat;
      buttonSkipBack.Font = new Font("Segoe UI", 14.25F);
      buttonSkipBack.ForeColor = Color.Cyan;
      buttonSkipBack.Location = new Point(159, 3);
      buttonSkipBack.Name = "buttonSkipBack";
      buttonSkipBack.Size = new Size(57, 35);
      buttonSkipBack.TabIndex = 1;
      buttonSkipBack.Text = "⏪";
      toolTip.SetToolTip(buttonSkipBack, "Skip Back  5 Minutes");
      buttonSkipBack.UseVisualStyleBackColor = false;
      buttonSkipBack.Click += ButtonSkipBack_Click;
      // 
      // buttonOpenFiles
      // 
      buttonOpenFiles.BackColor = Color.FromArgb(45, 45, 45);
      buttonOpenFiles.FlatAppearance.BorderColor = Color.Gray;
      buttonOpenFiles.FlatStyle = FlatStyle.Flat;
      buttonOpenFiles.ForeColor = Color.White;
      buttonOpenFiles.Location = new Point(11, 3);
      buttonOpenFiles.Name = "buttonOpenFiles";
      buttonOpenFiles.Size = new Size(106, 35);
      buttonOpenFiles.TabIndex = 0;
      buttonOpenFiles.Text = "Select Video...";
      toolTip.SetToolTip(buttonOpenFiles, "Open a video file on your computer");
      buttonOpenFiles.UseVisualStyleBackColor = false;
      buttonOpenFiles.Click += ButtonOpenFiles_Click;
      // 
      // panelSeeker
      // 
      panelSeeker.BackColor = Color.FromArgb(30, 30, 30);
      panelSeeker.Controls.Add(labelTime);
      panelSeeker.Controls.Add(trackBarSeek);
      panelSeeker.Dock = DockStyle.Bottom;
      panelSeeker.Location = new Point(0, 384);
      panelSeeker.Name = "panelSeeker";
      panelSeeker.Size = new Size(791, 50);
      panelSeeker.TabIndex = 5;
      // 
      // labelTime
      // 
      labelTime.AutoSize = true;
      labelTime.ForeColor = Color.White;
      labelTime.Location = new Point(715, 17);
      labelTime.Name = "labelTime";
      labelTime.Size = new Size(72, 15);
      labelTime.TabIndex = 3;
      labelTime.Text = "00:00 / 00:00";
      // 
      // trackBarSeek
      // 
      trackBarSeek.Location = new Point(12, 15);
      trackBarSeek.Name = "trackBarSeek";
      trackBarSeek.Size = new Size(701, 45);
      trackBarSeek.TabIndex = 2;
      toolTip.SetToolTip(trackBarSeek, "Video playing location");
      trackBarSeek.MouseDown += TrackBarSeek_MouseDown;
      trackBarSeek.MouseUp += TrackBarSeek_MouseUp;
      // 
      // panelVideo
      // 
      panelVideo.BackColor = Color.Black;
      panelVideo.Dock = DockStyle.Fill;
      panelVideo.Location = new Point(0, 0);
      panelVideo.Name = "panelVideo";
      panelVideo.Size = new Size(791, 384);
      panelVideo.TabIndex = 6;
      // 
      // timerPosition
      // 
      timerPosition.Interval = 250;
      timerPosition.Tick += TimerPosition_Tick;
      // 
      // openFileDialog
      // 
      openFileDialog.Filter = "Video files (*.mp4;*.wmv;*.avi;*.mov;*.mpg;*.mpeg)|*.mp4;*.wmv;*.avi;*.mov;*.mpg;*.mpeg|All files (*.*)|*.*";
      openFileDialog.Title = "Choose Video Files";
      // 
      // panelNowPlaying
      // 
      panelNowPlaying.Controls.Add(labelNowPlaying);
      panelNowPlaying.Dock = DockStyle.Top;
      panelNowPlaying.Location = new Point(0, 0);
      panelNowPlaying.Name = "panelNowPlaying";
      panelNowPlaying.Size = new Size(791, 32);
      panelNowPlaying.TabIndex = 7;
      // 
      // labelNowPlaying
      // 
      labelNowPlaying.BackColor = Color.FromArgb(30, 30, 30);
      labelNowPlaying.Dock = DockStyle.Fill;
      labelNowPlaying.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
      labelNowPlaying.ForeColor = Color.White;
      labelNowPlaying.Location = new Point(0, 0);
      labelNowPlaying.Name = "labelNowPlaying";
      labelNowPlaying.Size = new Size(791, 32);
      labelNowPlaying.TabIndex = 0;
      labelNowPlaying.Text = "Now Playing";
      labelNowPlaying.TextAlign = ContentAlignment.MiddleLeft;
      // 
      // FormMain
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(791, 525);
      Controls.Add(panelNowPlaying);
      Controls.Add(panelVideo);
      Controls.Add(panelSeeker);
      Controls.Add(panelControls);
      Controls.Add(panelVolume);
      MinimumSize = new Size(400, 300);
      Name = "FormMain";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Video Player";
      panelVolume.ResumeLayout(false);
      panelVolume.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)trackBarVolume).EndInit();
      panelControls.ResumeLayout(false);
      panelSeeker.ResumeLayout(false);
      panelSeeker.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)trackBarSeek).EndInit();
      panelNowPlaying.ResumeLayout(false);
      ResumeLayout(false);
    }

    #endregion
    private Panel panelVolume;
    private Panel panelControls;
    private TrackBar trackBarVolume;
    private Label label2;
    private Button buttonSkipForward;
    private Button buttonStop;
    private Button buttonPlayPause;
    private Button buttonSkipBack;
    private Button buttonOpenFiles;
    private Panel panelSeeker;
    private Label labelTime;
    private TrackBar trackBarSeek;
    private Panel panelVideo;
    private System.Windows.Forms.Timer timerPosition;
    private OpenFileDialog openFileDialog;
    private ToolTip toolTip;
    private Panel panelNowPlaying;
    private Label labelNowPlaying;
  }
}