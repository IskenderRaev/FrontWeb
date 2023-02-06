using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Core.Models;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Domain.Enums;


namespace StiGovKg.Application.MediatR.Questionnaires.Commands.CreateQuestionnaire
{
    public class CreateQuestionnaireCommand :IRequest<Result>
    {
        public Guid QuestionnaireId { get; set; }
        public Service Services { get; set; }
        public string? ServicesComment { get; set; }    
        public string? Rayoncode { get; set; }
        public DateTime DateApplication { get; set; }
        public WayOfAddress WayOfAddress { get; set; }
        public WaitingTime HowLongToWait { get; set; }
        public Answer ServiceProvidedInFull { get; set; }
        public Estimation ComfortPlaceOfService { get; set; }
        public Answer TermsOfServiceProvision { get; set; }
        public Estimation CompetenceOfEmployees { get; set; }       
        public WaitingTime HowLongToWaitAnswer { get; set; }
        public Estimation PhoneNumberConsultationGrade { get; set; }
        public Answer ServiceRequested { get; set; }
        public string? ServiceRequestedComment { get; set; }
        public Answer IssueResolved { get; set; }
        public Answer DifficultiesWithService { get; set; }
        public string? DifficultiesWithServiceComment { get; set; }
        public Estimation OverallAssessmentOfWork { get; set; }
        public string? SuggestionsAndCommentsWorkUGNS { get; set; }
        public string? SuggestionsAndCommentsWorkUGNSOrDivision { get; set; }
        public string? PhoneNumberConsultaion { get; set; }
        public string? SuggestionImprovement { get; set; }
        public ReviewStatus QuestionnaireStatus { get; set; }

    }

    public class CreateQuestionnaireCommandHandler : IRequestHandler<CreateQuestionnaireCommand , Result>
    {
        private readonly IStigovkgDbContext _context;
        private readonly ILogger<CreateQuestionnaireCommand> _logger;

        public CreateQuestionnaireCommandHandler(IStigovkgDbContext context, ILogger<CreateQuestionnaireCommand> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Result> Handle(CreateQuestionnaireCommand request , CancellationToken cancellationToken)
        {
            try
            {

                var entity = new Domain.Entities.Questionnaire
                {
                    QuestionnaireId = Guid.NewGuid(),
                    Services = request.Services,
                    ServicesComment = request.ServicesComment,                    
                    DateApplication = request.DateApplication,
                    Rayoncode = request.Rayoncode,
                    SuggestionImprovement = request.SuggestionImprovement,
                    SuggestionsAndCommentsWorkUGNS = request.SuggestionsAndCommentsWorkUGNS,
                    WayOfAddress = request.WayOfAddress,
                    HowLongToWait = request.HowLongToWait,
                    ServiceProvidedInFull = request.ServiceProvidedInFull,
                    ComfortPlaceOfService = request.ComfortPlaceOfService,
                    TermsOfServiceProvision = request.TermsOfServiceProvision,
                    CompetenceOfEmployees = request.CompetenceOfEmployees,
                    SuggestionsAndCommentsWorkUGNSOrDivision = request.SuggestionsAndCommentsWorkUGNSOrDivision,
                    HowLongToWaitAnswer = request.HowLongToWaitAnswer,
                    PhoneNumberConsultaion = request.PhoneNumberConsultaion,
                    PhoneNumberConsultationGrade = request.PhoneNumberConsultationGrade,
                    ServiceRequested = request.ServiceRequested,
                    ServiceRequestedComment = request.ServiceRequestedComment,
                    IssueResolved = request.IssueResolved,
                    DifficultiesWithService = request.DifficultiesWithService,
                    DifficultiesWithServiceComment = request.DifficultiesWithServiceComment,
                    OverallAssessmentOfWork = request.OverallAssessmentOfWork,
                    QuestionnaireStatus = ReviewStatus.NotReviwed
                };
                _context.Questionnaires.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Result.Success("Анкета успешно отправлена");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Questionnaire creation failed with error");
                return Result.Failure("Возникли ошибки при сохранении анкеты");
            }
        } 
    }
}
