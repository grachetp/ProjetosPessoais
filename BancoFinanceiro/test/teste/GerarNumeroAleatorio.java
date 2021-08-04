package teste;

import java.util.Random;

public class GerarNumeroAleatorio {
    public static void main(String[] args) {
        System.out.println("Gerando números aleatórios com 6 digitos");
        Random r = new Random();
        
        for(int i=0; i<35;i++){
            int n = r.nextInt(899999)+100000;
            System.out.println((i+1) + "°:" + n);
        }
    }
}
