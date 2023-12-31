﻿using Microsoft.Maui.Controls.Shapes;

namespace Border_iOS_Mask_Bug {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            ContentPage mainPage = new();
            mainPage.BackgroundColor = Colors.CornflowerBlue;
            this.MainPage = mainPage;

            VerticalStackLayout vert = new();
            mainPage.Content = vert;

            Border border = new();
            border.Stroke = Colors.White;
            border.StrokeThickness = 10;
            //border.Shadow = new Shadow() { Offset = new Point(0, 6), Radius = 7 };
            vert.Add(border);

            AbsoluteLayout abs = new();
            border.Content = abs;

            Image image = new();
            abs.Add(image);
            //image.Source = ImageSource.FromUri(new Uri("https://www.readersdigest.ca/wp-content/uploads/2019/11/cat-10-e1573844975155.jpg"));
            image.Source = ImageSource.FromResource("Border_iOS_Mask_Bug.Resources.Images.cat.jpg");
            image.Aspect = Aspect.AspectFill;

            //resize function
            mainPage.SizeChanged += delegate {
                if (mainPage.Width > 0) {
                    int width = (int)mainPage.Width ;
                    border.WidthRequest = border.HeightRequest = width * 0.5;
                    image.WidthRequest = image.HeightRequest = width * 0.5;
                    border.StrokeShape = new RoundRectangle() { CornerRadius = width * 0.25 };
                }
            };
        }
    }
}