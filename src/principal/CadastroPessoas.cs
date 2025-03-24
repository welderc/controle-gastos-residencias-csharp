using System;

/* 
    Classe responsável pelo gerenciamento de pessoas no sistema.
    Implementa as operações de CRUD (Create, Read, Update, Delete) para pessoas.
    Ao deletar uma pessoa, todas as suas transações associadas também são removidas.
*/

class CadastroPessoas
{
    private int id = 0;
    /* 
        Gerencia pessoas usando um dicionário com ID único como chave. 
        Integra-se com CadastroTransacoes para garantir consistência ao excluir dados.
    */
    private Dictionary<int, Pessoa> pessoas = new Dictionary<int, Pessoa>();
    public Dictionary<int, Pessoa> Pessoas
    {
        get{return pessoas;}
        set{pessoas = value;}
    }

    /*
        Cadastra pessoa com ID autoincrementado. 
        Solicita nome (string) e idade (int) via console.
        Lança FormatException se idade não for numérica.
    */
    public void cadastrar()
    {
        Console.WriteLine("\n ---------- Cadastro de Pessoas --------- \n");
        id++;

        Console.Write("Nome: ");
        string nomeUsuario = Console.ReadLine();

        Console.Write("Idade: ");
        int idadeUsuario = int.Parse(Console.ReadLine());

        Pessoa pessoa = new Pessoa(nomeUsuario, idadeUsuario, id);

        pessoas.Add(id, pessoa);

        Console.WriteLine("Pessoa cadastrada com sucesso! ID: "+ id +"\n");
        Console.WriteLine("---------------------------------------- \n\n"); 
    }
    
    /*
        Lista pessoas no formato: ID: X | Nome: Y | Idade: Z.
        Exibe 'Nenhuma pessoa cadastrada' se o dicionário estiver vazio.
    */
    public void exibir()
    {
        Console.WriteLine("\n ----------- Lista de Pessoas --------- ");
        if (pessoas.Count == 0)
        {
            Console.WriteLine("Nenhuma pessoa cadastrada.");
            return;
        }

        // Cabeçalho da tabela
        Console.WriteLine("\n"+ new string('-', TamanhoTabela.LinhaHorizontal));

        Console.WriteLine(
            "ID".PadRight(TamanhoTabela.IdNome) +
            "| Nome".PadRight(TamanhoTabela.Nome) +
            "| Idade".PadRight(TamanhoTabela.Idade)
        );

        Console.WriteLine(new string('-', TamanhoTabela.LinhaHorizontal));
        
        foreach (KeyValuePair<int, Pessoa> entrada in pessoas)
        {
            Pessoa pessoa = entrada.Value; // Extrai objeto Pessoa do valor do dicionário
            int id = entrada.Key; // Extrai a chave (ID) do dicionário

            Console.WriteLine(
                $"{id.ToString().PadRight(TamanhoTabela.IdNome)}" + // Usa o ID do dicionário
                $"| {pessoa.Nome.PadRight(TamanhoTabela.Nome-2)}" +
                $"| {pessoa.Idade.ToString().PadRight(TamanhoTabela.Idade)}"
            );
        }
    }

    // Remove uma pessoa e todas suas transações relacionadas.
    public bool deletar(int id, CadastroTransacoes cadastroTransacoes)
    {   
        if (!pessoas.ContainsKey(id))
        {
            Console.WriteLine("Pessoa não encontrada para o ID: " + id);
            return false;
        }

        pessoas.Remove(id);  // Remove a pessoa do dicionário
        cadastroTransacoes.RemoverTransacoesPorPessoa(id); // Remove transações associadas 

        Console.WriteLine("\n✅ Pessoa e transações removidas com sucesso! \n");
        return true;
    }

}