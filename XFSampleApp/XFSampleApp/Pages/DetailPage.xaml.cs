using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSampleApp.models;

namespace XFSampleApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage : ContentPage
	{
		private DetailPage ()
		{
			InitializeComponent ();
            //PreviewGridCell(this.Content as Grid, Color.Pink);
        }

        public DetailPage(SchoolInfo schoolInfo):this()
        {
            BindingContext = schoolInfo;
        }

        private void PreviewGridCell(Grid grid, Color cellBackgroundColor)
        {
            var columnCount = grid.ColumnDefinitions.Count;
            var rowCount = grid.RowDefinitions.Count;
            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    var boxView = new BoxView()
                    {
                        BackgroundColor = cellBackgroundColor
                    };
                    Grid.SetColumn(boxView, column);
                    Grid.SetRow(boxView, row);
                    grid.Children.Add(boxView);
                }
            }
            var allBuildPreviewCellCount = columnCount * rowCount;
            for (int start = 0; start < grid.Children.Count - allBuildPreviewCellCount; start++)
            {
                var targetCellView = grid.Children[0];
                for (int raiseCount = 0; raiseCount < grid.Children.Count - 1; raiseCount++)
                {
                    grid.RaiseChild(targetCellView);
                }
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var label = sender as Label;
            var result = CheckLabelType(label.Text);

            var isConfirm = await DisplayAlert("通知", $"是否執行 {result.Item2} 處理 ?", "確定", "取消");
            if (isConfirm)
            {
                Device.OpenUri(new Uri(result.Item1));
            }
        }

        private Tuple<string, string> CheckLabelType(string text)
        {
            if (text.Contains("@"))
            {
                return new Tuple<string, string>($"mailto:{text}", "發送 Email");
            }
            return new Tuple<string, string>($"tel:{text}", "撥打電話");
        }
    }
}