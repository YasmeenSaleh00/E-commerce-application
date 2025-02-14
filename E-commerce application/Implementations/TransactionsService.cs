﻿using E_commerce_application.Context;
using E_commerce_application.DTOs.Transaction.Request;
using E_commerce_application.DTOs.Transaction.Response;
using E_commerce_application.Entities;
using E_commerce_application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_application.Implementations
{
    public class TransactionsService : ITransactionsService
    {
        private readonly CommerceDbContext _context;
        public  TransactionsService(CommerceDbContext context)
        {
            _context = context;
        }
        public async Task CreateTransaction(CreateTransactionDTO input)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == input.OrderId);
            if (order != null)
            {
                if (order.StatusOrderId == 14)
                {
                    TransactionOrder transaction = new TransactionOrder
                    {
                        OrderId = input.OrderId,
                        DeliveryInfo = input.DeliveryInfo,
                        DeliveryDate = input.DeliveryDate,

                    };
                    _context.Transactions.Add(transaction);

                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Transaction can only be created for orders with status Accepted.");
                }
            }
            else
            {
                throw new Exception("Order not found.");
            }


        }

        public async Task<List<TransactionDTO>> ReadAllTransaction()
        {
            var result = from li in _context.Transactions
                         select new TransactionDTO
                         {
                             Id = li.Id,
                             OrderId = li.OrderId,
                             DeliveryInfo = li.DeliveryInfo,
                             DeliveryDate = li.DeliveryDate.ToShortDateString(),
                             CreationDate = li.CreationDate.ToShortDateString(),
                             isDeleted = li.IsDeleted,


                         };
            return await result.ToListAsync();
        }
    }
}
