namespace APICliente.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public bool IsActive { get; set; }
    }
}
