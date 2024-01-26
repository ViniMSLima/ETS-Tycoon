using System.Windows.Forms;
using NAudio.Wave;

public class Sound
{
    private static WaveOut waveOut;
    private static WaveOutEvent MusicOutputDevice;
    private static WaveOutEvent SFXOutputDevice;
    private static AudioFileReader audioFile;

    public static void InitializeSounds()
    {
        if (waveOut == null)
        {
            WaveFileReader reader = new WaveFileReader("./soundtracks/And_so_it_begins.wav");
            LoopStream loop = new LoopStream(reader);
            waveOut = new WaveOut();
            waveOut.Init(loop);
            waveOut.Play();
        }
        else
        {
            waveOut.Stop();
            waveOut.Dispose();
            waveOut = null;
        }
    }

    public static void PlaySFX()
    {
        if (SFXOutputDevice == null)
        {
            SFXOutputDevice = new WaveOutEvent();
            SFXOutputDevice.PlaybackStopped += OnPlaybackStopped;
        }

        if (audioFile == null)
        {
            audioFile = new AudioFileReader("./soundtracks/Cash.wav");
            SFXOutputDevice.Init(audioFile);
        }

        SFXOutputDevice.Play();
    }

    public static void OnPlaybackStopped(object sender, StoppedEventArgs args)
    {
        SFXOutputDevice.Dispose();
        SFXOutputDevice = null;
        audioFile.Dispose();
        audioFile = null;
    }
}
