using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Path = System.IO.Path;


namespace RibbonWin
{
   
    public partial class MainWindow : RibbonWindow
    {
        public static class RenderVisualService
        {
            private const double defaultDpi = 96.0;

            public static ImageSource RenderToPNGImageSource(Visual targetControl)
            {
                var renderTargetBitmap = GetRenderTargetBitmapFromControl(targetControl);

                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

                var result = new BitmapImage();

                using (var memoryStream = new MemoryStream())
                {
                    encoder.Save(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    result.BeginInit();
                    result.CacheOption = BitmapCacheOption.OnLoad;
                    result.StreamSource = memoryStream;
                    result.EndInit();
                }

                return result;
            }

            public static void RenderToPNGFile(Visual targetControl, string filename)
            {
                var renderTargetBitmap = GetRenderTargetBitmapFromControl(targetControl);

                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

                var result = new BitmapImage();

                try
                {
                    using (var fileStream = new FileStream(filename, FileMode.Create))
                    {
                        encoder.Save(fileStream);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Blad z zapisem pliku: {ex.Message}");
                }
            }

            private static BitmapSource GetRenderTargetBitmapFromControl(Visual targetControl, double dpi = defaultDpi)
            {
                if (targetControl == null) return null;

                var bounds = VisualTreeHelper.GetDescendantBounds(targetControl);
                var renderTargetBitmap = new RenderTargetBitmap((int)(bounds.Width * dpi / 96.0),
                                                                (int)(bounds.Height * dpi / 96.0),
                                                                dpi,
                                                                dpi,
                                                                PixelFormats.Pbgra32);

                var drawingVisual = new DrawingVisual();

                using (var drawingContext = drawingVisual.RenderOpen())
                {
                    var visualBrush = new VisualBrush(targetControl);
                    drawingContext.DrawRectangle(visualBrush, null, new Rect(new Point(), bounds.Size));
                }

                renderTargetBitmap.Render(drawingVisual);
                return renderTargetBitmap;
            }
        }


        public MainWindow()
        {
            InitializeComponent();          
        }

       

       


        private void nowy_projekt_Click(object sender, RoutedEventArgs e)
        {
            pole_kartki.Visibility = Visibility.Visible;
            UIPanel.Background = Brushes.White;
            wzor.Visibility = Visibility.Visible;
            zyczenia.Visibility = Visibility.Visible;          
            Save.Visibility = Visibility.Visible;
            RibbonWin.IsMinimized = false;
            
        }

        private void wzor1_Click(object sender, RoutedEventArgs e)
        {     
            plotno.Background = wzor1.Background;

        }

        private void wzor2_Click(object sender, RoutedEventArgs e)
        {
            plotno.Background = wzor2.Background;
        }

        private void wzor3_Click(object sender, RoutedEventArgs e)
        {
            plotno.Background = wzor3.Background;
        }

        private void wzor4_Click(object sender, RoutedEventArgs e)
        {
            plotno.Background = wzor4.Background;
        }

        private void wzor5_Click(object sender, RoutedEventArgs e)
        {
            plotno.Background = wzor5.Background;
        }

        private void wzor6_Click(object sender, RoutedEventArgs e)
        {
            plotno.Background = wzor6.Background;
        }

        private void wzor7_Click(object sender, RoutedEventArgs e)
        {
            plotno.Background = wzor7.Background;
        }

        private void wzor8_Click(object sender, RoutedEventArgs e)
        {
            plotno.Background = wzor8.Background;
        }

        private void wzor9_Click(object sender, RoutedEventArgs e)
        {
            plotno.Background = wzor9.Background;
        }

        private void wzor10_Click(object sender, RoutedEventArgs e)
        {
            plotno.Background = wzor10.Background;
        }

       

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            RenderVisualService.RenderToPNGFile(pole_kartki, "obrazek.png");

        }

        private void przycisk_bialy_Click(object sender, RoutedEventArgs e)
        {
            Box.Foreground = Brushes.White;
        }

        private void przycisk_czarny_Click(object sender, RoutedEventArgs e)
        {
            Box.Foreground = Brushes.Black;
        }

        private void przycisk_czerwony_Click(object sender, RoutedEventArgs e)
        {
            Box.Foreground = Brushes.Red;
        }

        private void przycisk_zolty_Click(object sender, RoutedEventArgs e)
        {
            Box.Foreground = Brushes.Yellow;
        }

        private void przycisk_zielony_Click(object sender, RoutedEventArgs e)
        {
            Box.Foreground = Brushes.Green;
        }

        private void przycisk_niebieski_Click(object sender, RoutedEventArgs e)
        {
            Box.Foreground = Brushes.Blue;
        }

        private void przycisk_fioletowy_Click(object sender, RoutedEventArgs e)
        {
            Box.Foreground = Brushes.Violet;
        }

        private void przycisk_rozowy_Click(object sender, RoutedEventArgs e)
        {
            Box.Foreground = Brushes.DeepPink;
        }
    }
    
}
