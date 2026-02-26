using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.RentVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.RentVehicle
{
    /// <summary>
    /// Handler for rent vehicle request.
    /// </summary>
    public sealed class RentVehicleRequestHandler : IRequestHandler<RentVehicleRequest, IWebApiPresenter>
    {
        private readonly IRentVehicleUseCase _useCase;
        private readonly RentVehiclePresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleRequestHandler"/> class.
        /// </summary>
        /// <param name="useCase">Use case.</param>
        /// <param name="presenter">Presenter.</param>
        public RentVehicleRequestHandler(IRentVehicleUseCase useCase, RentVehiclePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        /// <inheritdoc />
        public async Task<IWebApiPresenter> Handle(RentVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new RentVehicleInput(request.VehicleId, request.PersonId));
            return _presenter;
        }
    }
}
