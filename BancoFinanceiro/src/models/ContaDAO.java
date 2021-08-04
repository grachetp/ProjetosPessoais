package models;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import javax.swing.JOptionPane;
import models.Conta;
import models.Extrato;
import util.FabricaDeConexoes;

public class ContaDAO {
    
    static Connection con = FabricaDeConexoes.getConnection();
    
    static public boolean criarConta(Conta conta){
        boolean erroCriarConta;
        try{
            String sql = "insert into conta(id_cliente, numero, senha) values (?,?,?)";
            PreparedStatement stmt = con.prepareStatement(sql);
            stmt.setInt(1, conta.getCliente().getId());
            stmt.setInt(2, conta.getNumConta());
            stmt.setInt(3, conta.getSenha());
            stmt.execute();
            stmt.close();
            erroCriarConta = false;
        }catch(SQLException ex){
            erroCriarConta = true;
            System.out.println("Erro: " + ex);
        }
        return erroCriarConta;
    }
    
    static public Conta buscarConta(int num_conta){
        Conta conta = null;
        try{
            PreparedStatement stmt = con.prepareStatement("SELECT * FROM conta where numero= " + num_conta);
            ResultSet rs = stmt.executeQuery();
            
            while(rs.next()){
                conta = new Conta();
                conta.setNumConta(num_conta);
                conta.setSaldo(rs.getFloat("saldo"));
                conta.setSenha(rs.getInt("senha"));
                conta.setCliente(ClienteDAO.buscarCliente(rs.getInt("id_cliente")));
                return conta;
            }
            stmt.close();
        }catch(SQLException ex){
            conta = null;
            JOptionPane.showMessageDialog(null, "Erro:" + ex);
            return conta;
        }
            return conta;
    }
    public static void salvaDeposito(Conta contaLogada){
        Conta conta = new Conta();
        conta = contaLogada;
        try{
            String sql = "update conta set saldo="+ conta.getSaldo() + " where numero=" +conta.getNumConta();
            PreparedStatement stmt = con.prepareStatement(sql);
            stmt.executeUpdate();
            stmt.close();
        }catch(SQLException ex){
            JOptionPane.showMessageDialog(null, "Erro ao salvar deposito: " + ex);
        }
    }
    
    public static void salvaSaque(Conta contaLogada){
        Conta conta = new Conta();
        conta = contaLogada;
        try{
            String sql = "update conta set saldo="+ conta.getSaldo() + " where numero=" +conta.getNumConta();
            PreparedStatement stmt = con.prepareStatement(sql);
            stmt.executeUpdate();
            stmt.close();
        }catch(SQLException ex){
            JOptionPane.showMessageDialog(null, "Erro ao salvar saque: " + ex);
        }
        
    }
    
    public List<Extrato> gerarExtrato(int num_conta){
        List<Extrato> resumo_extrato = new ArrayList<>();
        try{
            PreparedStatement stmt = null;
            ResultSet rs = null;
            
            stmt = con.prepareStatement("select * from extrato where id_conta=" + num_conta);
            rs = stmt.executeQuery();
            
            while(rs.next()){
                Extrato extrato = new Extrato();
                extrato.setId_conta(rs.getInt("id_conta"));
                extrato.setId_transacao(rs.getInt("id_transacao"));
                extrato.setValor(rs.getFloat("valor"));
                extrato.setAcao(rs.getString("tipo"));
                resumo_extrato.add(extrato);
            }
            stmt.close();
        }catch(SQLException ex){
                JOptionPane.showMessageDialog(null, "Erro:" + ex);
        }
        return resumo_extrato;
}
}