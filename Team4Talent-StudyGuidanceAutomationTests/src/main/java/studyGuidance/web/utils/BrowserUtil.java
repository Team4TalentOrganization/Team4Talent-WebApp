package studyGuidance.web.utils;

import io.github.bonigarcia.wdm.managers.ChromeDriverManager;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;

public class BrowserUtil {

    public static WebDriver createBrowser(){
        ChromeOptions options = new ChromeOptions();
        options.addArguments("--window-size=375,812"); // Pas de grootte aan zoals nodig
        options.addArguments("--user-agent=Mozilla/5.0 (iPhone; CPU iPhone OS 11_0 like Mac OS X) AppleWebKit/604.1.38 (KHTML, like Gecko) Version/11.0 Mobile/15A372 Safari/604.1");
        options.addArguments("--headless");
        options.addArguments("--no-sandbox");
        options.addArguments("--disable-dev-shm-usage");
        ChromeDriverManager.chromedriver().setup();
        WebDriver driver = new ChromeDriver(options);
        //driver.manage().window().maximize();
        return driver;
    }

}
