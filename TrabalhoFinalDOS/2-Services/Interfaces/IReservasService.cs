using TrabalhoFinalDOS.DTO;

namespace TrabalhoFinalDOS.Services
{
    public interface IReservasService
    {
        ReservaDTO ObterReservaPorId(int id);
        List<ReservaClienteDTO> ObterReservaPorCliente(int idCliente);
        ReservaDTO CriarReserva(NovaReservaDTO reservaDTO);
    }
}
