package studyGuidance.web.pageObjects;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

import java.util.concurrent.TimeUnit;

public class QuizPage extends BasePage{
    private final By standardQuizButton = By.cssSelector("p.m-auto");
    private final By standardQuizNextButton = By.cssSelector("button.nextButton");
    private final By tinderQuizCrossButton = By.cssSelector("svg.bi-x-circle");
    private final By tinderQuizCheckButton = By.cssSelector("svg.bi-check-circle");
    public QuizPage(WebDriver driver) {
        super(driver, "/quiz");
    }

    public void runStandardQuiz(){
        driver.manage().timeouts().implicitlyWait(5, TimeUnit.SECONDS);
        WebElement standardQuizButton1Element1 = driver.findElement(standardQuizButton);
        standardQuizButton1Element1.click();
        WebElement standardQuizNextButtonElement1 = driver.findElement(standardQuizNextButton);
        standardQuizNextButtonElement1.click();

        driver.manage().timeouts().implicitlyWait(5, TimeUnit.SECONDS);
        WebElement standardQuizButton1Element2 = driver.findElement(standardQuizButton);
        standardQuizButton1Element2.click();
        WebElement standardQuizNextButtonElement2 = driver.findElement(standardQuizNextButton);
        standardQuizNextButtonElement2.click();

        driver.manage().timeouts().implicitlyWait(5, TimeUnit.SECONDS);
        WebElement standardQuizButton1Element3 = driver.findElement(standardQuizButton);
        standardQuizButton1Element3.click();
        WebElement standardQuizNextButtonElement3 = driver.findElement(standardQuizNextButton);
        standardQuizNextButtonElement3.click();

    }

    public void runTinderQuiz() {
        driver.manage().timeouts().implicitlyWait(5, TimeUnit.SECONDS);
        WebElement tinderQuizCrossButtonElement = driver.findElement(tinderQuizCrossButton);
        tinderQuizCrossButtonElement.click();

        WebElement tinderQuizCheckButtonElement = driver.findElement(tinderQuizCheckButton);
        tinderQuizCheckButtonElement.click();

        WebElement tinderQuizCheckButtonElement2 = driver.findElement(tinderQuizCheckButton);
        tinderQuizCheckButtonElement2.click();
    }
}
