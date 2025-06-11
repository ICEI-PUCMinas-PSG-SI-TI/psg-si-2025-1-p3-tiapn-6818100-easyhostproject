using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHost.Domain.Entities
{
    public class Alteracoes
    {
        private Guid _id;
        private Guid _usuarioId;
        private DateTime _dataAlteracao;
        private string _descricao;
        private string? _detalhes;

        public Alteracoes(Guid usuarioId, DateTime dataAlteracao, string descricao, string? detalhes)
        {
            //CONSTRUTOR PADRÃO POR ENQUANTO
            _id = Guid.NewGuid();
            _usuarioId = usuarioId;
            _detalhes = detalhes;
            _descricao = descricao;
            _detalhes = detalhes;
        }

        public void MudarDescricao(string descricao)
        {
            //POSSIVEL EXCEÇÃO
            //if (descricao.Count() <= 0)
            //    throw new ArgumentException("Descrição inválida");

            _descricao = descricao;
        }
    }
}
