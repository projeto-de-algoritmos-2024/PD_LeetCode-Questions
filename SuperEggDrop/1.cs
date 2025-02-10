using System;

public class Solution
{
    public int SuperEggDrop(int k, int n)
    {
        // Criamos uma matriz para armazenar os resultados intermediários
        int[,] dp = new int[k + 1, n + 1];

        // Inicializamos a contagem de tentativas
        int tentativas = 0;

        while (dp[k, tentativas] < n)
        {
            tentativas++;

            for (int ovos = 1; ovos <= k; ovos++)
            {
                // Calculamos a melhor tentativa baseada em casos anteriores
                // dp[ovos, tentativas] = Total de andares que podemos testar com "ovos" e "tentativas"
                dp[ovos, tentativas] =
                    dp[ovos - 1, tentativas - 1] // Caso o ovo quebre (testamos abaixo)
                    + dp[ovos, tentativas - 1] // Caso o ovo não quebre (testamos acima)
                    + 1; // Contabilizamos o andar atual
            }
        }

        return tentativas;
    }
}
