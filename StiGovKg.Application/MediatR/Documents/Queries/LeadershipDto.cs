using StiGovKg.Domain.Entities;

namespace StiGovKg.Application.MediatR.Documents.Queries
{
    public record LeadershipDto(
    string FullName,
    DateTime BirthDate,
    string BirthPlace,
    string Position,
    string RankInSpeciality,
    string Email,
    string TimeOfReceipt,
    Guid DocumentId,
    List<Education> Education,
    List<WorkExperience> WorkExperiences);
}