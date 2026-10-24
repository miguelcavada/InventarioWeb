using System.Drawing;
using InventarioWeb.WinForms.Styles;

namespace InventarioWeb.WinForms.Controls;

public class SearchBox : Panel
{
    private Label? _lblIcono;
    public TextBox TextBox { get; }

    public string PlaceholderText
    {
        get => TextBox.PlaceholderText;
        set => TextBox.PlaceholderText = value;
    }

    public SearchBox()
    {
        Height = 38;
        BackColor = Color.White;
        BorderStyle = BorderStyle.FixedSingle;
        Padding = new Padding(0);

        _lblIcono = new Label
        {
            Text = "🔍",
            Font = new Font("Segoe UI", 11),
            Location = new Point(10, 9),
            AutoSize = true,
            BackColor = Color.Transparent
        };

        TextBox = new TextBox
        {
            BorderStyle = BorderStyle.None,
            Location = new Point(35, 9),
            Width = 200,
            Font = AppFonts.Normal,
            BackColor = Color.White,
            PlaceholderText = "Buscar..."
        };

        Controls.Add(_lblIcono);
        Controls.Add(TextBox);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        if (TextBox != null)
            TextBox.Width = Width - 50;
    }
}