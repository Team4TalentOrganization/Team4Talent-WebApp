package studyGuidance.web.pageObjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import java.sql.Driver;
import java.util.concurrent.TimeUnit;

public class JobOverviewPage extends BasePage{

    private final By jobOneButton = By.cssSelector("img[src='/images/person2.jpg']");
    public JobOverviewPage(WebDriver driver) {
        super(driver, "/jobs/Gustaph");
    }

    public void clickOnFirstJob(){
        driver.manage().timeouts().implicitlyWait(5, TimeUnit.SECONDS);
        WebElement jobOneButtonElement = driver.findElement(jobOneButton);
        jobOneButtonElement.click();

    }
}
