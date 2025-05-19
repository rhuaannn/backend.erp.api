namespace backend.erp.Model
{
        public class Produtos
    {
                public Guid Id { get; set; }

                public string Nome { get; set; }

                public DateTime Validade { get; set; }

                public int Quantidade { get; set; }

                public double Preco { get; set; }

                public Guid FornecedorId { get; set; }
                public Fornecedores Fornecedor { get; set; }
    }
}
