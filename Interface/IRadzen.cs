using Radzen;

namespace Asentamientos.Interface{
    public interface INotifiRadzenServices
    {
        public NotificationMessage Notificacion(string tipo, string mensaje, string detalle);
    }
}
