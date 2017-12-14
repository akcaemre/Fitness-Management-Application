package logic;

import data.Auslagern;
import data.Produkt;
import jdbc.ConnectionFactory;

import java.sql.*;
import java.util.ArrayList;

public class ProduktManager {

    private static ArrayList<Produkt> allProducts;
    private static ArrayList<Auslagern> allOrders;
    private static Connection con;
    

    public static ArrayList<Produkt> getProdukts() {
        return allProducts;
    }

    public static ArrayList<Auslagern> getOrders() {
        return allOrders;
    }




    public ProduktManager() {
        try {
            con = ConnectionFactory.get();
        } catch (SQLException e) {
            e.printStackTrace();

        }
    }



    public static void loadAllProductsFromDB() {

        try {
            allProducts = new ArrayList<Produkt>();
            Statement stmt = con.createStatement();
            ResultSet rs = stmt.executeQuery("select * from produkt");

            while(rs.next()) {
                // adds all items from the result set into the allProducts ArrayList
                allProducts.add(new Produkt(rs.getString(1), rs.getString(2), rs.getInt(3),
                rs.getDouble(4), rs.getString(5)));
            }

        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public static void removeProduct(String id, int amount) {
        try {
            Statement stmt = con.createStatement();
            stmt.executeUpdate("update produkt set menge = menge-" + amount +  " where id =" + id + " and menge > " + amount);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public static void insertProduct(String id, int amount) {
        try {
            Statement stmt = con.createStatement();
            stmt.executeUpdate("update produkt set menge = menge+" + amount +  " where id =" + id);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }


    public static void loadAllOrdersFromDB() {
        try {
            allOrders = new ArrayList<Auslagern>();
            Statement stmt = con.createStatement();
            ResultSet rs = stmt.executeQuery("select * from auslagern");

            while(rs.next()) {
                // adds all items from the result set into the allProducts ArrayList
                allProducts.add(new Produkt(rs.getString(1), rs.getString(2), rs.getInt(3),
                        rs.getDouble(4), rs.getString(5)));
            }

        } catch (SQLException e) {
            e.printStackTrace();
        }
    }



//    public void startLoadingDataInTable() {
//        allProducts = new ArrayList<>();
//        //TODO: load data from database into "itemList"
//        allProducts.add(new Produkt("L1-R1-E1-P1", "Produkt 1", 1, 11.30, "L1-R1-E1"));
//        allProducts.add(new Produkt("L1-R1-E1-P2", "Produkt 1", 10, 11.30, "L1-R1-E1"));
//        allProducts.add(new Produkt("L1-R1-E1-P3", "Produkt 2", 3, 3.50, "L1-R1-E1"));
//        allProducts.add(new Produkt("L1-R1-E1-P4", "Produkt 2", 7, 3.50, "L1-R1-E1"));
//        allProducts.add(new Produkt("L1-R1-E1-P5", "Produkt 2+", 1, 50.0, "L1-R1-E1"));
//        allProducts.add(new Produkt("L1-R1-E1-P6", "Produkt 3", 0, 499.90, "L1-R1-E1"));
//        allProducts.add(new Produkt("L1-R1-E1-P7", "Produkt 4", 15, 10.0, "L1-R1-E1"));
//        allProducts.add(new Produkt("L1-R1-E1-P8", "Produkt 4+", 3, 14.90, "L1-R1-E1"));
//        allProducts.add(new Produkt("L1-R1-E1-P9", "Produkt 5", 60, 1.30, "L1-R1-E1"));
//        System.out.println("Items loaded into List");
//
//        for(int i = 0; i < itemList.size(); i++) {
//
//            tableViewProducts.getColumns().add(itemList.get(i));
//        }
//        System.out.println("after for loop");
//
//    }

}
