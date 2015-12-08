﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Net4.WPF.Controls.Layouts
{
	public class Grid : System.Windows.Controls.Grid, IGrid
	{
		public Grid()
		{
		}

		public int ColumnCount
		{
			get
			{
				return base.ColumnDefinitions.Count;
			}
			set
			{
				while (base.ColumnDefinitions.Count < value)
				{
					base.ColumnDefinitions.Add(new System.Windows.Controls.ColumnDefinition());
				}

				while (base.ColumnDefinitions.Count > value)
				{
					base.ColumnDefinitions.RemoveAt(base.ColumnDefinitions.Count - 1);
				}
			}
		}

		public int RowCount
		{
			get
			{
				return base.RowDefinitions.Count;
			}
			set
			{
				while (base.RowDefinitions.Count < value)
				{
					base.RowDefinitions.Add(new System.Windows.Controls.RowDefinition());
				}

				while (base.RowDefinitions.Count > value)
				{
					base.RowDefinitions.RemoveAt(base.RowDefinitions.Count - 1);
				}
			}
		}

		public IControl GetContent(int row, int column)
		{
			foreach(System.Windows.UIElement children in base.Children)
			{
				if (Grid.GetRow(children) == row && Grid.GetColumn(children) == column)
				{
					return (IControl) children;
				}
			}

			return null;
		}

		public void SetContent(int row, int column, IControl content)
		{
			Grid.SetRow((System.Windows.UIElement) content, row);
			Grid.SetColumn((System.Windows.UIElement) content, column);

			base.Children.Add((System.Windows.UIElement) content);
		}

		public Color BackgroundColor
		{
			get
			{
				return Page.Parse(((System.Windows.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new System.Windows.Media.SolidColorBrush(Page.Parse(value));
			}
		}

		public Color BorderColor
		{
			get
			{
				return Page.Parse(((System.Windows.Media.SolidColorBrush)base.BorderBrush).Color);
			}
			set
			{
				base.BorderBrush = new System.Windows.Media.SolidColorBrush(Page.Parse(value));
			}
		}

		public double BorderWidth
		{
			get
			{
				return base.BorderThickness.Bottom;
			}
			set
			{
				base.BorderThickness = new System.Windows.Thickness(value);
			}
		}

		public bool Enabled
		{
			get
			{
				return base.IsEnabled;
			}
			set
			{
				base.IsEnabled = value;
			}
		}

		public bool Visible
		{
			get
			{
				return base.Visibility == System.Windows.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = System.Windows.Visibility.Visible;
				}
				else
				{
					base.Visibility = System.Windows.Visibility.Hidden;
				}
			}
		}

		public void Dispose()
		{
		}

		protected override Size ArrangeOverride(Size arrangeSize)
		{
			//apply paddings here? http://stackoverflow.com/questions/1319974/wpf-grid-with-column-row-margin-padding
			return base.ArrangeOverride(arrangeSize);
		}
	}
}