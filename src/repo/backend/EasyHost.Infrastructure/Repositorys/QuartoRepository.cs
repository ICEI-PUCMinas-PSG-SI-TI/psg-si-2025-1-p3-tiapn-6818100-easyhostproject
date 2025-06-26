using Dapper;
using EasyHost.Domain.Entities;
using EasyHost.Domain.Interfaces;
using EasyHost.Infrastructure.Data;


namespace EasyHost.Infrastructure.Repositorys
{
    public class QuartoRepository : BaseRepository, IQuartoRepository
    {
        public QuartoRepository(IDataConnection context)
            : base(context)
        {
        }

        public void CreateQuarto(Quarto quarto)
        {
            var sql = @"
            INSERT INTO Quarto 
                (id, numQuarto, numCamasSolteiro, numCamasCasal, maxPessoas, hotelIdFk, precoDiaria)
            VALUES
                (@Id, @NumQuarto, @NumCamasSolteiro, @NumCamasCasal, @MaxPessoas, @HotelId, @PrecoDiaria); 
            ";

            connection.Execute(sql, new
            {
                Id = quarto.id,
                NumQuarto = quarto.numQuarto,
                NumCamasSolteiro = quarto.numCamasSolteiro,
                NumCamasCasal = quarto.numCamasCasal,
                MaxPessoas = quarto.maxPessoas,
                HotelId = quarto.hotelId,
                PrecoDiaria = quarto.precoDiaria,
            });
        }

        public Quarto? GetQuartoById(Guid quartoId)
        {
            const string sql = @"
            SELECT
            id    AS id,
            numQuarto  AS numQuarto,
            numCamasSolteiro  AS numCamasSolteiro,
            numCamasCasal   AS numCamasCasal,
            maxPessoas AS maxPessoas,
            hotelIdFk  AS hotelId,
            precoDiaria  AS precoDiaria
            FROM Quarto
            WHERE id = @Id;";

            return connection.QueryFirstOrDefault<Quarto>(sql, new { Id = quartoId });
        }

        public IEnumerable<Quarto> GetAllQuartos(Guid hotelId)
        {
            const string sql = @"
            SELECT
            id    AS id,
            numQuarto  AS numQuarto,
            numCamasSolteiro  AS numCamasSolteiro,
            numCamasCasal   AS numCamasCasal,
            maxPessoas AS maxPessoas,
            hotelIdFk  AS hotelId,
            precoDiaria  AS precoDiaria
            FROM Quarto
            WHERE hotelIdFk = @hotelId;";

            return connection.Query<Quarto>(sql, new { hotelId });

        }

        public void AtualizarQuarto(Quarto quarto)
        {
            const string sql = @"
            UPDATE Quarto 
              SET numCamasSolteiro = @NumCamasSolteiro,
               numCamasCasal    = @NumCamasCasal,
               maxPessoas    = @MaximoPessoas,
               precoDiaria   = @PrecoDiaria
              WHERE Id               = @Id;
             ";

            connection.Execute(sql, new
            {
                Id = quarto.id,
                NumCamasSolteiro = quarto.numCamasSolteiro,
                NumCamasCasal = quarto.numCamasCasal,
                MaximoPessoas = quarto.maxPessoas,
                PrecoDiaria = quarto.precoDiaria
            });

        }

        public void DeletarQuarto(Guid quartoId)
        {
            const string sql = @"DELETE FROM Quarto WHERE id = @Id;";
            connection.Execute(sql, new { Id = quartoId });
        }
    }
}