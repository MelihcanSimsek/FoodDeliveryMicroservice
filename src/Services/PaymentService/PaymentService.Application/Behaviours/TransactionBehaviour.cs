using MediatR;
using PaymentService.Application.Interfaces.Transactional;
using PaymentService.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Behaviours
{
    public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>, ITransactionalEvent
    {
        private readonly IUnitOfWork unitOfWork;

        public TransactionBehaviour(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            await unitOfWork.BeginTransactionAsync();
            try
            {
                TResponse response = await next();

                await unitOfWork.CommitTransactionAsync();
                return response;
            }
            catch
            {
                await unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
