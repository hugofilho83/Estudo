using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entitites.Notifications
{
    public class Notifies
    {
        public Notifies()
        {
            Notitys = new List<Notifies>();
        }

        [NotMapped]
        public string NameProperty { get; set; }

        [NotMapped]
        public string Messeger { get; set; }

        [NotMapped]
        public List<Notifies> Notitys { get; set; }

        public bool ValidationPropertyString(string value, string nameProperty) { 
            if(string.IsNullOrWhiteSpace(value)|| string.IsNullOrWhiteSpace(nameProperty)) 
            {
                Notitys.Add(new Notifies
                {
                    Messeger = "Campo Obrigatório",
                    NameProperty = nameProperty
                });

                return false;
            }

            return true;
        }

        public bool ValidationPropertyInteger(int value, string nameProperty) 
        {
            if(value < 1 || string.IsNullOrWhiteSpace(NameProperty))
            {
                Notitys.Add(new Notifies
                {
                    Messeger = "Campo Obrigatório",
                    NameProperty = nameProperty
                });

                return false;
            }

            return true;
        }
    }
}
