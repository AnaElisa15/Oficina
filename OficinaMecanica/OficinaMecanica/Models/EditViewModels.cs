using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OficinaMecanica.Models
{
    public class EditViewModels
    {
        public EditViewModels (OrdemServico ordemServico, List<Cliente> clientes, List<Funcionario> funcionarios, List<Servico> servicos)
        {
            this.OrdemServico = ordemServico;
            this.Clientes = clientes;
            this.Funcionarios = funcionarios;
            this.Servicos = servicos;
        }

        public OrdemServico OrdemServico { get; set; }

        [Required(ErrorMessage = "Selecione um cliente")]
        public List<Cliente> Clientes { get; set; }
        [Required(ErrorMessage = "Selecione um funcionário")]
        public List<Funcionario> Funcionarios { get; set; }
        [Required(ErrorMessage = "Selecione um serviço")]
        public List<Servico> Servicos { get; set; }
    }
}