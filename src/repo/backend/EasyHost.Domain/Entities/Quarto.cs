
namespace EasyHost.Domain.Entities
{
    public class Quarto
    {
        public Guid id { get; private set; }
        public int numQuarto { get; private set; }
        public int numCamasSolteiro { get; private set; }
        public int numCamasCasal { get; private set; }
        public int maxPessoas { get; private set; }
        public Guid hotelId { get; private set; }
        public decimal precoDiaria { get; private set; }

        public Quarto() { }

        public Quarto(int numQuarto, int numCamasSolteiro, int numCamasCasal, int maxPessoas, Guid hotelId, decimal precoDiaria)
        {
            if (numQuarto <= 0)
                throw new ArgumentException("O número do quarto deve ser maior que zero.");

            if (numCamasSolteiro < 0 || numCamasCasal < 0)
                throw new ArgumentException("O número de camas não pode ser negativo.");

            if (maxPessoas <= 0)
                throw new ArgumentException("O número máximo de pessoas deve ser maior que zero.");

            if (maxPessoas < (numCamasSolteiro + (numCamasCasal * 2)))
                throw new ArgumentException("O número máximo de pessoas não pode ser menor que a capacidade total das camas.");

            this.id = Guid.NewGuid();
            this.numQuarto = numQuarto;
            this.numCamasSolteiro = numCamasSolteiro;
            this.numCamasCasal = numCamasCasal;
            this.maxPessoas = maxPessoas;
            this.hotelId = hotelId;
            this.precoDiaria = precoDiaria;
        }

        public void AlterarQuarto(int numCamasSolteiro, int numCamasCasal, int maxPessoas, decimal precodiaria)
        {
            if (numCamasSolteiro < 0 || numCamasCasal < 0)
                throw new ArgumentException("O número de camas não pode ser negativo.");

            if (maxPessoas <= 0)
                throw new ArgumentException("O número máximo de pessoas deve ser maior que zero.");

            if (maxPessoas < (numCamasSolteiro + (numCamasCasal * 2)))
                throw new ArgumentException("O número máximo de pessoas não pode ser menor que a capacidade total das camas.");
            
            
            this.numCamasSolteiro = numCamasSolteiro;
            this.numCamasCasal = numCamasCasal;
            this.maxPessoas = maxPessoas;
            this.precoDiaria = precodiaria;


        }
    }
}
