using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppStore.Models;

namespace WebAppStore.Repository
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
