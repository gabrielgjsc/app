public class Evento
    {
        public string? Id { get; set; }
        public string? Titulo { get; set; }
        public DateTime DataHoraInicial { get; set; }
        public DateTime DataHoraFinal { get; set; }
        public string? Descricao { get; set; }
        public int QuantidadePessoas { get; set; }
        public string? PublicoAlvo { get; set; }
        public Contato? ContatoResponsavel { get; set; }
    }