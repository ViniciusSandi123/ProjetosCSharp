using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security;
class JogoDaVelha
{
    static void Main(string[] args)
    {
        char continuar = 's', fim = 's', x = 'X', o = 'O', contiuarJogo = 's';
        bool vitoria = false;
        int linha, coluna, i, j, jogadas = 0, t = 3;
        const int MIN = 0, MAX = 2;
        char[,] tabuleiro;
        tabuleiro = new char[t, t];
        //inicia o jogo
        do
        {
            //forma o tabuleiro
            for (i = 0; i < t; i++)
            {
                for (j = 0; j < t; j++)
                {
                    tabuleiro[i, j] = '-';
                    contiuarJogo = 's';
                    jogadas = 0;
                }
            }
            //cria o looping das jogas dos jogadores 1 e 2
            while (fim != 'n')
            {
                //faz a primeira distribuição do jogo
                for (i = 0; i < t; i++)
                {
                    for (j = 0; j < t; j++)
                    {
                        Console.Write(tabuleiro[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                //jogada jogador 1
                while (contiuarJogo != 'n')
                {

                    Console.Write("Digite uma posição(L,C) jogador 1: ");
                    string[] j1 = Console.ReadLine().Split(',');
                    linha = int.Parse(j1[0]);
                    coluna = int.Parse(j1[1]);
                    //caso o jogador digite um numero fora do range do tabuleiro
                    if ((linha < MIN || linha > MAX) || (coluna < MIN || coluna > MAX))
                    {
                        Console.WriteLine("Posição invalida, digite novamente por favor !!");
                        continuar = 's';
                    }
                    else
                    {
                        //verifica se a linha está vazia caso esteja vai marcar com x
                        if (tabuleiro[linha, coluna] == '-')
                        {
                            tabuleiro[linha, coluna] = x;
                            jogadas++;
                            contiuarJogo = 'n';
                            //verifica se o jogodor venceu
                            for (i = 0; i < t; i++)
                            {
                                //verifica a linha
                                if ((tabuleiro[i, 0] == x && tabuleiro[i, 1] == x && tabuleiro[i, 2] == x))
                                {
                                    vitoria = true;
                                }
                                //verifica a coluna
                                else if ((tabuleiro[0, i] == x && tabuleiro[1, i] == x && tabuleiro[2, i] == x))
                                {
                                    vitoria = true;
                                }
                                //verifica diagonais
                                else if ((tabuleiro[0, 0] == x && tabuleiro[1, 1] == x && tabuleiro[2, 2] == x) ||
                                   (tabuleiro[0, 2] == x && tabuleiro[1, 1] == x && tabuleiro[2, 0] == x))
                                {
                                    vitoria = true;
                                }
                            }
                            //caso algum dos validadores se confirme declara a vitoria
                            if (vitoria == true)
                            {
                                for (i = 0; i < t; i++)
                                {
                                    for (j = 0; j < t; j++)
                                    {
                                        Console.Write(tabuleiro[i, j] + " ");
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine("Vitória jogador 1 !!");
                                contiuarJogo = 'n';
                            }
                        }
                        //caso o jogador tente preencher um campo já preenchido
                        else if (tabuleiro[linha, coluna] != '-')
                        {
                            Console.WriteLine("Campo ja preenchido !!");
                        }
                    }
                }
                //caso todas os campos do tabuleiro sejam preenchidos e ninguem ganhe
                if (jogadas == 9)
                {
                    Console.WriteLine("Deu velha !!");
                    break;
                }
                //caso algum jogador vença encerra a partida
                if (vitoria == true)
                {
                    break;
                }
                //reseta o status, para ir para a proxima jogada
                contiuarJogo = 's';

                //mostra o tabuleiro novamente
                for (i = 0; i < t; i++)
                {
                    for (j = 0; j < t; j++)
                    {
                        Console.Write(tabuleiro[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                //jogada jogador 2
                while (contiuarJogo != 'n')
                {
                    Console.Write("Digite uma posição(L,C) jogador 2: ");
                    string[] j1 = Console.ReadLine().Split(',');
                    linha = int.Parse(j1[0]);
                    coluna = int.Parse(j1[1]);

                    if ((linha < MIN || linha > MAX) || (coluna < MIN || coluna > MAX))
                    {
                        Console.WriteLine("Posição invalida, digite novamente por favor !!");
                        continuar = 's';
                    }
                    else
                    {
                        //verifica se a linha está vazia caso esteja vai marcar com x
                        if (tabuleiro[linha, coluna] == '-')
                        {
                            tabuleiro[linha, coluna] = o;
                            jogadas++;
                            contiuarJogo = 'n';
                            //verifica se o jogodor venceu
                            for (i = 0; i < t; i++)
                            {
                                //verifica a linha
                                if ((tabuleiro[i, 0] == o && tabuleiro[i, 1] == o && tabuleiro[i, 2] == o))
                                {
                                    vitoria = true;
                                }
                                //verifica a coluna
                                else if ((tabuleiro[0, i] == o && tabuleiro[1, i] == o && tabuleiro[2, i] == o))
                                {
                                    vitoria = true;
                                }
                                //verifica diagonais
                                else if ((tabuleiro[0, 0] == o && tabuleiro[1, 1] == o && tabuleiro[2, 2] == o) ||
                                   (tabuleiro[0, 2] == o && tabuleiro[1, 1] == o && tabuleiro[2, 0] == o))
                                {
                                    vitoria = true;
                                }
                            }
                            //caso algum dos validadores se confirme declara a vitoria
                            if (vitoria == true)
                            {
                                for (i = 0; i < t; i++)
                                {
                                    for (j = 0; j < t; j++)
                                    {
                                        Console.Write(tabuleiro[i, j] + " ");
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine("Vitória jogador 2 !!");
                                contiuarJogo = 'n';
                            }
                        }
                        //caso o jogador tente preencher um campo já preenchido
                        else if (tabuleiro[linha, coluna] != '-')
                        {
                            Console.WriteLine("Campo ja preenchido !!");
                        }
                    }
                }
                //caso todas os campos do tabuleiro sejam preenchidos e ninguem ganhe
                if (jogadas == 9)
                {
                    Console.WriteLine("Deu velha !!");
                    break;
                }
                contiuarJogo = 's';
                if (vitoria == true)
                {
                    break;
                }
            }

            Console.Write("Deseja continuar jogando ?(s/n): ");
            continuar = char.Parse(Console.ReadLine());

            if (continuar == 'n')
            {
                Console.WriteLine("Fim de jogo");
            }
        } while (continuar != 'n');
    }
}