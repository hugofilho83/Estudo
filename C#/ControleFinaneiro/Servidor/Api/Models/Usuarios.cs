using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Models
{
  public class Usuarios
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public bool Ativo { get; set; }
  }
}
