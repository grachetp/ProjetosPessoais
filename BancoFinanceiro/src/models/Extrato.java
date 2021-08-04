/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package models;

/**
 *
 * @author Marcelo
 */
public class Extrato {

    /**
     * @return the id_conta
     */
    public int getId_conta() {
        return id_conta;
    }

    /**
     * @param id_conta the id_conta to set
     */
    public void setId_conta(int id_conta) {
        this.id_conta = id_conta;
    }

    /**
     * @return the id_transacao
     */
    public int getId_transacao() {
        return id_transacao;
    }

    /**
     * @param id_transacao the id_transacao to set
     */
    public void setId_transacao(int id_transacao) {
        this.id_transacao = id_transacao;
    }

    /**
     * @return the valor
     */
    public float getValor() {
        return valor;
    }

    /**
     * @param valor the valor to set
     */
    public void setValor(float valor) {
        this.valor = valor;
    }

    /**
     * @return the acao
     */
    public String getAcao() {
        return acao;
    }

    /**
     * @param acao the acao to set
     */
    public void setAcao(String acao) {
        this.acao = acao;
    }
    private int id_conta;
    private int id_transacao;
    private float valor;
    private String acao;
}
