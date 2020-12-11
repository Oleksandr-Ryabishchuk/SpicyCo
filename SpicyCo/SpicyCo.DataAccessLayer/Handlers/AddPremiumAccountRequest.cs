using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpicyCo.DataAccessLayer.Handlers
{
    public class AddPremiumAccountRequest: IRequest<AddPremiumAccountResponse>
    {
        public int PremiumType { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class AddPremiumAccountResponse
    {
        public decimal Cost { get; set; }
    }

    public class AddPremiumAccountHandler: IRequestHandler<AddPremiumAccountRequest, 
                                           AddPremiumAccountResponse>
    {
        public AddPremiumAccountHandler()
        {

        }

        public async Task<AddPremiumAccountResponse> Handle(AddPremiumAccountRequest request, 
                                                            CancellationToken cancellationToken)
        {
            return await Task.FromResult(new AddPremiumAccountResponse { Cost = 25 });
        }
    }
}
