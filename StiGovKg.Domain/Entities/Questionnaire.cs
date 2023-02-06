using StiGovKg.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Entities
{
    public class Questionnaire
    {
        public Guid QuestionnaireId { get; set; }
        public Service Services { get; set; }
        public string ServicesComment { get; set; }
       
        public string Rayoncode { get; set; }
        public DateTime DateApplication { get; set; }
        
        public WayOfAddress WayOfAddress { get; set; }
        public WaitingTime HowLongToWait { get; set; }
        public Answer ServiceProvidedInFull { get; set; }
        public Estimation ComfortPlaceOfService { get; set; }
        public Answer TermsOfServiceProvision { get; set; }
        public Estimation CompetenceOfEmployees { get; set; }
        public Estimation PerformanceAppraisal { get; set; }
        public WaitingTime HowLongToWaitAnswer { get; set; }
        public Estimation PhoneNumberConsultationGrade { get; set; }        
        public Answer ServiceRequested { get; set; }
        public string ServiceRequestedComment { get; set; }
        public Answer IssueResolved { get; set; }
        public Answer DifficultiesWithService { get; set; }
        public string DifficultiesWithServiceComment { get; set; }
        public Estimation OverallAssessmentOfWork { get; set; }
        public string SuggestionsAndCommentsWorkUGNS { get; set; }
        public string SuggestionsAndCommentsWorkUGNSOrDivision { get; set; }
        public string PhoneNumberConsultaion { get; set; }
        public string SuggestionImprovement { get; set; }

        public ReviewStatus QuestionnaireStatus { get; set; }

    }
}
