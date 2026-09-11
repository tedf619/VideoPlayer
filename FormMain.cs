namespace VideoPlayerWinForms
{
  public partial class FormMain : Form
  {
    readonly System.Windows.Forms.Integration.ElementHost elementHostVideo = new();
    readonly System.Windows.Media.MediaPlayer player = new();
    readonly System.Windows.Media.VideoDrawing videoDrawing = new();
    bool isPlaying, isDraggingSeek;
    TimeSpan duration;

    public FormMain()
    {
      InitializeComponent();

      player.MediaOpened += Player_MediaOpened;
      player.MediaEnded += Player_MediaEnded;
      player.MediaFailed += Player_MediaFailed;

      videoDrawing.Player = player;

      elementHostVideo.Dock = DockStyle.Fill;
      elementHostVideo.BackColorTransparent = false;
      elementHostVideo.BackColor = Color.Black;

      // add video player surface using a WPF Grid and Image control

      var videoRoot = new System.Windows.Controls.Grid();
      videoRoot.Background = System.Windows.Media.Brushes.Black;

      var videoImage = new System.Windows.Controls.Image();
      videoImage.Stretch = System.Windows.Media.Stretch.Uniform;
      videoImage.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
      videoImage.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
      videoImage.Source = new System.Windows.Media.DrawingImage(videoDrawing);

      videoRoot.Children.Add(videoImage);
      elementHostVideo.Child = videoRoot;

      panelVideo.Controls.Add(elementHostVideo);
    }

    void ButtonOpenFiles_Click(object? sender, EventArgs e)
    {
      if (openFileDialog.ShowDialog() != DialogResult.OK) return;

      player.Open(new Uri(openFileDialog.FileName));
      labelNowPlaying.Text = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);

      UpdatePlayPauseState(isNowPlaying: true);
    }

    void ButtonSkipBack_Click(object sender, EventArgs e)
    {
      TimeSpan newSeekPosition = TimeSpan.FromSeconds(trackBarSeek.Value - 300);
      if (newSeekPosition.TotalSeconds < 0)
        newSeekPosition = TimeSpan.Zero;

      player.Position = newSeekPosition;
      UpdateTrackBarSeekPosition();
    }

    void ButtonPlayPause_Click(object? sender, EventArgs e)
    {
      if (player.Source == null) return;
      UpdatePlayPauseState(!isPlaying);
    }

    void ButtonStop_Click(object? sender, EventArgs e)
    {
      player.Stop();
      player.Position = TimeSpan.Zero;
      UpdatePlayPauseState(isNowPlaying: false);
      UpdateTrackBarSeekPosition();
    }

    void ButtonSkipForward_Click(object sender, EventArgs e)
    {
      TimeSpan newSeekPosition = TimeSpan.FromSeconds(trackBarSeek.Value + 300);
      if (newSeekPosition.TotalSeconds > trackBarSeek.Maximum) return;

      player.Position = newSeekPosition;
      UpdateTrackBarSeekPosition();
    }

    void TrackBarVolume_ValueChanged(object sender, EventArgs e)
    {
      player.Volume = trackBarVolume.Value / 100.0;
    }

    void Player_MediaOpened(object? sender, EventArgs e)
    {
      duration = player.NaturalDuration.HasTimeSpan ? player.NaturalDuration.TimeSpan : TimeSpan.Zero;

      if (player.NaturalDuration.HasTimeSpan)
        trackBarSeek.Maximum = Math.Max(1, (int)duration.TotalSeconds);

      // scale image to maintain proper aspect ratio
      int width = player.NaturalVideoWidth > 0 ? player.NaturalVideoWidth : 640;
      int height = player.NaturalVideoHeight > 0 ? player.NaturalVideoHeight : 360;
      videoDrawing.Rect = new System.Windows.Rect(0, 0, width, height);
    }

    void Player_MediaEnded(object? sender, EventArgs e)
    {
      player.Stop();
      isPlaying = false;
      buttonPlayPause.Text = "▶";
      timerPosition.Stop();
      trackBarSeek.Value = 0;
    }

    void Player_MediaFailed(object? sender, System.Windows.Media.ExceptionEventArgs e)
    {
      MessageBox.Show($"Could not play this file:\n{e.ErrorException.Message}",
                       "Playback error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    void TrackBarSeek_MouseDown(object? sender, MouseEventArgs e)
    {
      isDraggingSeek = true;
    }

    void TrackBarSeek_MouseUp(object? sender, MouseEventArgs e)
    {
      isDraggingSeek = false;
      if (player.Source == null) return;

      player.Position = TimeSpan.FromSeconds(trackBarSeek.Value);
      UpdateTrackBarSeekPosition();
    }

 
    void TimerPosition_Tick(object? sender, EventArgs e)
    {
      if (isDraggingSeek || player.Source == null) return;
      UpdateTrackBarSeekPosition();
    }

    void UpdateTrackBarSeekPosition()
    {
      var position = player.Position;

      int seconds = (int)position.TotalSeconds;
      if (seconds <= trackBarSeek.Maximum)
        trackBarSeek.Value = seconds;

      labelTime.Text = $"{FormatTime(position)} / {FormatTime(duration)}";
    }

    string FormatTime(TimeSpan time) => time.ToString(@"h\:mm\:ss");

    void UpdatePlayPauseState(bool isNowPlaying)
    {
      isPlaying = isNowPlaying;

      if (isNowPlaying)
      {
        player.Play();
        isPlaying = true;
        buttonPlayPause.Text = "⏸";
        timerPosition.Start();
      }
      else
      {
        player.Pause();
        isPlaying = false;
        buttonPlayPause.Text = "▶";
        timerPosition.Stop();
      }
    }
  }
}
