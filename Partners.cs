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
    using System.Linq;

    public partial class Partners
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partners()
        {
            this.ApplicationProductPartners = new HashSet<ApplicationProductPartners>();
            this.SalePatnerPlaces = new HashSet<SalePatnerPlaces>();
        }
    
        public string TypeName
        {
            get
            {
                return TypePartners.Name;
            }
        }

        public int Id { get; set; }
        public int TypeID { get; set; }
        public string CompanyName { get; set; }
        public string LegalAdress { get; set; }
        public string INN { get; set; }
        public string SurnameDirector { get; set; }
        public string NameDirector { get; set; }
        public string PatronomycDirector { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public Nullable<decimal> Rating { get; set; }

        private int PartnerDiscount
        {
            get
            {
                if (FloorMasterEntities.GetContext().ManyArticle.Where(p => p.IDManyArticle == Id).Count() > 0)
                {
                    decimal PartnerProdQuantity = FloorMasterEntities.GetContext().ManyArticle.Where(p => p.IDManyArticle == Id).Sum(p => p.Count);

                    if (PartnerProdQuantity >= 10000 && PartnerProdQuantity < 50000)
                    {
                        return 5;
                    }
                    else if (PartnerProdQuantity >= 50000 && PartnerProdQuantity < 300000)
                    {
                        return 10;
                    }
                    else if (PartnerProdQuantity >= 300000)
                    {
                        return 15;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }

            }
        }

        public string PartnerDiscountDisplay
        {
            get
            {
                if (PartnerDiscount == 0)
                {
                    return "Нет скидки";
                }
                else
                {
                    return PartnerDiscount.ToString() + "%";
                }
            }
        }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationProductPartners> ApplicationProductPartners { get; set; }
        public virtual TypePartners TypePartners { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalePatnerPlaces> SalePatnerPlaces { get; set; }
    }
}
