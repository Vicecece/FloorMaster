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
    
    public partial class MaterialHistory
    {
        public int IDMaterial { get; set; }
        public int Count { get; set; }
        public System.DateTime Date { get; set; }
        public string Status { get; set; }
    
        public virtual Material Material { get; set; }
    }
}
