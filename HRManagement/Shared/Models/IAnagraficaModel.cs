namespace HRManagement.Shared.Models;

public interface IAnagraficaModel
{
    public int Id { get; set; }
    public string Descrizione { get; set; }
    public bool Attivo { get; set; }
}