using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace Consultorio.View.ManualDoUsuario
{
    /// <summary>
    /// Lógica interna para Ajuda.xaml
    /// </summary>
    public partial class Ajuda : Window
    {
        DispatcherTimer timer;
        bool isDragging = false;

        public Ajuda(string arquivo)
        {
            InitializeComponent();
            mePlayer.Source = new Uri("C:\\Users\\santo\\OneDrive\\Área de Trabalho\\Programa\\Consultorio\\Consultorio\\Consultorio\\View\\ManualDoUsuario\\Videos\\" + arquivo);
             timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += timer_Tick;
            mePlayer.Play();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (!isDragging)
                seekBar.Value = mePlayer.Position.TotalSeconds;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Stop();
        }
        
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            mePlayer.Volume = (double)volumeSlider.Value;
        }

        private void mePlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (mePlayer.NaturalDuration.HasTimeSpan)
            {
                TimeSpan ts = mePlayer.NaturalDuration.TimeSpan;
                seekBar.Maximum = ts.TotalSeconds;
                seekBar.SmallChange = 1;
                seekBar.LargeChange = Math.Min(10, ts.Seconds / 10);
            }
            timer.Start();
        }

        private void seekBar_DragStarted(object sender, DragStartedEventArgs e)
        {
            isDragging = true;
        }

        private void seekBar_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            isDragging = false;
            mePlayer.Position = TimeSpan.FromSeconds(seekBar.Value);
        }
    }
}
