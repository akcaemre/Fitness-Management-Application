package controller;

import data.Produkt;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;

import java.util.*;

public class ShowWarehouseController {

    @FXML
    private TableView tableViewProducts;
    @FXML
    private TableColumn tableColumnId;
    @FXML
    private TableColumn tableColumnName;
    @FXML
    private TextField tb_search;

    private ArrayList<Produkt> itemList;

    public ShowWarehouseController() {
    }




    public void searchActionTriggered(ActionEvent actionEvent) {
        String searchString = tb_search.getText().toString();
        System.out.println(searchString);
    }
}
