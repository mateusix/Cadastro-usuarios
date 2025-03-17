/*
 * 📌 Case Técnico - Cadastro de Usuários (C# Console App)
 * --------------------------------------------------------
 * 🔹 Funcionalidades:
 *    - Cadastrar usuários (Nome, E-mail, Idade)
 *    - Listar todos os usuários
 *    - Buscar usuário pelo nome
 * 🔹 Desenvolvido por: Mateus Padilha de Oliveira
 * 🔹 Data: 17/03/2025
 */

// COMO RODAR:
// 1. Compile o código em um compilador C#.
// 2. Execute o programa no terminal ou IDE de sua escolha.
// 3. Se estiver usando VS Code: no terminal Digite o comando dotnet run
// 4. O programa exibirá um menu com as opções:
//    - Cadastrar Usuário
//    - Listar Usuários
//    - Buscar Usuário por Nome
//    - Sair
// 5. Escolha a opção digitando o número correspondente e siga as instruções na tela.


using System;
using System.Collections.Generic;

// Classe principal que contém a execução do programa
class Program
{
    // Lista para armazenar os usuários em memória
    static List<Usuario> usuarios = new List<Usuario>();

    static void Main()
    {
        while (true)
        {
            // Exibe o menu de opções
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Cadastrar Usuário");
            Console.WriteLine("2 - Listar Usuários");
            Console.WriteLine("3 - Buscar Usuário por Nome");
            Console.WriteLine("4 - Sair");
            Console.Write("Opção: ");
            
            string opcao = Console.ReadLine();

            // Chama a função correspondente à opção escolhida
            switch (opcao)
            {
                case "1":
                    CadastrarUsuario();
                    break;
                case "2":
                    ListarUsuarios();
                    break;
                case "3":
                    BuscarUsuario();
                    break;
                case "4":
                Console.WriteLine("\n---Programa Encerrado---\n");
                    return; // Sai do programa
                default:
                    Console.WriteLine("Opção inválida, Tente novamente.");
                    break;
            }
        }
    }

    // Função para cadastrar um novo usuário
    static void CadastrarUsuario()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("E-mail: ");
        string email = Console.ReadLine();

        Console.Write("Idade: ");
        if (int.TryParse(Console.ReadLine(), out int idade))
        {
            // Adiciona o novo usuário à lista
            usuarios.Add(new Usuario(nome, email, idade));
            Console.WriteLine("Usuário cadastrado com sucesso!");
        }
        else
        {
            Console.WriteLine("Idade inválida! Cadastro cancelado.");
        }
    }

    // Função para listar todos os usuários cadastrados
    static void ListarUsuarios()
    {
        if (usuarios.Count == 0)
        {
            Console.WriteLine("Nenhum usuário cadastrado.");
            return;
        }

        Console.WriteLine("\nLista de Usuários:");
        foreach (var usuario in usuarios)
        {
            Console.WriteLine(usuario);
        }
    }

    // Função para buscar um usuário pelo nome
    static void BuscarUsuario()
    {
        Console.Write("Digite o nome do usuário: ");
        string nomeBusca = Console.ReadLine();

        // Procura o usuário na lista
        Usuario encontrado = usuarios.Find(u => u.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase));

        if (encontrado != null)
        {
            Console.WriteLine("\nUsuário encontrado:");
            Console.WriteLine(encontrado);
        }
        else
        {
            Console.WriteLine("\nUsuário não encontrado.");
        }
    }
}

// Classe que representa um usuário
class Usuario
{
    public string Nome { get; }
    public string Email { get; }
    public int Idade { get; }

    // Construtor para inicializar o usuário
    public Usuario(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
    }

    // Método para exibir as informações do usuário
    public override string ToString()
    {
        return $"Nome: {Nome}, E-mail: {Email}, Idade: {Idade}";
    }
}
