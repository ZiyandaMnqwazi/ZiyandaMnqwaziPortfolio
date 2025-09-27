namespace ZiyandaMnqwaziPortfolio.ProjectRepository
{
    public interface IEmailService
    {
        Task sendEmailAsync(string to, string subject, string body);
    }
}
