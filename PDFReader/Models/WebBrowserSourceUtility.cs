using System;
using System.Windows;
using System.Windows.Controls;

namespace PDFReader.Models;

public static class WebBrowserSourceUtility
{
    public static readonly DependencyProperty BindableSourceProperty =
        DependencyProperty.RegisterAttached("BindableSource", typeof(string), typeof(WebBrowserSourceUtility),
            new UIPropertyMetadata(null, BindableSourcePropertyChanged));

    public static string GetBindableSource(DependencyObject obj) => (string) obj.GetValue(BindableSourceProperty);

    public static void SetBindableSource(DependencyObject obj, string value) => obj.SetValue(BindableSourceProperty, value);

    public static void BindableSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
        WebBrowser browser = o as WebBrowser;
        if (browser != null)
        {
            string uri = e.NewValue as string;
            browser.Source = !String.IsNullOrEmpty(uri) ? new Uri(uri) : null;
        }
    }
}