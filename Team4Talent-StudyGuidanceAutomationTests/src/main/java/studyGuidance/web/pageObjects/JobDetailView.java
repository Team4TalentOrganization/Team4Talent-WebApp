package studyGuidance.web.pageObjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class JobDetailView extends BasePage{

    public final By descriptionField = By.cssSelector("div.row:nth-child(5) > .col");

    public JobDetailView(WebDriver driver) {
        super(driver, "/jobs/detail/1");
    }
}
