/******************************************************************************

Welcome to GDB Online.
GDB online is an online compiler and debugger tool for C, C++, Python, Java, PHP, Ruby, Perl,
C#, OCaml, VB, Swift, Pascal, Fortran, Haskell, Objective-C, Assembly, HTML, CSS, JS, SQLite, Prolog.
Code, Compile, Run and Debug online from anywhere in world.

*******************************************************************************/
using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Title = "Console de Diagnóstico de Rede";

        while (true)
        {
            MostrarMenu();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nDigite um comando: ");
            string comando = Console.ReadLine().ToLower();

            switch (comando)
            {
                case "1":
                case "ping":
                    ExecutarPing();
                    break;

                case "2":
                case "formatar":
                    FormatarUnidade();
                    break;

                case "help":
                case "?":
                    MostrarAjuda();
                    break;

                case "sair":
                    Console.WriteLine("Encerrando sistema...");
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Comando não reconhecido. Digite 'help' para ajuda.");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("=== Console de Diagnóstico de Rede ===\n");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[1] Ping em IP");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[2] Formatar Unidade");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nDigite 'help' ou '?' para ajuda");
        Console.WriteLine("Digite 'sair' para encerrar");
    }

    static void MostrarAjuda()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n=== AJUDA ===");

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1 ou 'ping'      → Testa conexão com um IP.");
        Console.WriteLine("2 ou 'formatar'  → Apaga todos os dados da unidade.");
        Console.WriteLine("help ou '?'      → Mostra esta ajuda.");
        Console.WriteLine("sair             → Encerra o sistema.");
    }

    static void ExecutarPing()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\nDigite o IP (ex: 192.168.0.1): ");
        string ip = Console.ReadLine();

        if (!ValidarIP(ip))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("⚠ IP inválido!");
            Console.WriteLine("Formato esperado: xxx.xxx.xxx.xxx (ex: 192.168.0.1)");
            return;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✔ Ping realizado com sucesso para {ip}!");
    }

    static bool ValidarIP(string ip)
    {
        string pattern = @"^(\d{1,3}\.){3}\d{1,3}$";
        return Regex.IsMatch(ip, pattern);
    }

    static void FormatarUnidade()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n⚠ ATENÇÃO: Esta ação apagará TODOS os dados!");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("Digite 'CONFIRMAR' para continuar ou qualquer outra tecla para cancelar: ");

        string confirmacao = Console.ReadLine();

        if (confirmacao == "CONFIRMAR")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✔ Unidade formatada com sucesso!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Operação cancelada com segurança.");
        }
    }
}