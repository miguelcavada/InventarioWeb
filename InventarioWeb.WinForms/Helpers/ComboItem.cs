namespace InventarioWeb.WinForms.Helpers;

public class ComboItem
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public override string ToString() => Nombre;
}