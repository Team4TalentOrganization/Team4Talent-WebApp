import org.openqa.selenium.chrome.ChromeOptions;
import org.testng.annotations.Test;
import studyGuidance.web.pageObjects.AllPages;

public class OpenHamburgerMenu {
    @Test
    public void testIfHamburgerMenuOpens() {
        AllPages pages = new AllPages();
        pages.homePage.navigateTo();
        pages.homePage.openHamburgerMenu();
    }
}
