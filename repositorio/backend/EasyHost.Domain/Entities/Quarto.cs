using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHost.Domain.Entities
{
    public class Quarto
    {
        private Guid id;
        private int numQuarto;
        private int numCamasSolteiro;
        private int numCamasCasal;
        private int maximoPessoas;
        List<string> adicionais;
        private Guid hotelId;

        /// <summary>
        /// Método construtor para a classe quarto com tratamento para valores inválidos
        /// </summary>
        /// <param name="numQuarto">numero do quarto no hotel</param>
        /// <param name="numCamasSolteiro">Numero de camas de solteiro</param>
        /// <param name="numCamasCasal">Numero de camas de casal</param>
        /// <param name="maximoPessoas">Numero máximo de hospedes que podem ser alocados no quarto</param>
        /// <param name="hotelId">ID do hotel para qual o quarto pertence</param>

        public Quarto(int numQuarto, int numCamasSolteiro, int numCamasCasal, int maximoPessoas, Guid hotelId)
        {
            if (numQuarto <= 0)
                throw new ArgumentException("O número do quarto deve ser maior que zero.");

            if (numCamasSolteiro < 0 || numCamasCasal < 0)
                throw new ArgumentException("O número de camas não pode ser negativo.");

            if (maximoPessoas <= 0)
                throw new ArgumentException("O número máximo de pessoas deve ser maior que zero.");

            if (maximoPessoas < (numCamasSolteiro + (numCamasCasal * 2)))
                throw new ArgumentException("O número máximo de pessoas não pode ser menor que a capacidade total das camas.");

            this.id = Guid.NewGuid();
            this.numQuarto = numQuarto;
            this.numCamasSolteiro = numCamasSolteiro;
            this.numCamasCasal = numCamasCasal;
            this.maximoPessoas = maximoPessoas;
            this.hotelId = hotelId;
            this.adicionais = new List<string>();
        }
        /// <summary>
        /// Método responsável pela adicão de adicionais nos quartos
        /// </summary>
        /// <param name="adicionar">string com os adicionais separados por virgula</param>
        /// <returns>retorna mensagem de erro ou mesagem de sucesso!!</returns>
        public string AddAdicionais(string adicionar)
        {
            try
            {
                string[] add = adicionar.Split(',');
                this.adicionais.AddRange(add);
            }catch (ArgumentException ex) {
                return "Erro ocorrido: " + ex ;
            }
            return "Adicionado com sucesso!!!";
        }

        public string RemoverAdicionais(string remover)
        {
            try
            {
                this.adicionais.Remove(remover);

            }catch (ArgumentException ex)
            {
                return "Erro ocorrido: " + ex;
            }
            return "Removido com sucesso!!!";
        }

        public void AlterarQuarto(int numCamasSolteiro, int numCamasCasal, int maximoPessoas)
        {
            if (numCamasSolteiro < 0 || numCamasCasal < 0)
                throw new ArgumentException("O número de camas não pode ser negativo.");

            if (maximoPessoas <= 0)
                throw new ArgumentException("O número máximo de pessoas deve ser maior que zero.");

            if (maximoPessoas < (numCamasSolteiro + (numCamasCasal * 2)))
                throw new ArgumentException("O número máximo de pessoas não pode ser menor que a capacidade total das camas.");
            
            
            this.numCamasSolteiro = numCamasSolteiro;
            this.numCamasCasal = numCamasCasal;
            this.maximoPessoas = maximoPessoas;

        }

        //Gets dos atributos!!!
        public Guid QuartoId
        {
            get { return id; }
        }
        public int NumQuarto
        {
            get { return numQuarto; }
        }

        public int NumCamasSolteiro
        {
            get { return numCamasSolteiro; }
        }

        public int NumCamasCasal
        {
            get { return numCamasCasal; }
        }

        public int MaximoPessoas
        {
            get { return maximoPessoas; }
        }

        public Guid HotelId
        {
            get { return hotelId; }
        }

    }
}
