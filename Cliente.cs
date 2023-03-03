
namespace M1S3_SistemaBanco
{
    public abstract class Cliente
    {        
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }        
        public int NumeroConta { get; set; }
        public double Saldo {  get {return GetSaldo(); }  private set{} }        
        
        public List<Transacao> Extrato { get; set; }

        public Cliente()
        {
            Extrato = new List<Transacao>();
        }
        public Cliente(string nome, string cpf, string email, string telefone, 
                       string end, DateTime dtNascimento,int numeroConta ) :this()
        {
            //Nome = nome;
            //CPF = cpf;
            Email=email;
            Telefone =telefone; 
            Endereco = end;
            DataNascimento = dtNascimento;
            NumeroConta = numeroConta;            
        }

        public string ResumoCliente() =>  $"{NumeroConta} |  {Nome}  | {CPF}";
        public bool EhMaior() => Idade >= 18;
    
        private double GetSaldo() => Extrato.Sum(x => x.Valor);
    }
}