using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHost.Domain.Entities
{
    public class Hospede
    {
        private Guid id;
        private string nome;
        private string cpf;
        private int hotelId;
        /// <summary>
        /// Construtor para a classe hospede com trataamento de exceções 
        /// </summary>
        /// <param name="nome">Nome do hospede</param>
        /// <param name="cpf">Cpf</param>
        /// <param name="hotelId">id do hotel</param>
        /// <exception cref="ArgumentException">Caso entrda seja válida</exception>
        public Hospede(string nome, string cpf, int hotelId)
        {
            this.id = Guid.NewGuid();
            if (nome == null)
                throw new ArgumentException ("Nome precisa ser válido");
            if (hotelId <= 0)
                throw new ArgumentException("Hotel id não pode ser 0");
            if (cpf == null && cpf.Length < 11)
                throw new ArgumentException("CPF precisa ser válido");
            this.hotelId = hotelId;
            this.nome = nome;
            this.cpf = cpf;
        }
        /// <summary>
        /// Metodo que permite a alteração dos dados do Hospede
        /// </summary>
        /// <param name="nome">
        /// <param name="nome">Nome do hospede</param>
        /// <param name="cpf">Cpf</param>
        /// <exception cref="ArgumentException">Caso parâmetro seja válida</exception>
        public void AlterarHospede(string nome, string cpf)
        {
            if (nome == null)
                throw new ArgumentException("Nome precisa ser válido");
            if (cpf == null && cpf.Length < 11)
                throw new ArgumentException("CPF precisa ser válido");
            this.nome = nome;
            this.cpf = cpf;
        }

        //Gets dos atributos!!!
        public string Nome()
        {
            return nome;
        }

        public string Cpf()
        {
            return cpf;
        }

    }
}
