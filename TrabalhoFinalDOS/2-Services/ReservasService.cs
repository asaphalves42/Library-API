using Microsoft.AspNetCore.Mvc;
using TrabalhoFinalDOS._2___Services.Excepcoes;
using TrabalhoFinalDOS._2_Services.Mapper;
using TrabalhoFinalDOS.DTO;
using TrabalhoFinalDOS.Mapper;
using TrabalhoFinalDOS.Models;
using TrabalhoFinalDOS.Repository;
using TrabalhoFinalDOS.Services;

namespace TrabalhoFinalDOS.Controllers
{
    public class ReservasService : IReservasService
    {
        private readonly BaseDados _basedados;

        public ReservasService(BaseDados basedados)
        {
            _basedados = basedados;
        }

        public ReservaDTO ObterReservaPorId(int id)
        {
            var reserva = this._basedados.Reserva.Where(objecto => objecto.Id == id).FirstOrDefault();
            if (reserva == null)
            {
                throw new ExcepcaoHTTP("Reserva não encontrada", System.Net.HttpStatusCode.NotFound);
            }
            return reserva.ReservaParaDTO();
        }

        public List<ReservaClienteDTO> ObterReservaPorCliente(int idCliente)
        {
            var reservas = this._basedados.Reserva.Where(objecto => objecto.IdCliente == idCliente).Select(x => x.ReservaParaDTOClienteReserva()).ToList();
            return reservas;
        }

        public ReservaDTO CriarReserva(NovaReservaDTO novaReserva)
        {

            // validações
            var cliente = _basedados.Cliente.Find(novaReserva.IdCliente);
            if (cliente == null)
            {
                throw new ExcepcaoHTTP("Id cliente inválido", System.Net.HttpStatusCode.NotFound);
            }

            var livro = _basedados.Livro.Find(novaReserva.IdLivro);
            if (livro == null)
            {
                throw new ExcepcaoHTTP("Id livro inválido", System.Net.HttpStatusCode.NotFound);
            }

            Reserva reserva = novaReserva.DTOParaReserva();
            this._basedados.Reserva.Add(reserva);
            this._basedados.SaveChanges();

            // Retornar a reserva criada em formato DTO
            return reserva.ReservaParaDTO();
        }
    }
}
