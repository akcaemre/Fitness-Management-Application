package controller;

import data.Auslagern;
import javafx.fxml.FXML;
import javafx.scene.control.ListView;
import logic.ProduktManager;

import java.util.ArrayList;

public class ViewOrdersController {

    @FXML private ListView lv_allOrders;

    private ProduktManager pm;

    public ViewOrdersController() {

    }

    public void init(ProduktManager pm) {
        this.pm = pm;
        loadAllOrdersIntoListView();
    }

    private void loadAllOrdersIntoListView() {

    }

    private ArrayList<Auslagern> getOrdersFromDatabase() {
        return ProduktManager.getOrders();
    }

}
