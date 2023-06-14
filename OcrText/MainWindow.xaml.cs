using Microsoft.Win32;
using PaddleOCRSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OcrText
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "*.*|*.bmp;*.jpg;*.jpeg;*.tiff;*.tiff;*.png";
            ofd.ShowDialog();
            //if (ofd.ShowDialog() != ) return;

            var imagebyte = File.ReadAllBytes(ofd.FileName);
            Bitmap bitmap = new Bitmap(new MemoryStream(imagebyte));

            OCRModelConfig config = null;

            OCRParameter oCRParameter = new OCRParameter();

            OCRResult ocrResult = new OCRResult();

            using (PaddleOCREngine engine = new PaddleOCREngine(config, oCRParameter))

            {

                ocrResult = engine.DetectText(bitmap);
                text.Text = ocrResult.Text;

            }

            if (ocrResult != null)
            {

                MessageBox.Show(ocrResult.Text, "识别结果");

            }
        }
    }
}
