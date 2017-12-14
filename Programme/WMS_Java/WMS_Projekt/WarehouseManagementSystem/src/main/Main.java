package main;

import controller.MainMenuController;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

import java.sql.Connection;
import java.sql.SQLException;

public class Main extends Application {

    @Override
    public void start(Stage primaryStage) throws Exception{

        FXMLLoader fxmlLoader = new FXMLLoader();
        fxmlLoader.setLocation(getClass().getResource("/fxml/mainMenuPage.fxml"));
        Parent root = fxmlLoader.load();
        Scene scene = new Scene(fxmlLoader.load(), 900, 600);
        primaryStage.setTitle("Warehouse Management System");
        primaryStage.setScene(new Scene(root, 600, 400));


        MainMenuController mmc = fxmlLoader.getController();
        mmc.init();

        primaryStage.show();
    }


    public static void main(String[] args) {
        launch(args);
    }
}
