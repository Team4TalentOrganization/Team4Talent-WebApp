package studyGuidance.web.pageObjects;

import org.openqa.selenium.WebDriver;
import studyGuidance.web.utils.BrowserUtil;

public class AllPages {
    public HomePage homePage;
    public QuizPage quizPage;
    public JobOverviewPage jobOverviewPage;

    public JobDetailView jobDetailView;

    public AllPages(){
        WebDriver driver = BrowserUtil.createBrowser();
        homePage = new HomePage(driver);
        quizPage = new QuizPage(driver);
        jobOverviewPage = new JobOverviewPage(driver);
        jobDetailView = new JobDetailView(driver);
    }
}
