using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Core.Models;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Application.MediatR.Questionnaires.Commands.CreateQuestionnaire;
using StiGovKg.Domain.Enums;

namespace StiGovKg.Application.MediatR.Offers.Commands.CreateOffer
{
    public class CreateOfferCommands : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string? Text { get; set; }

    }

    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommands, Result>
    {

        private readonly IStigovkgDbContext _context;
        private readonly ILogger<CreateOfferCommands> _logger;
        public CreateOfferCommandHandler(IStigovkgDbContext context, ILogger<CreateOfferCommands> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Result> Handle(CreateOfferCommands request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new Domain.Entities.Offer
                {
                    Id = Guid.NewGuid(),
                    Text = request.Text,
                    Created = DateTime.Now,
                    OfferStatusEnum = OfferStatusEnum.NotReviewed,
                };
                _context.Offer.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return Result.Success("Предложение успешно отправлено");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Offer creation failed with error");
                return Result.Failure("Возникли ошибки при сохранении предложения");
            }
        }
    }
}
