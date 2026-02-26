using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ListAvailableVehicles;
using MediatR;

namespace GtMotive.Estimate.Microservice.Api.UseCases.Vehicles.ListAvailableVehicles
{
    /// <summary>
    /// Handler for listing available vehicles request.
    /// </summary>
    public sealed class ListAvailableVehiclesRequestHandler : IRequestHandler<ListAvailableVehiclesRequest, IWebApiPresenter>
    {
        private readonly IListAvailableVehiclesUseCase _useCase;
        private readonly ListAvailableVehiclesPresenter _presenter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesRequestHandler"/> class.
        /// </summary>
        /// <param name="useCase">Use case.</param>
        /// <param name="presenter">Presenter.</param>
        public ListAvailableVehiclesRequestHandler(
            IListAvailableVehiclesUseCase useCase,
            ListAvailableVehiclesPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        /// <inheritdoc />
        public async Task<IWebApiPresenter> Handle(ListAvailableVehiclesRequest request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new ListAvailableVehiclesInput());
            return _presenter;
        }
    }
}
