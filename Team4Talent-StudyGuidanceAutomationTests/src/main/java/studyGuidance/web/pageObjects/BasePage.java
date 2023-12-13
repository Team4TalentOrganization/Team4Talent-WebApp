package studyGuidance.web.pageObjects;

import org.openqa.selenium.WebDriver;

public class BasePage {

    public WebDriver driver;

    public WebDriver getDriver() {
        return driver;
    }

    public void setDriver(WebDriver driver) {
        this.driver = driver;
    }

    private final String baseUrl = "https://studyguidancewebapp.azurewebsites.net";
    //private final String baseUrl = "https://localhost:7063";
    private String url;

    public BasePage(WebDriver driver, String endpoint){
        this.driver = driver;
        this.url = baseUrl + endpoint;
    }

    public void navigateTo(){
        driver.get(url);
    }

}
