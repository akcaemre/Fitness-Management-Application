package controller;

import data.Produkt;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.Label;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.input.MouseEvent;
import logic.ProduktManager;

import java.util.*;

public class ShowWarehouseController {

    @FXML private TableView<Produkt> tv_products;

    @FXML private TextField tb_search;

    @FXML private Label lbl_id;
    @FXML private Label lbl_name;
    @FXML private Label lbl_beschreibung;
    @FXML private Label lbl_menge;
    @FXML private Label lbl_preis;

    @FXML private TableColumn<Produkt, String> col_id;
    @FXML private TableColumn<Produkt, String> col_name;

    private ArrayList<Produkt> itemList;
    private ProduktManager pm;
    TableView tableViewProducts;

    private Produkt selectedItem;


    public ShowWarehouseController() {
    }

    public void init(ProduktManager pm) {
        //System.out.println("Until here it worked fine");
        this.pm = pm;
        tableViewProducts = new TableView();

        tb_search.setText("Search...");

        startLoadingDataIntoTable();
        showProductsInTableView();
        //tv_products.setItems((ObservableList) itemList);
    }

    public void testInit() {
        final ObservableList<Produkt> data = FXCollections.observableArrayList(
                new Produkt("test id1", "test name", 100, 1000.01, "test ebenen id1"),
                new Produkt("test id2", "test name", 100, 1000.01, "test ebenen id2"),
                new Produkt("test id3", "test name", 100, 1000.01, "test ebenen id3"),
                new Produkt("test id4", "test name", 100, 1000.01, "test ebenen id4"),
                new Produkt("test id5", "test name", 100, 1000.01, "test ebenen id5")
        );


        tv_products.setEditable(true);

        TableColumn firstNameCol = new TableColumn("ID");
        firstNameCol.setMinWidth(100);
        firstNameCol.setCellValueFactory(
                new PropertyValueFactory<>("id"));

        TableColumn lastNameCol = new TableColumn("Name");
        lastNameCol.setMinWidth(100);
        lastNameCol.setCellValueFactory(
                new PropertyValueFactory<>("name"));

        tv_products.setItems(data);
        tv_products.getColumns().addAll(firstNameCol, lastNameCol);

        tv_products.refresh();
    }


    public void searchActionTriggered(ActionEvent actionEvent) {
        String searchString = tb_search.getText().toString();
        //System.out.println(searchString);
    }

    /*
    * This method uses the ProduktManagerClass to load the data from the Database into the itemList
    */
    public void startLoadingDataIntoTable() {
        pm.loadAllProductsFromDB();
        itemList = ProduktManager.getProdukts();
    }

    /*
    * This method displays all items in the itemList in the tableView by inserting them
    */
    public void showProductsInTableView() {

        for(int i = 0; i < itemList.size(); i++) {
            System.out.println("ID: " + itemList.get(i).getpId());
            tableViewProducts.getItems().add(itemList.get(i));
        }

        //tv_products.setItems((ObservableList<Produkt>) itemList);
//
//        col_id = new TableColumn<>("ID");
//        col_id.setCellValueFactory(cellData -> {
//            Produkt rowIndex = cellData.getValue();
//            return new ReadOnlyStringWrapper(itemList.get(rowIndex).getpId());
//        });
//
//        col_name = new TableColumn<>("Name");
//        col_name.setCellValueFactory(cellData -> {
//            Produkt rowIndex = cellData.getValue();
//            return new ReadOnlyStringWrapper(itemList.get(rowIndex).getName());
//        });
//
//        tv_products.getColumns().add(col_id);
//        tv_products.getColumns().add(col_name);
//        tv_products.refresh();

        //tv_products = tableViewProducts;
        //tv_products.setItems((ObservableList) itemList);
        tv_products.refresh();

        System.out.println("Is Table Visible: " + tv_products.isVisible());
    }


    /*
    * This method updates the labels in the info box, depending on which item the user selected
    */
    public void updateInfoBox(Produkt p) {
        System.out.println("Infobox updated");
        lbl_id.setText(p.getpId());
        lbl_name.setText(p.getName());
        lbl_beschreibung.setText("Description");
        lbl_preis.setText(String.valueOf(p.getEinheitspreis()));
        lbl_menge.setText(String.valueOf(p.getMenge()));
    }

    public void onItemSelected(MouseEvent mouseEvent) {
        selectedItem = tv_products.getSelectionModel().getSelectedItem();
        updateInfoBox(selectedItem);
    }

    // this method gets called when the user presses the "Entnehmen" button in the view
    public void onActionProduktEntnehmen(ActionEvent actionEvent) {
        ProduktManager.removeProduct(selectedItem.getpId(), 10);
    }

    // this method gets called when the user presses the "Einlagern" button in the view
    public void onActionProduktEinlagern(ActionEvent actionEvent) {
        ProduktManager.insertProduct(selectedItem.getpId(), 10);
    }
}
