using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineManagement.MedicineManagement
{
    internal class Medicine
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} /名前: {Name} / 数量: {Quantity} / 有効期限: {ExpiryDate:yyyy-MM-dd}";
        }
    }
}
