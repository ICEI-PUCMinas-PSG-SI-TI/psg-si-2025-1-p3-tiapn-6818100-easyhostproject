using System;
using System.Collections.Generic;
using System.Linq;
using EasyHost.Application.DTOs;
using EasyHost.Application.DTOs.Request.HospedeRequest;
using EasyHost.Application.DTOs.Response.HospedeResponse;
using EasyHost.Application.Interfaces;
using EasyHost.Domain.Entities;
using EasyHost.Domain.Interfaces;
using Mapster;

namespace EasyHost.Application.Services
{
    public class HospedeService : IHospedeService
    {
        private readonly IHospedeRepository _hospedeRepository;
        private readonly IConsumoRepository _consumoRepository;

        public HospedeService(IHospedeRepository hospedeRepository, IConsumoRepository consumoRepository)
        {
            _hospedeRepository = hospedeRepository;
            _consumoRepository = consumoRepository;
        }

        public HospedeDto CreateHospede(CreateHospedeDto dto)
        {
            var hospede = new Hospede(dto.nome, dto.cpf, dto.hotelId);
            _hospedeRepository.CreateHospede(hospede);
            return hospede.Adapt<HospedeDto>();
        }

        public IEnumerable<HospedeDto> GetAllHospedes(Guid hotelId)
        {
            var hospedes = _hospedeRepository.GetAllHospede(hotelId);
            return hospedes.Adapt<IEnumerable<HospedeDto>>();
        }

        public HospedeDto GetHospedeById(Guid id)
        {
            var hospede = _hospedeRepository.GetHospedeById(id)
                ?? throw new KeyNotFoundException("Hóspede não encontrado");
            return hospede.Adapt<HospedeDto>();
        }

        public HospedeDto GetHospedeByCpf(string cpf)
        {
            var hospede = _hospedeRepository.GetHospedeByCpf(cpf)
                ?? throw new KeyNotFoundException("Hóspede não encontrado");
            return hospede.Adapt<HospedeDto>();
        }

        public void DeleteHospede(Guid id)
        {
            _hospedeRepository.DeletarHospede(id);
        }

        public decimal GetValorTotalConsumo(Guid idHospede)
        {
            return _consumoRepository.GetConsumosByHospedeId(idHospede).Sum(c => c.preco);
        }
    }
}
