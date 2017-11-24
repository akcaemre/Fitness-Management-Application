package controller;

import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.stage.Stage;
import logic.ProduktManager;

import java.io.IOException;

/*
* This controller class manages all actions which were triggered in the main menu window.
* I uses a product manager class that holds all the items (products) and makes it available for
* all the other windows.
* TODO: It is not transaction save but we are working on it.
*/

public class MainMenuController {


    @FXML
    private Button buttonAddItem;

    private ProduktManager pm;

    public void addItemIntoWarehouse() {

        try {
            FXMLLoader fxmlLoader = new FXMLLoader();
            fxmlLoader.setLocation(getClass().getResource("/fxml/addItemPage.fxml"));

            Scene scene = new Scene(fxmlLoader.load(), 500, 300);
            scene = new Scene(fxmlLoader.load(), 500, 300);
            Stage stage = new Stage();
            stage.setTitle("Warehouse Management System");
            stage.setScene(scene);
            stage.show();
        }
        catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void removeItemFromWarehouse() throws Exception{

        try {
            FXMLLoader fxmlLoader = new FXMLLoader();
            fxmlLoader.setLocation(getClass().getResource("/fxml/removeItemPage.fxml"));

            Scene scene = new Scene(fxmlLoader.load(), 500, 300);
            Stage stage = new Stage();
            stage.setTitle("Warehouse Management System");
            stage.setScene(scene);
            stage.show();
        }
        catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void addNewProduct() throws Exception{

    }

    public void viewAllWarehouseItems() throws Exception{
        try {
            pm = new ProduktManager();


            FXMLLoader fxmlLoader = new FXMLLoader();
            fxmlLoader.setLocation(getClass().getResource("/fxml/viewAllPage.fxml"));
            ShowWarehouseController swc = fxmlLoader.getController();

            Scene scene = new Scene(fxmlLoader.load(), 900, 600);
            Stage stage = new Stage();
            stage.setTitle("Warehouse Management System");
            stage.setScene(scene);

            stage.show();
            swc.startLoadingDataInTable();
        }
        catch (IOException e) {
            e.printStackTrace();
        }
    }

}
