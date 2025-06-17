namespace EasyHost.Domain.Entities
{
    public class Consumo
    {
        public Guid id { get; private set; }
        public string nome { get; private set; }
        public decimal preco { get; private set; }
        public Guid hospedeId { get; private set; }
        public Guid hotelId { get; private set; }

        public Consumo() { }

        public Consumo(string nome, decimal preco, Guid hospedeId, Guid hotelId)
        {
            id = Guid.NewGuid();
            this.nome = nome;
            this.preco = preco;
            this.hospedeId = hospedeId;
            this.hotelId = hotelId;
        }
    }
}
