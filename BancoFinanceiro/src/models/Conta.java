package models;

public class Conta {

    
    
    //Variáveis do Objeto Conta
    private int numConta;
    private float saldo;
    private int senha;
    private Cliente cliente;

    
    //Métodos Getter's e Setter's
    
    public Cliente getCliente() {
        return cliente;
    }

    public void setCliente(Cliente cliente) {
        this.cliente = cliente;
    }
    
    public int getNumConta() {
        return numConta;   
    }

    public void setNumConta(int numConta) {
        this.numConta = numConta;
    }

    public float getSaldo() {
        return saldo;
    }

    public void setSaldo(float saldo) {
        this.saldo = saldo;
    }

    public int getSenha() {
        return senha;
    }

    public void setSenha(int senha) {
        this.senha = senha;
    }
    
    //Método Sacar do Tipo Boolean
    public boolean sacar(float quantidade){ 
    if (this.saldo < quantidade)
        return false;
    else{
        this.saldo -= quantidade;
        return true;
      }
  } 
  
  public void depositar (float quantidade){ //método depositar
    this.saldo += quantidade; //depositar um valor na conta
      //saldo = saldo + quantidade;
  }
  
  public boolean transferir(Conta contaDestino, float quantidade){ //método transferir...
    if (this.saldo < quantidade)
      return false;
    else
      {
        this.saldo = this.saldo - quantidade;
        contaDestino.saldo = contaDestino.saldo + quantidade;
        return true;
      }
  }

}
