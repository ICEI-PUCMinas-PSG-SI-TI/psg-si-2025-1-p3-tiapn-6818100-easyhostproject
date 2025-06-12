using Dapper;
using EasyHost.Domain.Entities;
using EasyHost.Domain.Interfaces;
using EasyHost.Infrastructure.Data;


namespace EasyHost.Infrastructure.Repositorys
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(IDataConnection context)
            : base(context)
        {
        }

        public void CreateUsuario(Usuario usuario)
        {
            var sql = @"
            INSERT INTO Usuario 
                (id, nome, cpf, salario, ativo, tipoUsuarioId, hotelIdFk, email, senha)
            VALUES
                (@Id, @Nome, @Cpf, @Salario, @Ativo, @TipoUsuarioId, @HotelId, @Email, @Senha); 
            ";

            connection.Execute(sql, new
            {
                Id = usuario._id,
                Nome = usuario._nome,
                Cpf = usuario._cpf,
                Salario = usuario._salario,
                Ativo = true,
                TipoUsuarioId = (int)usuario._tipoUsuario,
                HotelId = usuario._hotelId,
                Email = usuario._email,
                Senha = usuario._senha
            });
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            const string sql = @"
            UPDATE Usuario 
            SET nome = @Nome, salario = @Salario, tipoUsuarioId = @TipoUsuarioId , ativo = @Ativo
            WHERE id = @Id;";

            connection.Execute(sql, new
            {
                Id = usuario._id,
                Nome = usuario._nome,
                Salario = usuario._salario,
                TipoUsuarioId = (int)usuario._tipoUsuario,
                Ativo = usuario._ativo,
            });
        }

        public void AtualizarUsuarioSenha(Usuario usuario)
        {
            const string sql = @"
            UPDATE Usuario 
            SET email = @Email,  senha = @Senha
            WHERE id = @Id;";

            connection.Execute(sql, new
            {
                Id = usuario._id,
                Email = usuario._email,
                Senha = usuario._senha
            });

        }

        public void DeletarUsuario(Guid userId)
        {
            const string sql = @"DELETE FROM Usuario WHERE id = @Id;";
            connection.Execute(sql, new { Id = userId });
        }

        public bool HasLogin(string cpf)
        {
            const string sql = @"SELECT * FROM Usuario WHERE cpf = @Cpf;";
                
            var usuario = connection.QueryFirstOrDefault<Usuario>(sql, new { Cpf = cpf });
            return usuario != null;
        }

        public Usuario? GetUserByEmail(string email)
        {
            const string sql = @"
            SELECT
            id            AS _id,
            nome          AS _nome,
            cpf           AS _cpf,
            salario       AS _salario,
            ativo         AS _ativo,
            tipoUsuarioId AS _tipoUsuario,
            hotelIdFk     AS _hotelId,
            email         AS _email,
            senha         AS _senha
            FROM Usuario
            WHERE email = @Email;";
            
            return connection.QueryFirstOrDefault<Usuario>(sql, new { Email = email });
        }

        public Usuario? GetUserById(Guid id)
        {
            const string sql = @"
            SELECT
            id            AS _id,
            nome          AS _nome,
            cpf           AS _cpf,
            salario       AS _salario,
            ativo         AS _ativo,
            tipoUsuarioId AS _tipoUsuario,
            hotelIdFk     AS _hotelId,
            email         AS _email,
            senha         AS _senha
            FROM Usuario
            WHERE id = @Id;";

            return connection.QueryFirstOrDefault<Usuario>(sql, new { Id = id });
        }

        public List<Usuario> GetAllUsuarios()
        {
            const string sql = @"
            SELECT
            id            AS _id,
            nome          AS _nome,
            cpf           AS _cpf,
            salario       AS _salario,
            ativo         AS _ativo,
            tipoUsuarioId AS _tipoUsuario,
            hotelIdFk     AS _hotelId,
            email         AS _email,
            senha         AS _senha
            FROM Usuario;";

            return connection.Query<Usuario>(sql).ToList();
        }
    }
}
