using BrazilModels;
namespace backend.erp.Domain.ValueObject
{

        public class Documento
    {
                public string Documentos { get; private set; }

                protected Documento()
        {
        }

                public Documento(string documento)
        {
            if (isValid())
            {
                Documentos = documento;
            }
        }

                public bool isValid()
        {
            return CpfCnpj.ValidateString(Documentos) != null;
        }

                public override string ToString()
        {
            return Documentos;
        }
    }
}
