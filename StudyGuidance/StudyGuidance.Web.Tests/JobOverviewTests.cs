﻿using Microsoft.AspNetCore.Components;
using Moq;
using StudyGuidance.Web.ApiClient;
using StudyGuidance.Web.Models;
using StudyGuidance.Web.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StudyGuidance.Web.Tests
{
    public class JobOverviewTests
    {
        [Test]
        public void GetMultiSelectionText_Should_Return_Correct_Text_Single_Selection()
        {
            // Arrange
            var jobOverview = new JobOverview();
            var selectedValues = new List<string> { "Subdomain1" };

            // Act
            var result = jobOverview.GetMultiSelectionText(selectedValues);

            // Assert
            Assert.AreEqual("1 subdomein is geselecteerd", result);
        }

        [Test]
        public void GetMultiSelectionText_Should_Return_Correct_Text_Multiple_Selections()
        {
            // Arrange
            var jobOverview = new JobOverview();
            var selectedValues = new List<string> { "Subdomain1", "Subdomain2" };

            // Act
            var result = jobOverview.GetMultiSelectionText(selectedValues);

            // Assert
            Assert.AreEqual("2 subdomeinen zijn geselecteerd", result);
        }
    }
}
