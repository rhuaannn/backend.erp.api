using backend.erp.Domain.UserEnums;
using backend.erp.Domain.ValueObject;

namespace backend.erp.Domain.Model
{
    public class Fornecedores
    {
                public Guid Id { get; set; }

                public string Nome { get; set; }

                public Documento Documento { get; set; }
                
                public SituationEnum Situacao { get; set; }

                public ICollection<Produtos> Produtos { get; set; } = new List<Produtos>();


    }
}
