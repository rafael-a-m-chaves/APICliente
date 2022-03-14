using System;

namespace APICliente.Domain.Entities
{
    public class VendasCliente
    {
        public int Id { get; set; }
        public int CodigoCliente { get; private set; }
        public DateTime DataVenda { get; private set; }
        public decimal ValorDaVenda { get; private set; }
        public int IdUsuario { get; private set; }
        public Usuario Usuario { get; set; }

        public VendasCliente()
        {

        }

        public void NovaVenda(int codigoCliente, DateTime dataVenda, decimal valorDaVenda, int idUsuario)
        {
            this.Id = 0;
            this.CodigoCliente = codigoCliente;
            this.DataVenda = dataVenda;
            this.ValorDaVenda = valorDaVenda;
            this.IdUsuario = idUsuario;
        }

        public void AlterarValorVenda(decimal novoValor)
        {
            this.ValorDaVenda = novoValor;
        }

        public void AlterarDataDaVenda(DateTime dataVenda) 
        { 
            this.DataVenda = dataVenda;
        }
    }
}
