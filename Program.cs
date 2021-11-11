using System;
using System.Drawing;
using System.IO;

namespace Image2ASCII
{

	class Program
	{


		public static string ConvertByte2Icon(byte pixel_grey_) 
		{

			if (pixel_grey_ < 18 * 1) { return " "; }
			if (pixel_grey_ < 18 * 2) { return "."; }
			if (pixel_grey_ < 18 * 3) { return ":"; }
			if (pixel_grey_ < 18 * 4) { return "-"; }
			if (pixel_grey_ < 18 * 5) { return "="; }
			if (pixel_grey_ < 18 * 6) { return "+"; }
			if (pixel_grey_ < 18 * 7) { return "*"; }
			if (pixel_grey_ < 18 * 8) { return "#"; }
			if (pixel_grey_ < 18 * 9) { return "%"; }
			if (pixel_grey_ < 18 * 10) { return "@"; }
			if (pixel_grey_ < 18 * 11) { return "░"; }
			if (pixel_grey_ < 18 * 12) { return "▒"; }
			if (pixel_grey_ < 18 * 13) { return "▓"; }
			else { return "█"; }
		}

		public static int GetScale(Bitmap bitmap_image_)
		{
			int escalado;
			for (escalado = 1; escalado < bitmap_image_.Height; escalado++)
			{
				if (bitmap_image_.Width / escalado > Console.WindowWidth)
				{
				}
				else { break; }
			}
			return escalado;
		}

		static void Main(string[] args)
		{

			FileStream raster = File.OpenRead("imagen.jpeg");
			var bitmap = new Bitmap(raster);
			raster.Close();


			int escala = GetScale(bitmap);

			for (int y = 0; y<bitmap.Height;y+=escala) 
			{
				for (int x = 0; x<bitmap.Width; x+=escala ) 
				{
					Color color = bitmap.GetPixel(x, y);
					byte escala_gris =Convert.ToByte( (color.R + color.G + color.B) / 3 ) ;
					Console.Write( ConvertByte2Icon(escala_gris) );
				}
				Console.Write("\n");
			}





		}
	}
}
