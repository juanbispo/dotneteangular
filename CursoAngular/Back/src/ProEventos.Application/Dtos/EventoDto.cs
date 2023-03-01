using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Application.Dtos{
    public class EventoDto{
    
    public int Id {get; set;}
    public string Local { get; set; }

    public string DataEvento {get; set;}

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(50,MinimumLength =3,ErrorMessage ="O {0} deve ter de 3 a 50 caracteres")]
    public string Tema { get; set; }

    [Required(ErrorMessage ="A {0} é obrigatória")]
    [Display(Name ="Quantidade de pessoas")]
    [Range(1,120000,ErrorMessage ="A {0} não pode ser menor que 1 e maior que 120.000")]
    public int QtdPessoas { get; set; }

    [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", 
        ErrorMessage ="Não é uma imagem válida. (gif,jpg,jpeg,bmp e png)")]
    public string ImagemUrl { get; set; }

    [Required(ErrorMessage ="O campo {0} é obrigatório")]
    [Phone(ErrorMessage ="O campo {0} está com o número inválido")]
    public string Telefone { get; set; }

    [EmailAddress(ErrorMessage = "O campo {0} precisa ser um e-mail válido")]
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string Email { get; set; }

    public IEnumerable<LoteDto> Lotes { get; set; }

    public IEnumerable<RedeSocialDto> RedesSociais { get; set; }

    public IEnumerable<PalestranteDto> Palestrantes{ get; set; }
    
}
}
