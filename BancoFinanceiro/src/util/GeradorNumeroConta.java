package util;

import java.util.Random;

public class GeradorNumeroConta {
    
    public static int gerarNumeroConta(){
        Random r = new Random();
        int numAleatorio = r.nextInt(899999)+100000;
        return numAleatorio;
    }
}
