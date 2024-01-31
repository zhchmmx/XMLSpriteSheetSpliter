using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml;

namespace XMLSpriteSheetSpliter
{
    public class Spliter
    {
        public static void SplitAndSave(string xmlPath, string savePath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);
            XmlNode root = xmlDocument.DocumentElement;
            int SlashIndex = xmlPath.LastIndexOf('\\');
            string xmlFolderPath = xmlPath.Substring(0, SlashIndex + 1);
            string imagePath = xmlFolderPath + root.Attributes[0].Value;
            BitmapSource bitmapSource = new BitmapImage(new Uri(imagePath));
            foreach (XmlNode subTexture in root.ChildNodes)
            {
                string name = subTexture.Attributes["name"].Value;
                int x = Convert.ToInt32( subTexture.Attributes["x"].Value);
                int y = Convert.ToInt32(subTexture.Attributes["y"].Value);
                int width = Convert.ToInt32(subTexture.Attributes["width"].Value);
                int height = Convert.ToInt32(subTexture.Attributes["height"].Value);
                Int32Rect rect = new Int32Rect(x,y,width,height);
                BitmapSource cropped = new CroppedBitmap(bitmapSource,rect);
                BitmapEncoder bitmapEncoder = new PngBitmapEncoder();
                bitmapEncoder.Frames.Add(BitmapFrame.Create(cropped));
                using (var fileStream = new FileStream($"{savePath}\\{name}", FileMode.Create))
                {
                    bitmapEncoder.Save(fileStream);
                }
            }
        }
    }
}
