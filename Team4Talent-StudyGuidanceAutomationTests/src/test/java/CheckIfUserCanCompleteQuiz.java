import org.testng.Assert;
import org.testng.annotations.Test;
import studyGuidance.web.pageObjects.AllPages;

public class CheckIfUserCanCompleteQuiz {

    @Test
    public void getThroughFullQuizToLandOnJobOverviewPage(){
        AllPages pages = new AllPages();
        pages.quizPage.navigateTo();
        pages.quizPage.runStandardQuiz();
        pages.quizPage.runTinderQuiz();

        //Assert.assertEquals("https://localhost:7063/jobs", pages.quizPage.getDriver().getCurrentUrl());
        Assert.assertEquals("https://studyguidancewebapp.azurewebsites.net/jobs", pages.quizPage.getDriver().getCurrentUrl());
    }

}
