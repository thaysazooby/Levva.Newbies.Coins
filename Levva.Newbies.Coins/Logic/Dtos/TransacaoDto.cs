﻿using Levva.Newbies.Coins.Domain.Enums;
using Levva.Newbies.Coins.Logic.Dtos;

namespace Levva.Newbies.Coins.Logic.Dtos
{
    public class TransacaoDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public TipoTransacaoEnum Type { get; set;}
        public CategoriaDto? Category { get; set; }
    }
}
