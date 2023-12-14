import org.testng.Assert;
import org.testng.annotations.Test;
import studyGuidance.web.pageObjects.AllPages;

public class TestJobOverviewAndDetailViewPages {

    private AllPages pages;

    public void runPages(){
        pages = new AllPages();
        pages.jobOverviewPage.navigateTo();
        pages.jobOverviewPage.clickOnFirstJob();
    }

    @Test
    public void checksIfClickingOnJobSendsYouToJobdetailview(){

        runPages();
        Assert.assertEquals("https://studyguidancewebapp.azurewebsites.net/jobs/detail/1", pages.quizPage.getDriver().getCurrentUrl());
    }

    @Test
    public void checkIfJobODetailPageReturnsDescriptionString(){
        runPages();
        Assert.assertNotNull(pages.jobDetailView.descriptionField.toString());

    }


}
