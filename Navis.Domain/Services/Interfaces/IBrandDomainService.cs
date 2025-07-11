﻿using Navis.Domain.Entities;
using Navis.Domain.Repository.Filters;

namespace Navis.Domain.Services.Interfaces
{
    public interface IBrandDomainService : IDomainService<Brand, BrandFilter>
    {
    }
}
