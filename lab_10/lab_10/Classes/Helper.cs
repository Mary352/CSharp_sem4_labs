using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace lab_10.Classes
{
    static class Helper
    {
        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }

        public static byte[] ConvertImageIntoBytes(string iFile)
        {
            // конвертация изображения в байты
            byte[] imageData = null;
            FileInfo fInfo = new FileInfo(iFile);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(iFile, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            imageData = br.ReadBytes((int)numBytes);
            return imageData;
            //// получение расширения файла изображения не забыв удалить точку перед расширением
            //string iImageExtension = "jpg";
            ////(Path.GetExtension(iFile)).Replace(".", "").ToLower();
            //// запись изображения в БД
            //using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS; Initial Catalog=dbtest;Integrated Security=True")) // строка подключения к БД
            //{
            //    string commandText = "INSERT INTO report (screen, screen_format) VALUES(@screen, @screen_format)"; // запрос на вставку
            //    SqlCommand command = new SqlCommand(commandText, sqlConnection);
            //    command.Parameters.AddWithValue("@screen", (object)imageData); // записываем само изображение
            //    command.Parameters.AddWithValue("@screen_format", iImageExtension); // записываем расширение изображения
            //    sqlConnection.Open();
            //    command.ExecuteNonQuery();
            //    sqlConnection.Close();
            //}
        }



        public static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
    }
}
