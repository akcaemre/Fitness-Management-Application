package controller;

import javafx.event.ActionEvent;
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

    private ProduktManager mainPdktMngr;

    public void init() {
        mainPdktMngr = new ProduktManager();
    }


    public void viewWarehouseItems(ActionEvent actionEvent) {
        try {

            FXMLLoader fxmlLoader = new FXMLLoader();
            fxmlLoader.setLocation(getClass().getResource("/fxml/viewAllPage.fxml"));
            Scene scene = new Scene(fxmlLoader.load(), 900, 600);
            Stage stage = new Stage();
            stage.setTitle("Warehouse Management System");
            stage.setScene(scene);

            ShowWarehouseController swc = fxmlLoader.<ShowWarehouseController>getController();
            swc.init(mainPdktMngr);

            stage.show();
        }
        catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void onViewOrdersButtonClicked(ActionEvent actionEvent) {
        try {
            FXMLLoader fxmlLoader = new FXMLLoader();
            fxmlLoader.setLocation(getClass().getResource("/fxml/viewOrdersPage.fxml"));
            Scene scene = new Scene(fxmlLoader.load(), 900, 600);
            Stage stage = new Stage();
            stage.setTitle("Warehouse Management System");
            stage.setScene(scene);

            ViewOrdersController voc = fxmlLoader.<ViewOrdersController>getController();
            voc.init(mainPdktMngr);

            stage.show();
        }
        catch (IOException e) {
            e.printStackTrace();
        }
    }
}
