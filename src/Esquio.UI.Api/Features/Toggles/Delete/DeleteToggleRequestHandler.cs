﻿using Esquio.EntityFrameworkCore.Store;
using Esquio.UI.Api.Diagnostics;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Esquio.UI.Api.Features.Toggles.Delete
{
    public class DeleteToggleRequestHandler : IRequestHandler<DeleteToggleRequest>
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly ILogger<DeleteToggleRequestHandler> _logger;

        public DeleteToggleRequestHandler(StoreDbContext storeDbContext, ILogger<DeleteToggleRequestHandler> logger)
        {
            _storeDbContext = storeDbContext ?? throw new ArgumentNullException(nameof(storeDbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteToggleRequest request, CancellationToken cancellationToken)
        {
            var toggle = await _storeDbContext
                .Toggles
                .Where(t => t.Id == request.ToggleId)
                .SingleOrDefaultAsync(cancellationToken);

            if (toggle != null)
            {
                _storeDbContext.Remove(toggle);
                await _storeDbContext.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }

            Log.ToggleNotExist(_logger, request.ToggleId.ToString());
            throw new InvalidOperationException($"Toggle with id {request.ToggleId} does not exist in the store.");
        }
    }
}
