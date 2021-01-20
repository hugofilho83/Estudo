using Backend.Models.Notifications;

namespace Backend.Models {
    public class Usuario : Notifies {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
    }
}
