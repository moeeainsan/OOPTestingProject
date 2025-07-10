using System;

namespace MedicineManagementProject.Domain
{
    public class Medicine
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public DateTime ExpiryDate { get; private set; }

        public Medicine(string name, int quantity, DateTime expiryDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("名前は必須です");
            if (quantity < 0)
                throw new ArgumentException("数量は0以上である必要があります");

            Name = name;
            Quantity = quantity;
            ExpiryDate = expiryDate;
        }

        public void SetId(int id)
        {
            if (Id == 0)
            {
                Id = id;
            }
        }

        public void ChangeQuantity(int delta)
        {
            if (Quantity + delta < 0)
                throw new InvalidOperationException("在庫が不足しています。");
            Quantity += delta;
        }

        public void UpdateExpiry(DateTime newExpiryDate)
        {
            ExpiryDate = newExpiryDate;
        }

        public void UpdateFrom(Medicine other)
        {
            Name = other.Name;
            Quantity = other.Quantity;
            ExpiryDate = other.ExpiryDate;
        }

        public override string ToString()
        {
            return $"ID: {Id} / 名前: {Name} / 数量: {Quantity} / 有効期限: {ExpiryDate:yyyy-MM-dd}";
        }
    }
}
