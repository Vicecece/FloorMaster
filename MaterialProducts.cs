//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FloorMaster
{
    using System;
    using System.Collections.Generic;
    
    public partial class MaterialProducts
    {
        public int ProductArticle { get; set; }
        public int MaterialID { get; set; }
        public int ID { get; set; }
    
        public virtual Material Material { get; set; }
        public virtual Product Product { get; set; }
    }
}
