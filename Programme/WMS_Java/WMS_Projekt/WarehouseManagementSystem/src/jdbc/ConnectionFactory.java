/**
 *
 */
package jdbc;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.sql.ResultSet;
import java.io.OutputStream;
import java.util.Properties;
import java.sql.Connection;
import java.sql.SQLException;
import java.sql.DriverManager;
import java.sql.Statement;

/**
 * @author Paoli Jakob
 *
 */

public class ConnectionFactory {

    private static String user 		= "d5a01";
    private static String pwd 		= "d5a";
    private static String url 		= "jdbc:oracle:thin:@192.168.128.152:1521:ora11g";
    private static String driver 	= "oracle.jdbc.OracleDriver";
    private static String host 		= "aphrodite4";

    private static ConnectionFactory conFac = new ConnectionFactory();

    /**
     * Get- & Set-Methods
     */
    public static String getUser() {
        return user;
    }
    public static String getPwd() {
        return pwd;
    }
    public static String getUrl() {
        return url;
    }
    public static String getDriver() {
        return driver;
    }
    public static String getHost() {
        return host;
    }


    public static void setUser(String user) {
        ConnectionFactory.user = user;
    }
    public static void setPwd(String pwd) {
        ConnectionFactory.pwd = pwd;
    }
    public static void setUrl(String url) {
        ConnectionFactory.url = url;
    }
    public static void setDriver(String driver) {
        ConnectionFactory.driver = driver;
    }
    public static void setHost(String host) {
        ConnectionFactory.host = host;
    }
    public static void setConn(ConnectionFactory conn) {
        ConnectionFactory.conFac = conn;
    }

    /**
     * Constructor
     */
    private ConnectionFactory(){}


    /**
     * Connection Factory Methods
     */
    public static Connection get() throws SQLException {
        try {
            Class.forName(driver);
        } catch (ClassNotFoundException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
        System.out.println("url:" + url + "  user:" + user + "   pwd: " + pwd);
        return DriverManager.getConnection(url, user, pwd);
    }
    public static ConnectionFactory getConn() {
        return conFac;
    }

    public static boolean close(Connection c){
        boolean tof = true;
        try{
            c.close();
        }
        catch(Exception ex){
            tof = false;
        }
        return tof;
    }
    public static boolean close(Statement s) {
        boolean tof = true;
        try{
            s.close();
        }
        catch(Exception ignore){
            tof = false;
        }
        return tof;
    }
    public static boolean close(ResultSet rs){
        boolean tof = true;
        try{
            rs.close();
        }
        catch(Exception ignore){
            tof= false;
        }
        return tof;
    }
}
