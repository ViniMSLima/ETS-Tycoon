using System;
using System.Windows.Forms;
using Extension;
using NAudio.Wave;

namespace EtsTycoon
{
    public class Sound
    {
        private static WaveOut waveOut;
        private static WaveOutEvent SFX1OutputDevice;
        private static WaveOutEvent SFX2OutputDevice;
        private static AudioFileReader audioFile;
        private static AudioFileReader audioFile2;

        public static String[] Audios { get; set; } = {
        "./soundtracks/Cash.wav",
        "./soundtracks/Rizz.wav",
        "./soundtracks/Horn.wav",
        "./soundtracks/OpenStore.wav"
    };

        public static void StartMusic()
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

        public static void PlaySFX1(int a)
        {
            if (SFX1OutputDevice == null)
            {
                SFX1OutputDevice = new WaveOutEvent();
                SFX1OutputDevice.PlaybackStopped += OnPlaybackStopped1;
            }

            if (audioFile == null)
            {
                audioFile = new(Audios[a]);
                SFX1OutputDevice.Init(audioFile);
            }
            audioFile.Position = 0;
            SFX1OutputDevice.Play();
        }

        public static void OnPlaybackStopped1(object sender, StoppedEventArgs args)
        {
            SFX1OutputDevice.Dispose();
            SFX1OutputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }

        public static void PlaySFX2(int a)
        {
            if (SFX2OutputDevice == null)
            {
                SFX2OutputDevice = new WaveOutEvent();
                SFX2OutputDevice.PlaybackStopped += OnPlaybackStopped2;
            }

            if (audioFile2 == null)
            {
                audioFile2 = new(Audios[a]);
                SFX2OutputDevice.Init(audioFile2);
            }
            audioFile2.Position = 0;
            SFX2OutputDevice.Play();
        }

        public static void OnPlaybackStopped2(object sender, StoppedEventArgs args)
        {
            SFX2OutputDevice.Dispose();
            SFX2OutputDevice = null;
            audioFile2.Dispose();
            audioFile2 = null;
        }

        public static void PlaySFX3(int a)
        {
            if (SFX2OutputDevice == null)
            {
                SFX2OutputDevice = new WaveOutEvent();
                SFX2OutputDevice.PlaybackStopped += OnPlaybackStopped3;
            }

            if (audioFile2 == null)
            {
                audioFile2 = new(Audios[a]);
                SFX2OutputDevice.Init(audioFile2);
            }
            audioFile2.Position = 0;
            SFX2OutputDevice.Play();
        }

        public static void OnPlaybackStopped3(object sender, StoppedEventArgs args)
        {
            SFX2OutputDevice.Dispose();
            SFX2OutputDevice = null;
            audioFile2.Dispose();
            audioFile2 = null;
        }
    }
}
