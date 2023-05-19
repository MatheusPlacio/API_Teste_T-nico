namespace Domain.Models
{
    public class Convenio
    {
        public int ConvenioId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }


        // EF Relacionamento
        public List<Paciente> Pacientes { get; set; }


        public void Update(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}
