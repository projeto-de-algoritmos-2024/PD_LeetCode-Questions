using System;

public class Solution {
    public int LastStoneWeightII(int[] stones) {
        int totalPedras = stones.Length;
        int somaTotal = 0;

        foreach (int pedra in stones) {
            somaTotal += pedra;
        }

        int capacidadeMochila = somaTotal / 2;
        bool[,] dp = new bool[totalPedras + 1, capacidadeMochila + 1];
        dp[0, 0] = true;

        // Algoritmo da Mochila 
        for (int i = 1; i <= totalPedras; i++) {
            int pesoAtual = stones[i - 1];
            for (int j = 0; j <= capacidadeMochila; j++) {
                if (dp[i - 1, j]) { 
                    dp[i, j] = true; // Mantém a soma existente
                    if (j + pesoAtual <= capacidadeMochila) {
                        dp[i, j + pesoAtual] = true; // Adiciona a pedra à soma possível
                    }
                }
            }
        }

        // Encontra a soma mais próxima de metade do total
        for (int j = capacidadeMochila; j >= 0; j--) {
            if (dp[totalPedras, j]) {
                return somaTotal - 2 * j;
            }
        }

        return 0;
    }
}
