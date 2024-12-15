﻿using GerenciadorDeTarefas.Enum;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreation { get; set; }
    }
}