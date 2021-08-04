/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package models;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import javafx.scene.control.ComboBox;
import javax.swing.JComboBox;
import util.FabricaDeConexoes;
/**
 *
 * @author Marcelo
 */
public class ClienteDAO {
    //Método que cria e abre uma conexão ao banco de dados
    static Connection con = FabricaDeConexoes.getConnection();
    
    //Método que cria um "cliente" no banco de dados
    public static boolean criarCliente(Cliente cliente){
        boolean erroCriarCliente;
        try{
            String sql = "insert into cliente(nome, cpf) values (?,?)";
            PreparedStatement stmt = con.prepareStatement(sql);
            stmt.setString(1, cliente.getNome());
            stmt.setString(2, cliente.getCPF());
            stmt.execute();
            stmt.close();
            erroCriarCliente = false;
        }catch(SQLException ex){
            System.out.println("Erro: " + ex);
            erroCriarCliente = true;
        }
        return erroCriarCliente;
    }
    
    public static Cliente buscarCliente(int id){
        Cliente cliente = null;
        try{
            PreparedStatement stmt = con.prepareStatement("select * from cliente where id=" + id);
            ResultSet rs = stmt.executeQuery();
            
            while(rs.next()){
                cliente = new Cliente();
                cliente.setId(id);
                cliente.setNome(rs.getString("nome"));
                cliente.setCPF(rs.getString("cpf"));
                return cliente;
            }
        }catch(SQLException ex){
            cliente = null;
            System.out.println("Erro: " + ex);
            return cliente;
        }
        return cliente;
    }
    
    //PAREI AQUI; Criando um array, pra ver se da pra mandar pro JComboBox
    public static List<Extrato> populaJComboBox(){
        List<Extrato> clientes = new ArrayList<>();
        try{
            PreparedStatement stmt = con.prepareStatement("select * from cliente");
            ResultSet rs = stmt.executeQuery();
            
            while(rs.next()){
                cmb.addItem(rs.getString("nome"));
                System.out.println("RODOU");
            }
            return cmb;
        }catch(SQLException ex){
            System.out.println("Erro PopulaJComboBox: " + ex);
            return cmb;
        }
        
    }
}
