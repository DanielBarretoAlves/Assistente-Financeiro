public class Categoria {
    private string nome;

    public Categoria(string nome)
    {
        this.nome = nome;
    }

    public Categoria()
    {
        
    }

    public string Nome { get => nome; set => nome = value; }
}