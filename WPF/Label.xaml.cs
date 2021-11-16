using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
using System.ComponentModel;

namespace TESTWPF
{
    /// <summary>
    /// Interaction logic for Label.xaml
    /// </summary>
    public partial class Label : Page
    {
        public Label()
        {
            InitializeComponent();
            projectEntities db = new projectEntities();
            var wast = from w in db.labels
                       select w;

            List<string> labels = new List<string>();
            foreach (var item in wast)
            {

                labels.Add(item.Label_Name);

            }

            this.LabelBox.ItemsSource = new LabelData[]
            {
            new LabelData{Title=labels[0], ImageData = LoadImage(@"\1.png")},
            new LabelData{Title=labels[1], ImageData = LoadImage(@"\2.png")},
            new LabelData{Title=labels[2], ImageData = LoadImage(@"\3.png")},
            new LabelData{Title=labels[3], ImageData = LoadImage(@"\4.png")},
            new LabelData{Title=labels[4], ImageData = LoadImage(@"\5.png")},
            new LabelData{Title=labels[5], ImageData = LoadImage(@"\6.png")},
            new LabelData{Title=labels[6], ImageData = LoadImage(@"\7.png")},
            new LabelData{Title=labels[7], ImageData = LoadImage(@"\8.png")},
            new LabelData{Title=labels[8], ImageData = LoadImage(@"\17.png")},
            new LabelData{Title=labels[9], ImageData = LoadImage(@"\9.png")},
            new LabelData{Title=labels[10], ImageData = LoadImage(@"\10.png")},
            new LabelData{Title=labels[11], ImageData = LoadImage(@"\11.png")},
            new LabelData{Title=labels[12], ImageData = LoadImage(@"\12.png")},
            new LabelData{Title=labels[13], ImageData = LoadImage(@"\13.png")},
            new LabelData{Title=labels[14], ImageData = LoadImage(@"\14.png")},
            new LabelData{Title=labels[15], ImageData = LoadImage(@"\15.png")},
            new LabelData{Title=labels[16], ImageData = LoadImage(@"\16.png")}
            };
        }
        private BitmapImage LoadImage(string filename)
        {
            return new BitmapImage(new Uri(filename));
        }
    }

    public class LabelData
    {
        private string _Title;
        public string Title
        {
            get { return this._Title; }
            set { this._Title = value; }
        }

        private BitmapImage _ImageData;
        public BitmapImage ImageData
        {
            get { return this._ImageData; }
            set { this._ImageData = value; }
        }

    }
    
}
