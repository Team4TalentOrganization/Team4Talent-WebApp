using StudyGuidance.Domain;

namespace StudyGuidance.AppLogic
{
    public interface IQuestionRepository
    {
        Task<IReadOnlyList<Question>> GetQuestionsAsync();
        Task<IReadOnlyList<Option>> GetDomainsAsync();

        Task<IReadOnlyList<Option>> GetSubDomainsAsync(List<int> domainId);

    }
}
