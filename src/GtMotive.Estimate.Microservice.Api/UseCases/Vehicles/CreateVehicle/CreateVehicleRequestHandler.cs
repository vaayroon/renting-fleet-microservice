using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.CreateVehicle;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.CreateVehicle
{
    /// <summary>
    /// Handler for create vehicle request.
    /// </summary>
    public sealed class CreateVehicleRequestHandler : IRequestHandler<CreateVehicleRequest, IWebApiPresenter>
    {
        private readonly ICreateVehicleUseCase _useCase;
        private readonly CreateVehiclePresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateVehicleRequestHandler"/> class.
        /// </summary>
        /// <param name="useCase">Create vehicle use case.</param>
        /// <param name="presenter">Create vehicle presenter.</param>
        public CreateVehicleRequestHandler(ICreateVehicleUseCase useCase, CreateVehiclePresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        /// <inheritdoc />
        public async Task<IWebApiPresenter> Handle(CreateVehicleRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new CreateVehicleInput(request.Plate, request.ManufactureDate));
            return _presenter;
        }
    }
}
