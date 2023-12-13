package studyGuidance.web.pageObjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import java.util.concurrent.TimeUnit;

public class HomePage extends BasePage{
    private final By hamburgerMenuButton = By.cssSelector("button.navbar-toggler");

    public HomePage(WebDriver driver) {
        super(driver, "/");
    }

    public void openHamburgerMenu(){
        driver.manage().timeouts().implicitlyWait(5, TimeUnit.SECONDS);
        WebElement hamburgerMenuButtonElement = driver.findElement(hamburgerMenuButton);
        hamburgerMenuButtonElement.click();
    }


}
