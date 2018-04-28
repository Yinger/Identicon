public BitmapSource GenerateIdenticon(Object value)
{
	int width = 9;
	int height = width;
	int stride = (PixelFormats.Indexed8.BitsPerPixel * width) / 8;
	byte[] pixels = new byte[height * stride];
	int hash = value.GetHashCode();
 
	BitmapPalette myPalette = new BitmapPalette(new Color[] { Colors.White, Colors.LightGray, Colors.LightSeaGreen, Colors.White });
 
	for (int y = 0; y < 5; ++y)
	 for (int x = y; x < 5; ++x)
	 {
	 	byte color = (byte)(hash & 0x03);
		hash >>= 2;
 
		// II quadrant
		pixels[x + (y * stride)] = color;
		pixels[y + (x * stride)] = color;
 
		// I quadrant
		pixels[(8 - x) + (y * stride)] = color;
		pixels[(8 - y) + (x * stride)] = color;
 
		// III quadrant
		pixels[x + ((8 - y) * stride)] = color;
		pixels[y + ((8 - x) * stride)] = color;
 
		// IV quadrant
		pixels[(8 - x) + ((8 - y) * stride)] = color;
		pixels[(8 - y) + ((8 - x) * stride)] = color;
	 }
 
	return BitmapSource.Create(width, height, 96, 96, PixelFormats.Indexed8, myPalette, pixels, stride);
}