using Backend.Models.Notifications;

namespace Backend.Models {
    public class ContaDespesa:Notifies {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
