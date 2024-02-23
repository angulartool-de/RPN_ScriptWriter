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

    /// <summary>
    /// Check all Key Inputs and React on specified actions
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            case Key.Space:
                Rpn.Text += "this.";
                FocusSet();
                break;
        }
    }


    private void Button_OnClick(object sender, RoutedEventArgs e)
    {
        var btn = (Button)sender;
        if (Rpn.Text.Length > 0) Protokoll.Text += "'" + Rpn.Text + "'" + "," + "\r\n";

        Protokoll.Text += "'" + btn.Content + "'" + "," + "\r\n";
        Rpn.Text = null;
        FocusSet();
    }


    /// <summary>
    /// Add this. to Input Text
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void This_OnClick(object sender, RoutedEventArgs e)
    {
        var btn = (Button)sender;
        Rpn.Text += "this.";
        FocusSet();
    }


    /// <summary>
    /// Routine to scip + - * /
    /// </summary>
    /// <param name="n"></param>
    private void TextRemove(int n)
    {
        Rpn.Text = Rpn.Text.Remove(Rpn.Text.Length - n, 1);

        if (Rpn.Text.Length > 0) Protokoll.Text += "'" + Rpn.Text + "'" + "," + "\r\n";
    }

    /// <summary>
    /// Set focus on Input field
    /// </summary>
    private void FocusSet()
    {
        Rpn.Focus();
        Rpn.CaretIndex = Rpn.Text.Length;
    }
}