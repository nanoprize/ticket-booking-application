//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Национальная_деревня
{
    using System;
    using System.Collections.Generic;
    
    public partial class Билеты
    {
        public Билеты()
        {
            this.Заказ = new HashSet<Заказ>();
        }
    
        public int Id { get; set; }
        public string тип { get; set; }
        public Nullable<int> цена { get; set; }
    
        public virtual ICollection<Заказ> Заказ { get; set; }
    }
}
