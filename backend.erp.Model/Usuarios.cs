using BrazilModels;

namespace backend.erp.Model
{
        public class Usuarios
    {
                public Guid Id { get; set; }

                public string Nome { get; set; }

                public Email Email { get; set; }

                public string Senha { get; set; }

                public DateTime DataCadastro { get; set; }

                public bool Situacao { get; set; }
    }
}
