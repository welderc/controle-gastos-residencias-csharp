using System;

/*
    Classe responsável pelo gerenciamento de transações financeiras no sistema.
    Implementa as operações de criação e listagem de transações.
    Possui regras específicas para menores de idade (apenas despesas permitidas).
*/

 class CadastroTransacoes
 {
    private int id = 0;
    // Armazena as transações usando um dicionário com ID único como chave.
    private Dictionary<int, Transacao> transacoes = new Dictionary<int, Transacao>();

    public int ID
    {
        get{return id;}
        set{id = value;}
    }

    public Dictionary<int, Transacao> Transacoes 
    {
        get{return transacoes;}
        set{transacoes = value;}
    }
    /*
        Cadastra uma nova transação para uma pessoa já cadastrada.
        Solicita ID da pessoa, descrição, valor e tipo da transação.
        Verifica restrições para menores de idade.
    */
    public void cadastrar(CadastroPessoas cadastroPessoas)
    {
        Console.WriteLine("\n\n---------- Transação --------- \n");

        Console.Write("ID Pessoa (ID gerado no cadastro): ");
        int idPessoa = int.Parse(Console.ReadLine());

        // Verifica se a pessoa existe no cadastro
        if (!cadastroPessoas.Pessoas.ContainsKey(idPessoa))
        {
            Console.WriteLine("Pessoa não encontrada. Operação cancelada.");
            return;
        }


        // Obtém a pessoa associada ao ID
        Pessoa pessoa = cadastroPessoas.Pessoas[idPessoa];

        id++;

        Console.Write("Descrição: ");
        string descricaoUsuario = Console.ReadLine();

        Console.Write("Valor: ");
        double valorUsuario = double.Parse(Console.ReadLine());

        // Verifica se o valor da transação é válido
        if (valorUsuario <= 0)
        {
            Console.WriteLine("O valor deve ser positivo. Operação cancelada.");
            id--;
            return;
        }

        Console.Write("Tipo (1 - Despesa / 2 - Receita): ");
        int tipoUsuario = int.Parse(Console.ReadLine());

        TipoTransacao tipo;

        switch (tipoUsuario)
        {
            case 1:
                tipo = TipoTransacao.DESPESA;
                break;
            case 2:
                // Restrição para menores de idade (somente despesas permitidas)
                if (pessoa.Idade < 18)
                {
                    Console.WriteLine("Menores de idade só podem registrar despesas. Operação cancelada.");
                    id--;
                    return;
                }
                tipo = TipoTransacao.RECEITA;
                break;
            default:
                Console.WriteLine("Opção inválida. Operação cancelada.");
                id--;
                return;
        }

        // Cria e adiciona a transação ao dicionário
        Transacao novaTransacao = new Transacao(id, descricaoUsuario, valorUsuario, tipo, idPessoa);
        transacoes.Add(id, novaTransacao);

        Console.WriteLine("✅ Transação cadastrada com sucesso! ID: " + id +"\n\n");
    }
    
    /*
        Exibe todas as transações cadastradas no formato de tabela.
        Caso não haja transações, exibe uma mensagem informativa.
    */
    public void exibir()
    {
        Console.WriteLine("\n----------- Lista de Transações ---------");
        if (transacoes.Count == 0)
        {
            Console.WriteLine("Nenhuma transação cadastrada.");
            return;
        }
        
        // Cabeçalho da tabela
        Console.WriteLine("\n"+ new string('-', TamanhoTabela.LinhaHorizontal));

        Console.WriteLine(
            "ID".PadRight(TamanhoTabela.IdTrasacao) +
            "| Descrição".PadRight(TamanhoTabela.Descricao) +
            "| Valor".PadRight(TamanhoTabela.Valor) +
            "| Tipo".PadRight(TamanhoTabela.Tipo) +
            "| ID Pessoa"
        );

        Console.WriteLine(new string('-', TamanhoTabela.LinhaHorizontal));
        
        foreach (KeyValuePair<int, Transacao> entrada in transacoes)
        {
            Transacao transacao = entrada.Value; // Obtém o objeto Transacao
            int id = entrada.Key; // Obtém a chave (ID)

            Console.WriteLine(
                $"{id.ToString().PadRight(TamanhoTabela.IdTrasacao)}" + // Usa o ID
                $"| {transacao.Descricao.PadRight(TamanhoTabela.Descricao-2)}" +
                $"| R$ {transacao.Valor.ToString("N2").PadLeft(TamanhoTabela.Valor-6)} " + 
                $"| {transacao.Tipo.ToString().PadRight(TamanhoTabela.Tipo-2)}" +
                $"| {transacao.IdPessoa}"
            );
        }

    }

    /*
        Remove todas as transações associadas a uma pessoa específica pelo ID.
        Busca transações vinculadas e as remove do dicionário.
    */
    public void RemoverTransacoesPorPessoa(int idPessoa)
    {
        var chavesParaRemover = transacoes
            .Where(transacao => transacao.Value.IdPessoa == idPessoa)
            .Select(transacao => transacao.Key)
            .ToList();

        foreach (var chave in chavesParaRemover)
        {
            transacoes.Remove(chave);
        }
    }
 }