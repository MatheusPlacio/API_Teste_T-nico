namespace Domain.Models
{
    public class Paciente
    {
        public int PacienteId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Genero { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string UF_RG { get; set; }
        public string? Email { get; set; }
        public string Celular { get; set; }
        public string? TelefoneFixo { get; set; }
        public string CarteirinhaDoConvenio { get; set; }
        public string ValidadeDaCarteirinha { get; set; }


        // EF Relacionamento
        public Convenio Convenio { get; set; }
        public int ConvenioId { get; set; }
    }
}
