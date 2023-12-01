﻿using StudyGuidance.Web.Models;

namespace StudyGuidance.Web.ApiClient
{
	public interface IJobApiClient
	{
		Task<Job> GetJobByIdAsync(int id);
		Task<List<Job>> GetJobsAsync();
		Task<List<Job>> GetJobsByFilterAsync(List<string> subdomains, bool workInTeam, bool workOnSite);
		Task<List<Option>> GetAllSubDomains();
	}
}