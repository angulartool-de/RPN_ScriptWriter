using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JGLib24_RPNScriptWriter;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // FileStream fs = new FileStream();
    }

    private void Rpn_OnKeyUp(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Enter:
                Protokoll.Text += "'" + Rpn.Text + "'" + "," + "\r\n";
                Rpn.Text = null;
                break;
            case Key.Add:
                TextRemove(1);
                Protokoll.Text += "'" + "+" + "'" + "," + "\r\n";
                Rpn.Text = null;
                break;
            case Key.Divide:
                TextRemove(1);
                Protokoll.Text += "'" + "/" + "'" + "," + "\r\n";
                Rpn.Text = null;
                break;
            case Key.Multiply:
                TextRemove(1);
                Protokoll.Text += "'" + "*" + "'" + "," + "\r\n";
                Rpn.Text = null;
                break;
            case Key.Subtract:
                TextRemove(1);
                Protokoll.Text += "'" + "-" + "'" + "," + "\r\n";
                Rpn.Text = null;
                break;
        }
    }

    private void TextRemove(int n)
    {
        Rpn.Text = Rpn.Text.Remove(Rpn.Text.Length - n, 1);

        if (Rpn.Text.Length > 0) Protokoll.Text += "'" + Rpn.Text + "'" + "," + "\r\n";
    }


    private void Button_OnClick(object sender, RoutedEventArgs e)
    {
        var btn = (Button)sender;
        if (Rpn.Text.Length > 0) Protokoll.Text += "'" + Rpn.Text + "'" + "," + "\r\n";

        Protokoll.Text += "'" + btn.Content + "'" + "," + "\r\n";
        Rpn.Text = null;
        FocusSet();
    }

    private void This_OnClick(object sender, RoutedEventArgs e)
    {
        var btn = (Button)sender;
        Rpn.Text += "this.";
        FocusSet();
    }


    private void FocusSet()
    {
        Rpn.Focus();
        Rpn.CaretIndex = Rpn.Text.Length;
    }
}