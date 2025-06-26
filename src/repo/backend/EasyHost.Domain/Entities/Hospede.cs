using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHost.Domain.Entities
{
    public class Hospede
    {
        public Guid id { get; private set;}
        public string nome { get; private set;}
        public string cpf { get; private set; }
        public Guid hotelId { get; private set; }
        public LinkedList<Consumo>? consumos { get; private set; }

        public Hospede() { }
        
        public Hospede(string nome, string cpf, Guid hotelId)
        {
            this.id = Guid.NewGuid();
            this.hotelId = hotelId;
            this.nome = nome;
            this.cpf = cpf;
            consumos = new LinkedList<Consumo>();
        }
    }
}
