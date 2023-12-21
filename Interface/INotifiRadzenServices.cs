using Radzen;

namespace Asentamientos.Interface{
    public interface INotifiRadzenServices
    {
        NotificationMessage Notificacion(string tipo, string mensaje, string detalle);
    }
}
