# Video Player
## C# with .NET 10

A super-simple one-class Windows Forms desktop app for people getting started with video rendering.

<img width="793" height="557" alt="image" src="https://github.com/user-attachments/assets/a243d3d0-30d6-4600-90d4-3d2d6771fe9c" />

*Figure 1 - VideoPlayer in action.*

The app can handle the most common video file types, including:

* .mp4 (both H.264 and H.265)
* .mov (Apple QuickTime)
* .wmv (Windows Media Video)

With VideoPlayer, you first open a video file, then use the various control buttons to play it.
The heavy lifting is handled by the MediaPlayer that comes not with Windows Forms but with Windows Presentation Foundation (WPF). In order to include the player
in a Windows Forms app, you need to enable WPF in the .csproj project file:

<img width="431" height="246" alt="image" src="https://github.com/user-attachments/assets/cdabc3c0-3d37-4ebe-b35f-539a733153eb" />

*Figure 2 - Enabling WPF support in a Windows Forms project file.*

## The UI Layout

The UI is laid out using a series of docked panels, as shown in the following figure.

<img width="712" height="533" alt="image" src="https://github.com/user-attachments/assets/127c06e3-3fa1-4e67-8aa0-e635dc16a7ec" />

*Figure 3 - Using panels to layout the user interface.*

When laying out docked panels, their order (back to front) is important. The first panel added in the Visual Studio Visual Designer is the backmost.
Additional panels appear on top of panels already added. With top-docked panels, the first one goes to the top, the second one docks right under it.
Conversely, for bottom-docked panels the first one goes to the bottom, the second one docks right over it, and so on.
The panel with Dock=Fill, which contains the list of songs, needs to be the front-most panel. You either must add it last, or you can use the
"Bring to Front" button in the Visual Studio.

## Rendering Video

The WPF MediaPlayer component is capable of handling both audio and video files. With audio files, it handles the actual playing. With video files, it needs
additional support to paint the decoded video frames on a Windows Forms rendering surface. The full video pipeline requires three main components:

* *MediaPlayer.* A WPF component that loads, decodes and plays video files. It doesn't have a rendering surface.
* *VideoDrawing.* A WPF component that provides a rendering surface for the decoded frames from MediaPlayer.
* *Element Host.* A WinForms component that provides a bridge between WPF and Windows Forms.

The components form a tree that looks something like this:

```
WinForms Form panel
     └─ ElementHost (WinForms control capable of hosting WPF content)
        └─ WPF element tree (e.g., a Rectangle)
            └─ Fill = DrawingBrush
                └─ Drawing = VideoDrawing
                    └─ Player = MediaPlayer  ← decodes/drives playback
```

The following listing shows the code necessary for the video pipeline.

 ```csharp
public partial class FormMain : Form
 {
   readonly System.Windows.Forms.Integration.ElementHost elementHostVideo = new();
   readonly System.Windows.Media.MediaPlayer player = new();
   readonly System.Windows.Media.VideoDrawing videoDrawing = new();
   //...
   
   public FormMain()
   {
     InitializeComponent();
     //...

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
```

*Listing 1 - The code that sets up the complete video pipeline.*

## Using Font Symbols for the video control buttons

A note regarding the symbols on the play buttons. Once upon a time we would have needed to import them as bitmaps into the project and add them as embedded resources.
All that complication is avoided by using the symbols as font characters. Several fonts include media player symbols. You can lookup symbols on the web or simply use the
Character Map app, which is built into Windows itself. Below are the symbols we need, with their Unicode values.

⏪  U+23EA: Skip back

▶   U+25B6: Play

⏸  U+23F8: Pause

⏹  U+23F9: Stop

⏩  U+23E9: Skip forward

The figure below shows the use of Windows Character Map to do the looking up.

<img width="476" height="507" alt="image" src="https://github.com/user-attachments/assets/0493fe9c-995a-4884-a421-39c1af5ebbef" />

*Figure 4 - Using the Windows Character Map to find symbols used in VideoPlayer.*

## Closing Notes

* *Codecs.* The WPF MediaPlayer is shipped with the most common codecs included. Additional codecs can be downloaded from the Windows Media Foundation.
* *Performance.* The player is designed for ease-of-use, not high-performance. It handles video decoding in software rather than using hardware acceleration.
* *Audio Support.* The player supports audio. If you open an audio file in VideoPlayer, the video panel will just remain black.
