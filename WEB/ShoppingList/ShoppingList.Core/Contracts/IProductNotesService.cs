using ShoppingList.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Core.Contracts
{
    public interface IProductNotesService
    {
        Task AddProductNoteAsync(int prodId, string content);
    }
}
