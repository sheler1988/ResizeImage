
// این کد به طور کلی یک روش مؤثر برای تغییر اندازه تصاویر با کیفیت بالا در سی‌شارپ ارائه می‌دهد

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ResizeImage.Services;

public class ImageTools // ImageTools کلاس
{
	// متدی که یک تصویر و عرض هدف را به عنوان ورودی دریافت می‌کند
	public Image ResizeImage(Image original, int targetWidth)
	{
		// محاسبه ابعاد جدید تصویر
		//درصد تغییر اندازه محاسبه می‌شود. سپس عرض  و ارتفاع  جدید تصویر با حفظ نسبت ابعاد اصلی تصویر محاسبه می‌شوند
		var percent = (double)original.Width / targetWidth;
		var destWidth = (int)(original.Width / percent);
		var destHeight = (int)(original.Height / percent);

		// ایجاد یک تصویر جدید با اندازه تغییر یافته
		// یک شیء جدید از نوع بیت مپ با اندازه جدید ایجاد می‌کند و یک شیء کرافیکس برای رسم در آن ایجاد می‌کند
		var b = new Bitmap(destWidth, destHeight);
		var g = Graphics.FromImage(b);
		try
		{
			// تنظیمات کرافیکی برای بهبود کیفیت تغییر اندازه
			// این تنظیمات کرافیکی برای اطمینان از کیفیت بالا هنکام تغییر اندازه تصویر استفاده می‌شود
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.CompositingQuality = CompositingQuality.HighQuality;

			// رسم تصویر تغییر اندازه یافته
			// تصویر اصلی با اندازه جدید رسم می‌شود
			g.DrawImage(original, 0, 0, destWidth, destHeight);
		}
		finally
		{
			g.Dispose();
		}
		// برکشت تصویر تغییر اندازه یافته
		return b;
	}
}
