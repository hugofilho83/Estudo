using Backend.Models.Notifications;

namespace Backend.Models {
    public class SituacaoLancamentoReceita : Notifies {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
