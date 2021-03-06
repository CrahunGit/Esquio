﻿using MediatR;

namespace Esquio.UI.Api.Features.Products.Update
{
    public class UpdateProductRequest : IRequest
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
