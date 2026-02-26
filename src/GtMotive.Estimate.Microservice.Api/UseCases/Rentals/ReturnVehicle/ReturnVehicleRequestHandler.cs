using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.ReturnVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Rentals.ReturnVehicle
{
    /// <summary>
    /// Handler for return vehicle request.
    /// </summary>
    public sealed class ReturnVehicleRequestHandler : IRequestHandler<ReturnVehicleRequest, IWebApiPresenter>
    {
        private readonly IReturnVehicleUseCase _useCase;
        private readonly ReturnVehiclePresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleRequestHandler"/> class.
        /// </summary>
        /// <param name="useCase">Use case.</param>
        /// <param name="presenter">Presenter.</param>
        public ReturnVehicleRequestHandler(IReturnVehicleUseCase useCase, ReturnVehiclePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        /// <inheritdoc />
        public async Task<IWebApiPresenter> Handle(ReturnVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new ReturnVehicleInput(request.RentalId));
            return _presenter;
        }
    }
}
