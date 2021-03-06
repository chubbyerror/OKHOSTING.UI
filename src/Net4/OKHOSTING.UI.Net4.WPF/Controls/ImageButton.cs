﻿using System;
using System.IO;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class ImageButton : Image, IImageButton
	{
		public ImageButton()
		{
			InnerImage.MouseUp += InnerImage_MouseUp;
		}

		public event EventHandler Click;

		private void InnerImage_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Click?.Invoke(this, e);
		}
	}
}