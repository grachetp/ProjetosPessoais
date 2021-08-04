/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package util;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 *
 * @author Marcelo
 */
public class FabricaDeConexoes {
    static String URL = "jdbc:mysql://localhost:3306/banco_bradesco?useTimezone=true&serverTimezone=UTC";
    static String USER = "root";
    static String PASS = "";
    
    public static Connection getConnection(){
        System.out.println("Conectando ao banco de dados");
        try{
            return DriverManager.getConnection(URL, USER, PASS);
        }catch(SQLException e){
            System.out.println(e.getMessage());
            return null;
        }
    }
}
