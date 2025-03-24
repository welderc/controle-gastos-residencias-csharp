using System;

/*
    Classe responsável por consultar e exibir totais financeiros do sistema.
    Calcula receitas, despesas e saldos individuais de cada pessoa cadastrada, além do consolidado geral.
    Utiliza dados de CadastroPessoas e CadastroTransacoes para gerar relatórios formatados.
*/

class ConsultaTotais
{
    private CadastroPessoas cadastroPessoas; // Referência ao cadastro de pessoas
    private CadastroTransacoes cadastroTransacoes; // Referência ao cadastro de transações
    
    // Construtor da classe, recebe instâncias de CadastroPessoas e CadastroTransacoes
    public ConsultaTotais(CadastroPessoas cadastroPessoas, CadastroTransacoes cadastroTransacoes)
    {
        this.cadastroPessoas = cadastroPessoas;
        this.cadastroTransacoes= cadastroTransacoes;
    }

    /*
        Exibe um relatório detalhado de receitas, despesas e saldo por pessoa cadastrada.
        Calcula também os totais gerais de receitas e despesas no sistema.
    */
    public void exbirTotais()
    {
        Console.WriteLine("\n===============================");
        Console.WriteLine(" 📊 CONSULTA DE TOTAIS ");
        Console.WriteLine("===============================\n");

        double totalReceitasGeral = 0;
        double totalDespesasGeral = 0;

        Dictionary<int, Pessoa> pessoas = cadastroPessoas.Pessoas;
        Dictionary<int, Transacao> transacoes = cadastroTransacoes.Transacoes;

        // Verifica se há pessoas cadastradas
        if (pessoas.Count == 0)
        {
            Console.WriteLine("❌ Nenhuma pessoa cadastrada.");
            return;
        }

        // Percorre todas as pessoas cadastradas para calcular receitas e despesas
        foreach (Pessoa pessoa in pessoas.Values)
        {
            double totalReceitas = 0;
            double totalDespesas = 0;

            // Percorre todas as transações associadas à pessoa
            foreach (Transacao transacao in transacoes.Values)
            {
                if (transacao.IdPessoa == pessoa.Identificador)
                {
                    if (transacao.Tipo == TipoTransacao.RECEITA)
                    {
                        totalReceitas += transacao.Valor;
                    }
                    else if (transacao.Tipo == TipoTransacao.DESPESA)
                    {
                        totalDespesas += transacao.Valor;
                    }
                }
            }

            double saldo = totalReceitas - totalDespesas;

            // Exibe o resumo financeiro individual
            Console.WriteLine("👤 Pessoa: " +pessoa.Nome+ " (ID: " +pessoa.Identificador+ ")");
            Console.WriteLine("   ➕ Receita Total: R$ " + totalReceitas);
            Console.WriteLine("   ➖ Despesa Total: R$ " + totalDespesas);
            Console.WriteLine("   💰 Saldo: R$ " + saldo);
            Console.WriteLine("--------------------------------------");

            totalReceitasGeral += totalReceitas;
            totalDespesasGeral += totalDespesas;
        }

        double saldoGeral = totalReceitasGeral - totalDespesasGeral;

        // Exibe os totais gerais do sistema
        Console.WriteLine("\n=========== TOTAL GERAL ===========");
        Console.WriteLine("📈 Receita Total: R$ " + totalReceitasGeral);
        Console.WriteLine("📉 Despesa Total: R$ " + totalDespesasGeral);
        Console.WriteLine("💰 Saldo Líquido: R$ " + saldoGeral);
        Console.WriteLine("====================================\n");

    }
}