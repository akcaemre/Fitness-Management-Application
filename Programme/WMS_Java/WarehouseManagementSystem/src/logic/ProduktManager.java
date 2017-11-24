package logic;

import data.Produkt;
import jdbc.ConnectionFactory;

import java.util.ArrayList;

public class ProduktManager {

    private static ArrayList<Produkt> allProducts;

    

    public static ArrayList<Produkt> getProdukts() {
        return allProducts;
    }

    public static void getItemsFromConnectionFactory() {
        ConnectionFactory.get();
    }

    public void startLoadingDataInTable() {
        allProducts = new ArrayList<>();
        //TODO: load data from database into "itemList"
        allProducts.add(new Produkt("L1-R1-E1-P1", "Produkt 1", 1, 11.30, "L1-R1-E1"));
        allProducts.add(new Produkt("L1-R1-E1-P2", "Produkt 1", 10, 11.30, "L1-R1-E1"));
        allProducts.add(new Produkt("L1-R1-E1-P3", "Produkt 2", 3, 3.50, "L1-R1-E1"));
        allProducts.add(new Produkt("L1-R1-E1-P4", "Produkt 2", 7, 3.50, "L1-R1-E1"));
        allProducts.add(new Produkt("L1-R1-E1-P5", "Produkt 2+", 1, 50.0, "L1-R1-E1"));
        allProducts.add(new Produkt("L1-R1-E1-P6", "Produkt 3", 0, 499.90, "L1-R1-E1"));
        allProducts.add(new Produkt("L1-R1-E1-P7", "Produkt 4", 15, 10.0, "L1-R1-E1"));
        allProducts.add(new Produkt("L1-R1-E1-P8", "Produkt 4+", 3, 14.90, "L1-R1-E1"));
        allProducts.add(new Produkt("L1-R1-E1-P9", "Produkt 5", 60, 1.30, "L1-R1-E1"));
        System.out.println("Items loaded into List");

//        for(int i = 0; i < itemList.size(); i++) {
//
//            tableViewProducts.getColumns().add(itemList.get(i));
//        }
//        System.out.println("after for loop");

    }
}
