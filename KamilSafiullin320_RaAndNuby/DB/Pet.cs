//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KamilSafiullin320_RaAndNuby.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pet
    {
        public int Id_pet { get; set; }
        public Nullable<int> Id_pet_name { get; set; }
        public byte[] Photo { get; set; }
        public string Description { get; set; }
    
        public virtual Pet_name Pet_name { get; set; }
    }
}