using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TESTWPF
{
    /// <summary>
    /// Interaction logic for Label.xaml
    /// </summary>
    public partial class Label : Page
    {
        static projectEntities1 db = new projectEntities1();
        public Label()
        {
            InitializeComponent();

            List<string> labels = Label_List().Values.ToList();
            
            this.LabelBox.ItemsSource = new LabelData[]
            {
            new LabelData{Title=labels[0], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\1.png")},
            new LabelData{Title=labels[1], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\2.png")},
            new LabelData{Title=labels[2], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\3.png")},
            new LabelData{Title=labels[3], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\4.png")},
            new LabelData{Title=labels[4], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\5.png")},
            new LabelData{Title=labels[5], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\6.png")},
            new LabelData{Title=labels[6], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\7.png")},
            new LabelData{Title=labels[7], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\8.png")},
            new LabelData{Title=labels[8], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\17.png")},
            new LabelData{Title=labels[9], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\9.png")},
            new LabelData{Title=labels[10], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\10.png")},
            new LabelData{Title=labels[11], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\11.png")},
            new LabelData{Title=labels[12], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\12.png")},
            new LabelData{Title=labels[13], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\13.png")},
            new LabelData{Title=labels[14], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\14.png")},
            new LabelData{Title=labels[15], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\15.png")},
            new LabelData{Title=labels[16], ImageData = LoadImage(@"D:\3 КУРС\ПІ\Label\16.png")}
            };
        }

        static Dictionary<int, string> Label_List()
        {
            var wast = from w in db.label
                       select w;
            Dictionary<int, string> lbl = new Dictionary<int, string>();
            foreach (var item in wast)
            {
                lbl.Add(item.Label_ID, item.Label_Name);
            }

            return lbl;
        }
        private void OnClick(object sender, RoutedEventArgs e)
        {
            var keyword = (e.Source as Button).Content.ToString();

            IDictionary<int, string> lbl = Label_List();
            var wast = from w in db.waste
                       select w;

            var ws_lb = from rs in wast.ToList()
                        join r in lbl on rs.Label_ID equals r.Key
                        select new { Name = rs.Waste_Name, Value = r.Value };

            StringBuilder builder = new StringBuilder();
            foreach (var w in ws_lb)
            {
                if (keyword == w.Value)
                {
                    builder.AppendLine(w.Name);
                }
            }
            MessageBox.Show(builder.ToString());

        }
        private BitmapImage LoadImage(string filename)
        {
            return new BitmapImage(new Uri(filename));
        }
        //public BitmapImage LoadImage2(byte[] imageData)
        //{

        //    if (imageData == null || imageData.Length == 0) return null;
        //    var image = new BitmapImage();
        //    using (var mem = new MemoryStream(imageData))
        //    {
        //        mem.Position = 0;
        //        image.BeginInit();
        //        image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
        //        image.CacheOption = BitmapCacheOption.OnLoad;
        //        image.UriSource = null;
        //        image.StreamSource = mem;
        //        image.EndInit();

        //    }
        //    image.Freeze();
        //    return image;
        //}
        //public BitmapImage SetImageData(byte[] data)
        //{
        //    var source = new BitmapImage();
        //    source.BeginInit();
        //    source.StreamSource = new MemoryStream(data);
        //    source.EndInit();
        //    return source;
        //    // use public setter
        //    //ImageSource = source;
        //}
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
