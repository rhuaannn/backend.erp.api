namespace backend.erp.Application.FornecedorDTO
{
    using backend.erp.Domain.UserEnums;
    using backend.erp.Domain.ValueObject;

        public class RequestFornecedorDTO
    {
                public Guid Id { get; set; }

                public string Nome { get; set; }

                public string Documento { get; set; }

                public SituationEnum Situacao { get; set; }

                public RequestFornecedorDTO(Guid id)
        {
            id = Guid.NewGuid();
            Id = id;
        }
    }
}
