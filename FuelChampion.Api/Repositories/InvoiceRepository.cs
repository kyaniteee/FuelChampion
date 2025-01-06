﻿using FuelChampion.Api.Data;
using FuelChampion.Api.Models;

namespace FuelChampion.Api.Repositories;

public class InvoiceRepository : RepositoryBase<Invoice>, IInvoiceRepository
{
    public InvoiceRepository(DBContext context) : base(context)
    {
    }
}