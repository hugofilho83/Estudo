using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models.Notifications {
    public class Notifies {
        public Notifies () {
            this.Notifications = new List<Notify> ();
        }

        [NotMapped]
        [JsonIgnore]
        public List<Notify> Notifications { get; set; }

        public bool ValidationPropertyString (string Value, string NameProperty) {
            if (string.IsNullOrWhiteSpace (Value) || string.IsNullOrWhiteSpace (NameProperty)) {
                Notifications.Add (new Notify
                {
                    Messager = "Campo Obrigatorio",
                        NameProperty = NameProperty
                });

                return false;
            }

            return true;
        }

        public bool ValidationPropertyInteger (int Value, string NameProperty) {
            if (Value < 1 || string.IsNullOrWhiteSpace (NameProperty)) {
                Notifications.Add (new Notify
                {
                    Messager = "Campo Obrigatorio",
                        NameProperty = NameProperty
                });

                return false;
            }

            return true;
        }

        public bool ValidationPropertyDecimal (decimal Value, string NameProperty) {
            if (Value < 1 || string.IsNullOrWhiteSpace (NameProperty)) {
                Notifications.Add (new Notify
                {
                    Messager = "Campo Obrigatorio ",
                        NameProperty = NameProperty
                });

                return false;
            }

            return true;
        }

        public void AddNoficication (string messager, string porperty) {
            Notifications.Add (new Notify
            {
                Messager = messager,
                    NameProperty = porperty
            });
        }

        public override string ToString()
        {
            string retorno = "";
            foreach (var item in Notifications)
            {
                retorno += item.Messager + " "+ item.NameProperty + " / ";
            }
            return retorno;
        }
    }
}
