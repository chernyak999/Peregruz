//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Peregruz.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RouteId { get; set; }
        public int CarId { get; set; }
        public int DriverId { get; set; }
        public int StatusId { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Driver Driver { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Route Route { get; set; }
    }
}
