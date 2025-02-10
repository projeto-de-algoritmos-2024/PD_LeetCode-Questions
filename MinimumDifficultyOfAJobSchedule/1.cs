using System;

public class Solution
{
    public int MinDifficulty(int[] jobDifficulty, int d)
    {
        int n = jobDifficulty.Length;
        if (n < d)
            return -1; // Se houver mais dias do que trabalhos, impossível dividir

        // Inicializa a matriz de DP com valores altos
        int[,] dp = new int[d + 1, n + 1];
        for (int i = 0; i <= d; i++)
            for (int j = 0; j <= n; j++)
                dp[i, j] = int.MaxValue;

        dp[0, 0] = 0; // Começamos do primeiro trabalho, sem dias usados

        // Algoritmo de Bellman-Ford 
        for (int dia = 1; dia <= d; dia++)
        { // Para cada dia
            for (int i = 0; i < n; i++)
            { // Começa um novo intervalo de trabalhos
                int dificuldadeMaxima = 0;
                for (int j = i; j < n; j++)
                { // Expande o intervalo até j
                    dificuldadeMaxima = Math.Max(dificuldadeMaxima, jobDifficulty[j]); // Atualiza a maior dificuldade

                    if (dp[dia - 1, i] != int.MaxValue)
                    {
                        // Atualiza o menor custo encontrado
                        dp[dia, j + 1] = Math.Min(
                            dp[dia, j + 1],
                            dp[dia - 1, i] + dificuldadeMaxima
                        );
                    }
                }
            }
        }

        return dp[d, n] == int.MaxValue ? -1 : dp[d, n]; // Retorna a menor dificuldade total possível
    }
}
