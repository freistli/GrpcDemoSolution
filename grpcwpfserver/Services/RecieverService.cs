using Grpc.Core;
using GrpcService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace grpcwpfserver.Services
{
    class RecieverService : Reciever.RecieverBase
    {

        private readonly ILogger<RecieverService> _logger;
        public RecieverService(ILogger<RecieverService> logger)
        {
            _logger = logger;
        }

        public RecieverService()
        {
        }

        public override Task<Reply> ShowSubtitle(Subtitle request, ServerCallContext context)
        {
            return Task.FromResult(new Reply
            {
                Message = "200 Okay"
            }) ;
        }
    }
}
