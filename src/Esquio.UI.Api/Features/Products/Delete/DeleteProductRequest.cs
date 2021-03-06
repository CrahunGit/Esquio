﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Esquio.UI.Api.Features.Products.Delete
{
    public class DeleteProductRequest : IRequest
    {
        public int ProductId { get; set; }
    }
}
