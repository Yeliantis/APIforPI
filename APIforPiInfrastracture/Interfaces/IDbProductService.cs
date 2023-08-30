using APIforPI.Infrastracture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIforPI.Infrastracture.Interfaces
{
    public interface IDbProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
