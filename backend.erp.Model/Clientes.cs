using backend.erp.Domain.ValueObject;

namespace backend.erp.Model
{
        public class Clientes
    {
                public Guid Id { get; set; }

                public string Nome { get; set; }

                public Documento Documento { get; set; }

                public DateTime DataCadastro { get; set; }
    }
}
